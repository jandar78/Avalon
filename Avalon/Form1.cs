using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySockets;
using System.Threading;

namespace Avalon {
    public partial class ServerForm : Form {
        private Server _server;
        private int Port { get; set; }
        private string IpAddress { get; set; }
        public bool StartGame {get; private set;}
        private Server Server {
            get {
                if (_server == null) {
                    _server = Server.GetServer(this);
                }

                return _server;
            }
        }

        public ServerForm() {
            InitializeComponent();
            nonCustomValue.Checked = true;
            StartGame = false;
            ThreadPool.QueueUserWorkItem(delegate { });
        }

        private void ipValue_Leave(object sender, EventArgs e) {
            IpAddress = ipValue.Text;
        }

        private void portValue_Leave(object sender, EventArgs e) {
            Port = int.Parse(portValue.Text);
        }

        private void startServer_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(IpAddress) && Port <= 0) {
                MessageBox.Show("No valid IP address and or Port specified for the server!.", "Unable to Start Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                Server.IPAddress = IpAddress;
                Server.Port = Port;
                LogIt("Starting up server");
                try {
                    Server.StartServer();
                    LogIt("Waiting for incoming connections...");
                }
                catch (Exception) {
                    LogIt("Failed to initialize server");
                }
            }
        }

        private void stopServer_Click(object sender, EventArgs e) {
            Server.ShutdownServer();
        }

        private void nonCustomValue_CheckedChanged(object sender, EventArgs e) {
            if (nonCustomValue.Checked) {
                customValue.Checked = !nonCustomValue.Checked;
                withOberon.Enabled = customValue.Checked;
                withMorgana.Enabled = customValue.Checked;
                withMerlin.Enabled = customValue.Checked;
                withMordred.Enabled = customValue.Checked;
                withPercival.Enabled = customValue.Checked;
                withAssassin.Enabled = customValue.Checked;
            }
            else {
                customValue_CheckedChanged(null, null);
            }
        }

        private void customValue_CheckedChanged(object sender, EventArgs e) {
            if (customValue.Checked) {
                nonCustomValue.Checked = !customValue.Checked;
                withOberon.Enabled = customValue.Checked;
                withMorgana.Enabled = customValue.Checked;
                withMerlin.Enabled = customValue.Checked;
                withMordred.Enabled = customValue.Checked;
                withPercival.Enabled = customValue.Checked;
                withAssassin.Enabled = customValue.Checked;
            }
        }

        public void LogIt(string message) {
            this.Invoke((MethodInvoker)delegate {
                logValue.Items.Add(message);
            });
        }

        private void startGame_Click(object sender, EventArgs e) {
            Server.PurgeUserList();
            if (Server.GetCurrentUserList().Count.ToString() == playerNumberValue.Text) {
                StartGame = true;
            }
            else {
                MessageBox.Show("You do not have the required number of players to play", "You Are Wrong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void playerNumberValue_Leave(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(playerNumberValue.Text.Trim())){
                playerNumberValue.Text = "1";
            }
        }

        private void stopGame_Click(object sender, EventArgs e) {
            StartGame = false;
        }
    }

    
    
}
