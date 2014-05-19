namespace AvalonClient {
    partial class TeamVote {
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
            this.rejectImage = new System.Windows.Forms.PictureBox();
            this.approveImage = new System.Windows.Forms.PictureBox();
            this.playersGoingOnMission = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rejectImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.approveImage)).BeginInit();
            this.SuspendLayout();
            // 
            // rejectImage
            // 
            this.rejectImage.BackgroundImage = global::AvalonClient.Properties.Resources.RejectTeam;
            this.rejectImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rejectImage.Location = new System.Drawing.Point(443, 3);
            this.rejectImage.Name = "rejectImage";
            this.rejectImage.Size = new System.Drawing.Size(150, 138);
            this.rejectImage.TabIndex = 1;
            this.rejectImage.TabStop = false;
            this.rejectImage.Click += new System.EventHandler(this.rejectImage_Click);
            // 
            // approveImage
            // 
            this.approveImage.BackgroundImage = global::AvalonClient.Properties.Resources.ApproveTeam;
            this.approveImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.approveImage.Location = new System.Drawing.Point(21, 3);
            this.approveImage.Name = "approveImage";
            this.approveImage.Size = new System.Drawing.Size(150, 138);
            this.approveImage.TabIndex = 0;
            this.approveImage.TabStop = false;
            this.approveImage.Click += new System.EventHandler(this.approveImage_Click);
            // 
            // playersGoingOnMission
            // 
            this.playersGoingOnMission.BackColor = System.Drawing.Color.Silver;
            this.playersGoingOnMission.FormattingEnabled = true;
            this.playersGoingOnMission.Location = new System.Drawing.Point(232, 12);
            this.playersGoingOnMission.Name = "playersGoingOnMission";
            this.playersGoingOnMission.Size = new System.Drawing.Size(164, 134);
            this.playersGoingOnMission.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(762, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Players chosen to go on Mission";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(21, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "APPROVE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(443, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "REJECT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TeamVote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(614, 227);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playersGoingOnMission);
            this.Controls.Add(this.rejectImage);
            this.Controls.Add(this.approveImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeamVote";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Approve Team for Mission";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.rejectImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.approveImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox approveImage;
        private System.Windows.Forms.PictureBox rejectImage;
        private System.Windows.Forms.ListBox playersGoingOnMission;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}