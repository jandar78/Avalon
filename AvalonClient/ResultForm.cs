using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AvalonClient {
    public partial class ResultForm : Form {
        private bool Result { get; set; }
        private int Failures { get; set; }

        public ResultForm(bool result, int failures) {
            InitializeComponent();
            Result = result;
            Failures = failures;

            if (Result) {
                this.BackgroundImage = global::AvalonClient.Properties.Resources.Success;
                messageValue.Text = "SUCCESS";
                messageValue.ForeColor = System.Drawing.Color.Green;
                DisplayFailureVotes();
            }
            else {
                this.BackgroundImage = global::AvalonClient.Properties.Resources.Failure;
                messageValue.Text = "FAILURE";
                messageValue.ForeColor = System.Drawing.Color.Red;
                DisplayFailureVotes();
            }
        }

        private void DisplayFailureVotes() {
            if (Failures >= 1) {
                failVote2.Visible = true;
            }
            if (Failures >= 2) {
                failVote3.Visible = true;
            }
            if (Failures >= 3) {
                failVote1.Visible = true;
            }
            if (Failures >= 4) {
                failVote4.Visible = true;
            }
        }

        private void ResultForm_DoubleClick(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
