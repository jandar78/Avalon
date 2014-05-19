using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvalonClient {
    public partial class PickTeam : Form {
        private int RequiredPlayers { get; set; }
        public List<string> PlayersGoingOnMission;
        private int RemainingSlots { get; set; }
        public bool Finished { get; private set; }

        public PickTeam(int requiredPlayers, List<Players> players) {
            InitializeComponent();
            RemainingSlots = RequiredPlayers = requiredPlayers;
            PlayersGoingOnMission = new List<string>();
            foreach(Players player in players){
                availablePlayers.Items.Add(player.Name);
            }
            remainingSlotsValue.Text = RemainingSlots.ToString();
            Finished = false;
        }

        private void missionPlayers_Click(object sender, EventArgs e) {
            if (missionPlayers.SelectedIndex != -1) {
                availablePlayers.Items.Add(missionPlayers.Items[missionPlayers.SelectedIndex]);
                missionPlayers.Items.Remove(missionPlayers.Items[missionPlayers.SelectedIndex]);
                RemainingSlots++;
                remainingSlotsValue.Text = RemainingSlots.ToString();
            }
        }

        private void availablePlayers_Click(object sender, EventArgs e) {
            if (availablePlayers.SelectedIndex != -1) {
                missionPlayers.Items.Add(availablePlayers.Items[availablePlayers.SelectedIndex]);
                availablePlayers.Items.Remove(availablePlayers.Items[availablePlayers.SelectedIndex]);
                RemainingSlots--;
                remainingSlotsValue.Text = RemainingSlots.ToString();
            }
        }

        private void sendTeam_Click(object sender, EventArgs e) {
            if (missionPlayers.Items.Count != RequiredPlayers) {
                MessageBox.Show("You either selected to many or too few players to go on this mission.", "No no no", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                foreach (string name in missionPlayers.Items) {
                    PlayersGoingOnMission.Add(name);
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Finished = true;
            }
        }
    }
}
