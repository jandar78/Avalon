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
    public partial class TeamVote : Form {

        public TeamVote(List<string> playersOnTeam) {
            InitializeComponent();
            foreach (string name in playersOnTeam) {
                playersGoingOnMission.Items.Add(name);
            }
        }

        private void rejectImage_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void approveImage_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void button1_Click(object sender, EventArgs e) {
            approveImage_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e) {
            rejectImage_Click(null, null);
        }
    }
}
