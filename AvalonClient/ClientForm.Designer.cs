namespace AvalonClient {
    partial class ClientForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.stepLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ipValue = new System.Windows.Forms.TextBox();
            this.portValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nameValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.playersPlayingValue = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cardValue = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rolePicture = new System.Windows.Forms.PictureBox();
            this.roundsPanel = new System.Windows.Forms.Panel();
            this.vote5 = new System.Windows.Forms.PictureBox();
            this.vote4 = new System.Windows.Forms.PictureBox();
            this.vote3 = new System.Windows.Forms.PictureBox();
            this.vote2 = new System.Windows.Forms.PictureBox();
            this.vote1 = new System.Windows.Forms.PictureBox();
            this.mission5 = new System.Windows.Forms.PictureBox();
            this.mission4 = new System.Windows.Forms.PictureBox();
            this.mission3 = new System.Windows.Forms.PictureBox();
            this.mission2 = new System.Windows.Forms.PictureBox();
            this.mission1 = new System.Windows.Forms.PictureBox();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.playersPanel = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rolePicture)).BeginInit();
            this.roundsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vote5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vote4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vote3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vote2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vote1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mission5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mission4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mission3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mission2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mission1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusValue,
            this.stepLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 704);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1139, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.toolTip1.SetToolTip(this.statusStrip1, "Connection to the server");
            // 
            // statusValue
            // 
            this.statusValue.Name = "statusValue";
            this.statusValue.Size = new System.Drawing.Size(0, 17);
            // 
            // stepLabel
            // 
            this.stepLabel.ActiveLinkColor = System.Drawing.Color.Black;
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stepLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ipValue
            // 
            this.ipValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipValue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ipValue.Location = new System.Drawing.Point(450, 598);
            this.ipValue.Name = "ipValue";
            this.ipValue.Size = new System.Drawing.Size(100, 20);
            this.ipValue.TabIndex = 5;
            this.ipValue.Text = "192.168.1.115";
            this.toolTip1.SetToolTip(this.ipValue, "Server IP address");
            // 
            // portValue
            // 
            this.portValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portValue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.portValue.Location = new System.Drawing.Point(450, 624);
            this.portValue.Name = "portValue";
            this.portValue.Size = new System.Drawing.Size(100, 20);
            this.portValue.TabIndex = 6;
            this.portValue.Text = "1301";
            this.toolTip1.SetToolTip(this.portValue, "Server port number");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(409, 627);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(371, 601);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "IP Address";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(533, 665);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameValue
            // 
            this.nameValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameValue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.nameValue.Location = new System.Drawing.Point(570, 624);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(218, 20);
            this.nameValue.TabIndex = 11;
            this.nameValue.Text = "Derp";
            this.toolTip1.SetToolTip(this.nameValue, "Enter the name you wish others to see you by");
            this.nameValue.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(570, 601);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Name";
            // 
            // playersPlayingValue
            // 
            this.playersPlayingValue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.playersPlayingValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playersPlayingValue.FormattingEnabled = true;
            this.playersPlayingValue.Location = new System.Drawing.Point(946, 295);
            this.playersPlayingValue.Name = "playersPlayingValue";
            this.playersPlayingValue.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.playersPlayingValue.Size = new System.Drawing.Size(176, 236);
            this.playersPlayingValue.TabIndex = 13;
            this.toolTip1.SetToolTip(this.playersPlayingValue, "Names of players currently in the game.");
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Role:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(943, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Players In Game:";
            // 
            // cardValue
            // 
            this.cardValue.AutoSize = true;
            this.cardValue.BackColor = System.Drawing.Color.Transparent;
            this.cardValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardValue.ForeColor = System.Drawing.Color.White;
            this.cardValue.Location = new System.Drawing.Point(12, 545);
            this.cardValue.Name = "cardValue";
            this.cardValue.Size = new System.Drawing.Size(198, 39);
            this.cardValue.TabIndex = 17;
            this.cardValue.Text = "UNKNOWN";
            this.cardValue.Visible = false;
            // 
            // rolePicture
            // 
            this.rolePicture.Image = global::AvalonClient.Properties.Resources.card_back;
            this.rolePicture.Location = new System.Drawing.Point(26, 286);
            this.rolePicture.Name = "rolePicture";
            this.rolePicture.Size = new System.Drawing.Size(176, 245);
            this.rolePicture.TabIndex = 16;
            this.rolePicture.TabStop = false;
            this.toolTip1.SetToolTip(this.rolePicture, "Hover to see card, click to see others players based on ability");
            this.rolePicture.Click += new System.EventHandler(this.rolePicture_Click);
            this.rolePicture.MouseLeave += new System.EventHandler(this.rolePicture_MouseLeave);
            this.rolePicture.MouseHover += new System.EventHandler(this.rolePicture_MouseHover);
            // 
            // roundsPanel
            // 
            this.roundsPanel.BackColor = System.Drawing.Color.Transparent;
            this.roundsPanel.BackgroundImage = global::AvalonClient.Properties.Resources.BackDrop5;
            this.roundsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.roundsPanel.Controls.Add(this.vote5);
            this.roundsPanel.Controls.Add(this.vote4);
            this.roundsPanel.Controls.Add(this.vote3);
            this.roundsPanel.Controls.Add(this.vote2);
            this.roundsPanel.Controls.Add(this.vote1);
            this.roundsPanel.Controls.Add(this.mission5);
            this.roundsPanel.Controls.Add(this.mission4);
            this.roundsPanel.Controls.Add(this.mission3);
            this.roundsPanel.Controls.Add(this.mission2);
            this.roundsPanel.Controls.Add(this.mission1);
            this.roundsPanel.Location = new System.Drawing.Point(26, 13);
            this.roundsPanel.Name = "roundsPanel";
            this.roundsPanel.Size = new System.Drawing.Size(1096, 234);
            this.roundsPanel.TabIndex = 2;
            this.toolTip1.SetToolTip(this.roundsPanel, "Display current mission round and team vote round");
            // 
            // vote5
            // 
            this.vote5.Image = global::AvalonClient.Properties.Resources.Vote5;
            this.vote5.Location = new System.Drawing.Point(725, 152);
            this.vote5.Name = "vote5";
            this.vote5.Size = new System.Drawing.Size(65, 65);
            this.vote5.TabIndex = 15;
            this.vote5.TabStop = false;
            // 
            // vote4
            // 
            this.vote4.Image = global::AvalonClient.Properties.Resources.Vote4;
            this.vote4.Location = new System.Drawing.Point(603, 152);
            this.vote4.Name = "vote4";
            this.vote4.Size = new System.Drawing.Size(65, 65);
            this.vote4.TabIndex = 14;
            this.vote4.TabStop = false;
            // 
            // vote3
            // 
            this.vote3.Image = global::AvalonClient.Properties.Resources.Vote3;
            this.vote3.Location = new System.Drawing.Point(481, 152);
            this.vote3.Name = "vote3";
            this.vote3.Size = new System.Drawing.Size(65, 65);
            this.vote3.TabIndex = 13;
            this.vote3.TabStop = false;
            // 
            // vote2
            // 
            this.vote2.Image = global::AvalonClient.Properties.Resources.Vote2;
            this.vote2.Location = new System.Drawing.Point(356, 152);
            this.vote2.Name = "vote2";
            this.vote2.Size = new System.Drawing.Size(65, 65);
            this.vote2.TabIndex = 12;
            this.vote2.TabStop = false;
            // 
            // vote1
            // 
            this.vote1.Image = global::AvalonClient.Properties.Resources.Vote1;
            this.vote1.Location = new System.Drawing.Point(229, 152);
            this.vote1.Name = "vote1";
            this.vote1.Size = new System.Drawing.Size(65, 65);
            this.vote1.TabIndex = 11;
            this.vote1.TabStop = false;
            // 
            // mission5
            // 
            this.mission5.BackColor = System.Drawing.Color.Transparent;
            this.mission5.Image = global::AvalonClient.Properties.Resources.Round5;
            this.mission5.Location = new System.Drawing.Point(858, 13);
            this.mission5.Name = "mission5";
            this.mission5.Size = new System.Drawing.Size(125, 116);
            this.mission5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mission5.TabIndex = 10;
            this.mission5.TabStop = false;
            // 
            // mission4
            // 
            this.mission4.BackColor = System.Drawing.Color.Transparent;
            this.mission4.Image = global::AvalonClient.Properties.Resources.Round4;
            this.mission4.Location = new System.Drawing.Point(662, 13);
            this.mission4.Name = "mission4";
            this.mission4.Size = new System.Drawing.Size(125, 116);
            this.mission4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mission4.TabIndex = 9;
            this.mission4.TabStop = false;
            // 
            // mission3
            // 
            this.mission3.BackColor = System.Drawing.Color.Transparent;
            this.mission3.Image = global::AvalonClient.Properties.Resources.Round3;
            this.mission3.Location = new System.Drawing.Point(481, 13);
            this.mission3.Name = "mission3";
            this.mission3.Size = new System.Drawing.Size(125, 116);
            this.mission3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mission3.TabIndex = 8;
            this.mission3.TabStop = false;
            // 
            // mission2
            // 
            this.mission2.BackColor = System.Drawing.Color.Transparent;
            this.mission2.Image = global::AvalonClient.Properties.Resources.Round2;
            this.mission2.Location = new System.Drawing.Point(287, 13);
            this.mission2.Name = "mission2";
            this.mission2.Size = new System.Drawing.Size(125, 116);
            this.mission2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mission2.TabIndex = 7;
            this.mission2.TabStop = false;
            // 
            // mission1
            // 
            this.mission1.BackColor = System.Drawing.Color.Transparent;
            this.mission1.Image = global::AvalonClient.Properties.Resources.Round1;
            this.mission1.Location = new System.Drawing.Point(107, 13);
            this.mission1.Name = "mission1";
            this.mission1.Size = new System.Drawing.Size(125, 116);
            this.mission1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mission1.TabIndex = 6;
            this.mission1.TabStop = false;
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.Silver;
            this.infoPanel.BackgroundImage = global::AvalonClient.Properties.Resources.Excalibur;
            this.infoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoPanel.ForeColor = System.Drawing.Color.Silver;
            this.infoPanel.Location = new System.Drawing.Point(264, 272);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(638, 259);
            this.infoPanel.TabIndex = 18;
            this.toolTip1.SetToolTip(this.infoPanel, "Displays the current step in the game.");
            // 
            // playersPanel
            // 
            this.playersPanel.BackColor = System.Drawing.Color.Transparent;
            this.playersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playersPanel.Location = new System.Drawing.Point(0, 0);
            this.playersPanel.Name = "playersPanel";
            this.playersPanel.Size = new System.Drawing.Size(1139, 726);
            this.playersPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.playersPanel.TabIndex = 0;
            this.playersPanel.TabStop = false;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AvalonClient.Properties.Resources.BackDropMain;
            this.ClientSize = new System.Drawing.Size(1139, 726);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.cardValue);
            this.Controls.Add(this.rolePicture);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.playersPlayingValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameValue);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portValue);
            this.Controls.Add(this.ipValue);
            this.Controls.Add(this.roundsPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.playersPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1155, 800);
            this.MinimumSize = new System.Drawing.Size(1155, 731);
            this.Name = "ClientForm";
            this.Text = "Avalon 0.4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rolePicture)).EndInit();
            this.roundsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vote5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vote4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vote3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vote2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vote1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mission5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mission4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mission3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mission2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mission1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox playersPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel roundsPanel;
        private System.Windows.Forms.TextBox ipValue;
        private System.Windows.Forms.TextBox portValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nameValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox mission1;
        private System.Windows.Forms.ToolStripStatusLabel statusValue;
        private System.Windows.Forms.ListBox playersPlayingValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox rolePicture;
        private System.Windows.Forms.Label cardValue;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox mission5;
        private System.Windows.Forms.PictureBox mission4;
        private System.Windows.Forms.PictureBox mission3;
        private System.Windows.Forms.PictureBox mission2;
        private System.Windows.Forms.PictureBox vote1;
        private System.Windows.Forms.PictureBox vote5;
        private System.Windows.Forms.PictureBox vote4;
        private System.Windows.Forms.PictureBox vote3;
        private System.Windows.Forms.PictureBox vote2;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.ToolStripStatusLabel stepLabel;
    }
}