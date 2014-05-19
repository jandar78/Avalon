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
    public partial class TeamOutcome : Form {
        private bool Result { get; set; }
        private List<string> Approved { get; set; }
        private List<string> Rejected { get; set; }

        public TeamOutcome(bool result, List<string> approved, List<string> rejected) {
            InitializeComponent();
            Result = result;
            Approved = approved;
            Rejected = rejected;

            foreach (string name in Approved) {
                approvedList.Items.Add(name);
            }
            foreach (string name in Rejected) {
                rejectedList.Items.Add(name);
            }

            if (Result) {
                messageValue.Text = "APPROVED";
                messageValue.ForeColor = System.Drawing.Color.Green;
            }
            else {
                messageValue.Text = "REJECTED";
                messageValue.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void TeamOutcome_DoubleClick(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
