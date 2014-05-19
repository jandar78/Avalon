using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Avalon;
using System.Threading;

namespace MySockets
{
	public class Server {

		#region Public Properties
		public string IPAddress {
			get {
				return _ipAddress.ToString();
			}
		   set {
				System.Net.IPAddress.TryParse(value, out _ipAddress);
			}
		}

		public int Port {
			get;
			set;
		}

		private Socket ServerSocket {
			get {
				return _serverSocket;
			}
		 set {
				_serverSocket = value;
			}
		}

		private byte[] ReceiveBuffer {
			get {
				return _receiveBuffer;
			}
			set {
				_receiveBuffer = value;
			}
		}

		private byte[] SendBuffer {
			get {
				return _sendBuffer;
			}
			set {
				_sendBuffer = value;
			}
		}

        private ServerForm ServerForm {
            get {
                return _serverForm;
            }
            set {
                _serverForm = value;
            }
        }
		#endregion Public Properties

		#region Private members
		private System.Net.IPAddress _ipAddress;
		private static ConcurrentDictionary<Socket, Players> clientSocketList;
		private Socket _serverSocket;
		private byte[] _receiveBuffer, _sendBuffer;
	    private static Server _server = null;
        private static ServerForm _serverForm;
		#endregion Private Members

		#region Constructors
		//Main constructor
        private Server(string address, int port, ServerForm serverForm) {			
			this.IPAddress = address;
			this.Port = System.Net.IPAddress.HostToNetworkOrder(port);
			ReceiveBuffer = new byte[1024];
			clientSocketList = new ConcurrentDictionary<Socket, Players>();
			_serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            ServerForm = serverForm;
		}
		#endregion Constructors

		#region Public Methods
		public static Server GetServer(ServerForm form) {
			return _server ?? (_server = new Server("192.168.1.1", 8814, form));
		}

        public static List<Players> GetCurrentUserList() {
            List<Players> userList = new List<Players>();
            Dictionary<Socket, Players> tempList = new Dictionary<Socket, Players>(clientSocketList); //this should prevent "Collection was modified" exception
            foreach (KeyValuePair<Socket, Players> user in tempList) {
				userList.Add(user.Value); 
			}

			return userList;
		}

		public static Players GetAUserPlusState(string id, States state = States.CONNECTED) {
            Dictionary<Socket, Players> tempList = new Dictionary<Socket, Players>(clientSocketList);
			return tempList.Where(c => c.Value.Name == id && c.Value.CurrentState == state).FirstOrDefault().Value;
		}

        public static Players GetAUser(string id) {
            Dictionary<Socket, Players> tempList = new Dictionary<Socket, Players>(clientSocketList);
			return tempList.Where(c => c.Value.Name == id).FirstOrDefault().Value;
		}

        public static Players GetAUserFromList(List<string> id) {
            if (id.Count > 0) {
                return GetAUser(id[0]);
            }

            return null;
        }

        public static void PurgeUserList(){
            foreach (KeyValuePair<Socket,Players> pair in clientSocketList) {
                try {
                    pair.Key.Send(System.Text.Encoding.ASCII.GetBytes(""));
                }
                catch (SocketException) {
                    _server.CloseThisConnection(pair);
                }
            }
        }

        public static List<Players> GetAUserByName(string name) {
            if (string.IsNullOrEmpty(name)) {
                return null;
            }
            Dictionary<Socket, Players> tempList = new Dictionary<Socket, Players>(clientSocketList);
            List<KeyValuePair<Socket, Players>> temp = tempList.Where(c => c.Value.Name.ToLower() == name.ToLower()).ToList();
            List<Players> result = new List<Players>();

            foreach (KeyValuePair<Socket, Players> user in temp) {
                result.Add(user.Value);
            }
            return result;
        }

		public void StartServer() {
			try {
                if (this.ServerSocket == null || !this.ServerSocket.IsBound) {
                    this.ServerSocket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(IPAddress), Port));
                }
				this.ServerSocket.Listen(1);
				this.ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
			}
            catch (ObjectDisposedException){
                this.ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                StartServer();
            }
			catch (SocketException se) {
				throw se;
			}
			catch (Exception ex) {
				throw ex; 
			}

		}

		public void ShutdownServer() {
			CloseAllConnections();
		}

		public void SendToAllClients(string message = null) {
			if (!string.IsNullOrEmpty(message)) {
				SendToAllClients(System.Text.Encoding.ASCII.GetBytes(message));
			}
			else {
				SendToAllClients(new byte[0]);
			}
		}

		public void SendToClients(States state, string message) {
			SendToClients(state, System.Text.Encoding.ASCII.GetBytes(message));
		}

		public void SendToClient(Socket socket, string message) {
			socket.Send(Encoding.ASCII.GetBytes(message));
			this.ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
		}
		#endregion Public Methods

		#region Private methods
		//this method is not responsible for checking a characters state, that is up to the method that calls this
		private void SendToClients(States state, byte[] message) {
			List<Socket> matchesState = clientSocketList.Where(s => s.Value.CurrentState == state).Select(s => s.Key).ToList();
			foreach (Socket client in matchesState) {
				client.Send(message);
			}
			this.ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
		}

        private void SendToAllClients(byte[] message = null) {
            if (clientSocketList.Count > 0) {
                Dictionary<Socket, Players> temp = new Dictionary<Socket, Players>(clientSocketList);
                foreach (KeyValuePair<Socket, Players> client in temp) {
                    Socket currentSocket = client.Key;
                    //let's get rid of any pending sockets that did not get removed from the clientSocketList
                    if (client.Value.CurrentState == States.DISCONNECT) {
                        CloseThisConnection(client);
                        continue;
                    }

                    //poll the socket to see if the user is still connected 

                    if ((currentSocket.Poll(1, SelectMode.SelectRead) && currentSocket.Available == 0) || !currentSocket.Connected || client.Value.CurrentState == States.LIMBO) {
                        //ok this guy disconnected we'll apply a time stamp and if it's been XX minutes since he was last disconnected
                        //then we'll save his character and drop this socket from the clientSocketList
                        if (client.Value.LastDisconnected == DateTime.MinValue) {
                            client.Value.LastDisconnected = DateTime.Now;
                            client.Value.CurrentState = States.LIMBO;
                        }
                        else {
                            TimeSpan idle = client.Value.LastDisconnected - DateTime.Now;
                            if (idle.Seconds < -10) { 
                                CloseThisConnection(client);
                                continue;
                            }
                        }
                    }

                    //this socket is still connected let's send a message 
                    if (currentSocket.Connected) {
                        try {
                            currentSocket.Send(message, 0, message.Length, SocketFlags.None);
                        }
                        catch (SocketException) {
                            //so somehow the previous polls didn't let us know the socket was closed but now we know for sure
                            client.Value.CurrentState = States.LIMBO;
                        }
                    }
                }
            }
        }

		private void AcceptCallback(IAsyncResult AR) {
            
			try {
				Socket socket = this.ServerSocket.EndAccept(AR);
                Players player = new Players();
                player.socket = socket;
                if (!clientSocketList.TryAdd(socket, player)) { //let's try to add to the dictionary and then try again
                    clientSocketList.TryAdd(socket, player);
				}
				ServerForm.LogIt("*** Client connected from IP: " + socket.RemoteEndPoint.ToString() + " ***");
				socket.BeginReceive(this.ReceiveBuffer, 0, this.ReceiveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
				this.ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
			}
			catch (Exception) {
				//just catch it and move on
			}
		}

		private void ReceiveCallback(IAsyncResult AR) {
			Socket socket = (Socket)AR.AsyncState;

			int received = 0;

			try {
				if (socket.Connected) {
					received = socket.EndReceive(AR);
				}
				else {
					CloseThisConnection(socket);
				}
			}
			catch (SocketException) {
				CloseThisConnection(socket);
				return;
			}
			catch (ObjectDisposedException) {
				//if it's been disposed then we are good to go continue on
				return;
			}

			if (received == 0) {
				return;
			}

			byte[] buffer = new byte[received];
			Array.Copy(ReceiveBuffer, buffer, received);

			clientSocketList[socket].InBuffer = System.Text.Encoding.ASCII.GetString(buffer);

			string temp = System.Text.Encoding.ASCII.GetString(buffer); //once you read it from the incoming buffer it's no longer there
			try {
				socket.BeginReceive(this.ReceiveBuffer, 0, this.ReceiveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
			}
			catch (SocketException se) {
				if (se.SocketErrorCode == SocketError.ConnectionReset) {
					CloseThisConnection(socket);
				}
			}
		}

		private void CloseThisConnection(Socket socket) {
			//serverLogger.Log("*** Client " + socket.RemoteEndPoint.ToString() + " disconnected. ***");
			if (clientSocketList.Count > 0) {
				if (clientSocketList.ContainsKey(socket)) {//we want to prevent silly exceptions
					clientSocketList[socket].CurrentState = States.NONE; //set it to none when exiting  
                    CloseThisConnection(new KeyValuePair<Socket, Players>(clientSocketList.Keys.Where(k => k == socket).Single(), clientSocketList[socket]));
				}
			}
		}

        private void CloseThisConnection(KeyValuePair<Socket, Players> socket) {
			try {
                Players user;
				ServerForm.LogIt("*** Client " + socket.Value.Name + " disconnected. ***");
				
				if (!clientSocketList.TryRemove(socket.Key, out user)) {
					user.CurrentState = States.DISCONNECT;
					return;
				}
				socket.Key.Close();
				socket.Key.Dispose();
			}
			catch (ObjectDisposedException) {
				//catch it and move on
			}
		}

		private void CloseAllConnections() {
            foreach (KeyValuePair<Socket, Players> socket in clientSocketList) {
				CloseThisConnection(socket);
			}

			clientSocketList.Clear();
			ServerForm.LogIt(">>>All connections closed<<<");
            _serverSocket.Close();
		}
		#endregion Private methods
	}


}
