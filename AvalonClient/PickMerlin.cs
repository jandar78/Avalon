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
    public partial class PickMerlin : Form {
        public PickMerlin(List<string> playerNames) {
            InitializeComponent();
            
            foreach (string name in playerNames) {
                playerListValue.Items.Add(Name);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (playerListValue.SelectedIndex != -1) {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else {
                MessageBox.Show("You must pick someone a player", "Pick your target", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
