using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace MySockets {

    public class ClientTCP: IDisposable {
        private TcpClient _tcpServer;
        private byte[] _data;
        private NetworkStream _networkStream;
        private Receiver _receiver;
        private Sender _sender;
        public bool Connected {
            get {
                try {
                    _tcpServer.Client.Send(System.Text.Encoding.ASCII.GetBytes("\0"));
                }
                catch (SocketException) {
                    return false;
                }
               return true;
            }
        }
        private int _bytes;

        public event EventHandler<DataReceivedEventArgs> DataReceived;

        public ClientTCP(string ipAddress, int port) {
            _tcpServer = new TcpClient(ipAddress, port);
            _data = new byte[1024];
            _networkStream = _tcpServer.GetStream();

            _receiver = new Receiver(_networkStream);
            _sender = new Sender(_networkStream);

            _receiver.DataReceived += OnDataReceived;
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e) {
            var handler = DataReceived;
            if (handler != null) {
                DataReceived(this, e);
            }
        }

        public void SendMessage(string msg) {
            _sender.Message = msg;
        }

        public string GetResponse() {
            string result;
            _bytes = _networkStream.Read(_data, 0, _data.Length);
            result = System.Text.Encoding.ASCII.GetString(_data, 0, _bytes);

            return result;
        }

        public void Dispose() {
            _networkStream = null;
            _receiver = null;
            _sender = null;
            _tcpServer.Close();
        }
    }

    sealed internal class Receiver {
        private NetworkStream _stream;
        private System.Threading.Thread _thread;
        private byte[] _data;

        public event EventHandler<DataReceivedEventArgs> DataReceived;

        public Receiver(NetworkStream stream) {
            _stream = stream;
            _data = new byte[1024];
            _thread = new System.Threading.Thread(Run);
            _thread.Start();
        }

        private void Run() {
            bool loop = true;
            while (loop) {
                try {
                    if (_stream != null && !_stream.DataAvailable) {
                        Thread.Sleep(1);
                    }
                    else if (_stream != null && _stream.Read(_data, 0, _data.Length) > 0) {
                        if (DataReceived != null) {
                            DataReceived(this, new DataReceivedEventArgs(_data));
                            _data = new byte[1024];
                        }
                    }
                    else { //ehh don't really want to close the stream
                        _stream.Close();
                    }
                }
                catch (Exception) {
                    _stream.Close();
                    loop = false;
                }
            }
        }
    }

    sealed internal class Sender {
        private NetworkStream _stream;
        private System.Threading.Thread _thread;
        private byte[] _data;
        public string Message { get; set; }

        public Sender(NetworkStream stream) {
            _stream = stream;
            _data = new byte[1024];
            _thread = new System.Threading.Thread(Run);
            _thread.Start();
        }

        private void Run() {
            try {
                while (true) {
                    try {
                        if (!string.IsNullOrEmpty(Message)) {
                            _data = System.Text.Encoding.ASCII.GetBytes(Message);
                            _stream.Write(_data, 0, _data.Length);
                            Message = null;
                            _data = new byte[1024];
                        }
                        else {
                            Thread.Sleep(1);
                        }
                    }
                    catch (System.IO.IOException iex) {
                        _stream.Close();
                    }
                }
            }
            catch (Exception ex) {
                _stream.Close();
            }
            finally {
                _stream.Dispose();
            }
        }
    }

    public class DataReceivedEventArgs : EventArgs {
        public string DataAsString {
            get {
                return System.Text.Encoding.ASCII.GetString(DataAsByte);
            }
        }
        public byte[] DataAsByte { get; set; }

        public DataReceivedEventArgs(byte[] data) {
            DataAsByte = data;
        }
    }


	public class Client {
		#region Public Properties
		public System.Net.IPAddress IPAddress {
			get {
				return _ipAddress;
			}
			set {
				_ipAddress = value;
			}
		}

        public int Port {
            get;
            set;
        }

		public Socket ClientSocket {
			get {
				return _clientSocket;
			}
			set {
				_clientSocket = value;
			}
		}

		public bool Connected {
            get {
                try {
                    ClientSocket.Send(new byte[0]);
                }
                catch (Exception ex) { } //i'm expecting this to fail if it's not connected
                return ClientSocket.Connected;
            }
		}
		#endregion Public Properties

		#region Private Memebers
		private System.Net.IPAddress _ipAddress;
		private Socket _clientSocket;
		#endregion Private Members

		#region Constructors
		public Client(): this("192.168.1.1",8221) { }

		public Client(string address, int port) {
			System.Net.IPAddress.TryParse(address, out _ipAddress);
			this.Port = System.Net.IPAddress.NetworkToHostOrder(port);
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}
		#endregion Cosntructors

		#region Public Methods
		public void EndConnection() {
			//ClientSocket.Disconnect(true);
            ClientSocket.Close();
		}

		public void Send(string message) {
			byte[] sendMessage = System.Text.Encoding.ASCII.GetBytes(message);
			try {

				ClientSocket.BeginSend(sendMessage, 0, sendMessage.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
			}
			catch (SocketException se) {
				if (se.SocketErrorCode  == SocketError.ConnectionReset) {
					EndConnection();
                    throw;
				}
			}
		}

        public string GetResponse() {
            byte[] buffer = new byte[1024];
            int received = 0;
            try {
                if (_clientSocket.Connected && _clientSocket.Available != 0) {
                    received = _clientSocket.Receive(buffer, SocketFlags.None);
                }
            }
            catch (SocketException se) {
                if (se.SocketErrorCode == SocketError.ConnectionReset) {
                    EndConnection();
                    return ">>> Server is unavailable. Disconnecting <<<";
                }
            }

            if (received == 0) {
                return null;
            }

            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = System.Text.Encoding.ASCII.GetString(data);
            return text;
        }

        public void ConnectToServer() {
            ClientConnect();
        }
		#endregion Public Methods

		#region Private Methods
		private void ClientConnect() {
            try {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.BeginConnect(new System.Net.IPEndPoint(IPAddress, Port), new AsyncCallback(ConnectCallback), null);
            }
            catch (Exception ex){ }
		}

		private void SendCallback(IAsyncResult Args) {
			try {
				ClientSocket.EndSend(Args);
			}
			catch (SocketException se) {
				if (se.SocketErrorCode == SocketError.ConnectionReset){
                    throw;
				}
			}
		}

		private void ConnectCallback(IAsyncResult Args) {
			try {
				ClientSocket.EndConnect(Args);
			}
			catch (SocketException se) {
                if (se.SocketErrorCode == SocketError.ConnectionRefused) {
                    ClientSocket.BeginConnect(new System.Net.IPEndPoint(IPAddress, Port), new AsyncCallback(ConnectCallback), null);
                }
                else { 
                    throw;
                }
			}
		}
		#endregion Private Methods
	}
}
