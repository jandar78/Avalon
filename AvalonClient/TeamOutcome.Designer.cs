namespace AvalonClient {
    partial class TeamOutcome {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.messageValue = new System.Windows.Forms.Label();
            this.approvedList = new System.Windows.Forms.ListBox();
            this.rejectedList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // messageValue
            // 
            this.messageValue.BackColor = System.Drawing.Color.Transparent;
            this.messageValue.Font = new System.Drawing.Font("Palatino Linotype", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageValue.Location = new System.Drawing.Point(191, 68);
            this.messageValue.Name = "messageValue";
            this.messageValue.Size = new System.Drawing.Size(254, 73);
            this.messageValue.TabIndex = 0;
            this.messageValue.Text = "APPROVED";
            this.messageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // approvedList
            // 
            this.approvedList.FormattingEnabled = true;
            this.approvedList.Location = new System.Drawing.Point(12, 50);
            this.approvedList.Name = "approvedList";
            this.approvedList.Size = new System.Drawing.Size(129, 121);
            this.approvedList.TabIndex = 1;
            // 
            // rejectedList
            // 
            this.rejectedList.FormattingEnabled = true;
            this.rejectedList.Location = new System.Drawing.Point(499, 50);
            this.rejectedList.Name = "rejectedList";
            this.rejectedList.Size = new System.Drawing.Size(129, 121);
            this.rejectedList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Approved:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(496, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rejected:";
            // 
            // TeamOutcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AvalonClient.Properties.Resources.thumbs_UpDown;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(631, 206);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rejectedList);
            this.Controls.Add(this.approvedList);
            this.Controls.Add(this.messageValue);
            this.Name = "TeamOutcome";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Team Vote Outcome";
            this.toolTip1.SetToolTip(this, "Double Click  to Close");
            this.TopMost = true;
            this.DoubleClick += new System.EventHandler(this.TeamOutcome_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageValue;
        private System.Windows.Forms.ListBox approvedList;
        private System.Windows.Forms.ListBox rejectedList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}