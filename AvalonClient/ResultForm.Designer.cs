namespace AvalonClient {
    partial class ResultForm {
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
            this.failVote1 = new System.Windows.Forms.PictureBox();
            this.failVote2 = new System.Windows.Forms.PictureBox();
            this.failVote3 = new System.Windows.Forms.PictureBox();
            this.failVote4 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.failVote1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.failVote2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.failVote3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.failVote4)).BeginInit();
            this.SuspendLayout();
            // 
            // messageValue
            // 
            this.messageValue.BackColor = System.Drawing.Color.Transparent;
            this.messageValue.Font = new System.Drawing.Font("Times New Roman", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageValue.ForeColor = System.Drawing.Color.DarkRed;
            this.messageValue.Location = new System.Drawing.Point(151, 26);
            this.messageValue.Name = "messageValue";
            this.messageValue.Size = new System.Drawing.Size(339, 65);
            this.messageValue.TabIndex = 1;
            this.messageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // failVote1
            // 
            this.failVote1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.failVote1.BackColor = System.Drawing.Color.Transparent;
            this.failVote1.BackgroundImage = global::AvalonClient.Properties.Resources.Broken_Shield;
            this.failVote1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.failVote1.Location = new System.Drawing.Point(115, 146);
            this.failVote1.Name = "failVote1";
            this.failVote1.Size = new System.Drawing.Size(54, 49);
            this.failVote1.TabIndex = 2;
            this.failVote1.TabStop = false;
            this.failVote1.Visible = false;
            // 
            // failVote2
            // 
            this.failVote2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.failVote2.BackColor = System.Drawing.Color.Transparent;
            this.failVote2.BackgroundImage = global::AvalonClient.Properties.Resources.Broken_Shield;
            this.failVote2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.failVote2.Location = new System.Drawing.Point(232, 146);
            this.failVote2.Name = "failVote2";
            this.failVote2.Size = new System.Drawing.Size(54, 49);
            this.failVote2.TabIndex = 3;
            this.failVote2.TabStop = false;
            this.failVote2.Visible = false;
            // 
            // failVote3
            // 
            this.failVote3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.failVote3.BackColor = System.Drawing.Color.Transparent;
            this.failVote3.BackgroundImage = global::AvalonClient.Properties.Resources.Broken_Shield;
            this.failVote3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.failVote3.Location = new System.Drawing.Point(345, 146);
            this.failVote3.Name = "failVote3";
            this.failVote3.Size = new System.Drawing.Size(54, 49);
            this.failVote3.TabIndex = 4;
            this.failVote3.TabStop = false;
            this.failVote3.Visible = false;
            // 
            // failVote4
            // 
            this.failVote4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.failVote4.BackColor = System.Drawing.Color.Transparent;
            this.failVote4.BackgroundImage = global::AvalonClient.Properties.Resources.Broken_Shield;
            this.failVote4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.failVote4.Location = new System.Drawing.Point(462, 146);
            this.failVote4.Name = "failVote4";
            this.failVote4.Size = new System.Drawing.Size(54, 49);
            this.failVote4.TabIndex = 5;
            this.failVote4.TabStop = false;
            this.failVote4.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Double Click to Close";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AvalonClient.Properties.Resources.Success;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(626, 207);
            this.Controls.Add(this.failVote4);
            this.Controls.Add(this.failVote3);
            this.Controls.Add(this.failVote2);
            this.Controls.Add(this.failVote1);
            this.Controls.Add(this.messageValue);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mission Vote Outcome";
            this.toolTip1.SetToolTip(this, "Double Click to close. Red shields represent number of failed votes.");
            this.TopMost = true;
            this.DoubleClick += new System.EventHandler(this.ResultForm_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.failVote1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.failVote2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.failVote3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.failVote4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label messageValue;
        private System.Windows.Forms.PictureBox failVote1;
        private System.Windows.Forms.PictureBox failVote2;
        private System.Windows.Forms.PictureBox failVote3;
        private System.Windows.Forms.PictureBox failVote4;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}