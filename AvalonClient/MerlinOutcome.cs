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
    public partial class MerlinOutcome : Form {
        public MerlinOutcome(bool killed) {
            InitializeComponent();
            if (killed) {
                BackgroundImage = global::AvalonClient.Properties.Resources.bloody_dagger;
                label1.Text = "KILLED";
            }
            else {
                BackgroundImage = global::AvalonClient.Properties.Resources.Merlin_Alive;
                label1.Text = "SURVIVED";
            }
        }
    }
}
