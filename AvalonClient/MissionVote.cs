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
    public partial class MissionVote : Form {
        public MissionVote(PlayingCards role) {
            InitializeComponent();
            if (role == PlayingCards.MERLIN || role == PlayingCards.PERCIVAL || role == PlayingCards.SERVANT_OF_ARTHUR) {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
