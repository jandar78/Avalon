namespace AvalonClient {
    partial class PickTeam {
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
            this.availablePlayers = new System.Windows.Forms.ListBox();
            this.missionPlayers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sendTeam = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.remainingSlotsValue = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // availablePlayers
            // 
            this.availablePlayers.FormattingEnabled = true;
            this.availablePlayers.Location = new System.Drawing.Point(12, 31);
            this.availablePlayers.Name = "availablePlayers";
            this.availablePlayers.Size = new System.Drawing.Size(156, 160);
            this.availablePlayers.TabIndex = 0;
            this.availablePlayers.Click += new System.EventHandler(this.availablePlayers_Click);
            // 
            // missionPlayers
            // 
            this.missionPlayers.FormattingEnabled = true;
            this.missionPlayers.Location = new System.Drawing.Point(455, 31);
            this.missionPlayers.Name = "missionPlayers";
            this.missionPlayers.Size = new System.Drawing.Size(164, 160);
            this.missionPlayers.TabIndex = 1;
            this.missionPlayers.Click += new System.EventHandler(this.missionPlayers_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available Players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(428, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Players Chosen to go on Mission";
            // 
            // sendTeam
            // 
            this.sendTeam.Location = new System.Drawing.Point(287, 168);
            this.sendTeam.Name = "sendTeam";
            this.sendTeam.Size = new System.Drawing.Size(75, 23);
            this.sendTeam.TabIndex = 4;
            this.sendTeam.Text = "Send Team";
            this.sendTeam.UseVisualStyleBackColor = false;
            this.sendTeam.Click += new System.EventHandler(this.sendTeam_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(473, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Remaining Slots:";
            // 
            // remainingSlotsValue
            // 
            this.remainingSlotsValue.AutoSize = true;
            this.remainingSlotsValue.BackColor = System.Drawing.Color.Transparent;
            this.remainingSlotsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingSlotsValue.ForeColor = System.Drawing.Color.Black;
            this.remainingSlotsValue.Location = new System.Drawing.Point(581, 194);
            this.remainingSlotsValue.Name = "remainingSlotsValue";
            this.remainingSlotsValue.Size = new System.Drawing.Size(14, 13);
            this.remainingSlotsValue.TabIndex = 6;
            this.remainingSlotsValue.Text = "0";
            // 
            // PickTeam
            // 
            this.BackgroundImage = global::AvalonClient.Properties.Resources.Choose_Wisely;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(631, 225);
            this.Controls.Add(this.remainingSlotsValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sendTeam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.missionPlayers);
            this.Controls.Add(this.availablePlayers);
            this.Name = "PickTeam";
            this.toolTip1.SetToolTip(this, "Choose wisely...");
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox availablePlayers;
        private System.Windows.Forms.ListBox missionPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendTeam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label remainingSlotsValue;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}