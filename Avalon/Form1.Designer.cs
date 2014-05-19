namespace Avalon {
    partial class ServerForm {
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
            this.ipValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portValue = new System.Windows.Forms.TextBox();
            this.startServer = new System.Windows.Forms.Button();
            this.stopServer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.playerNumberValue = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.withAssassin = new System.Windows.Forms.CheckBox();
            this.nonCustomValue = new System.Windows.Forms.RadioButton();
            this.customValue = new System.Windows.Forms.RadioButton();
            this.withMerlin = new System.Windows.Forms.CheckBox();
            this.withMorgana = new System.Windows.Forms.CheckBox();
            this.withMordred = new System.Windows.Forms.CheckBox();
            this.withOberon = new System.Windows.Forms.CheckBox();
            this.withPercival = new System.Windows.Forms.CheckBox();
            this.withLadyLake = new System.Windows.Forms.CheckBox();
            this.logValue = new System.Windows.Forms.ListBox();
            this.startGame = new System.Windows.Forms.Button();
            this.stopGame = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipValue
            // 
            this.ipValue.Location = new System.Drawing.Point(111, 23);
            this.ipValue.Name = "ipValue";
            this.ipValue.Size = new System.Drawing.Size(131, 20);
            this.ipValue.TabIndex = 0;
            this.ipValue.Text = "192.168.1.115";
            this.ipValue.Leave += new System.EventHandler(this.ipValue_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // portValue
            // 
            this.portValue.Location = new System.Drawing.Point(283, 23);
            this.portValue.Name = "portValue";
            this.portValue.Size = new System.Drawing.Size(47, 20);
            this.portValue.TabIndex = 2;
            this.portValue.Text = "1301";
            this.portValue.Leave += new System.EventHandler(this.portValue_Leave);
            // 
            // startServer
            // 
            this.startServer.Location = new System.Drawing.Point(352, 21);
            this.startServer.Name = "startServer";
            this.startServer.Size = new System.Drawing.Size(39, 23);
            this.startServer.TabIndex = 4;
            this.startServer.Text = "Start";
            this.startServer.UseVisualStyleBackColor = true;
            this.startServer.Click += new System.EventHandler(this.startServer_Click);
            // 
            // stopServer
            // 
            this.stopServer.Location = new System.Drawing.Point(410, 21);
            this.stopServer.Name = "stopServer";
            this.stopServer.Size = new System.Drawing.Size(42, 23);
            this.stopServer.TabIndex = 5;
            this.stopServer.Text = "Stop";
            this.stopServer.UseVisualStyleBackColor = true;
            this.stopServer.Click += new System.EventHandler(this.stopServer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Players:";
            // 
            // playerNumberValue
            // 
            this.playerNumberValue.Location = new System.Drawing.Point(76, 70);
            this.playerNumberValue.Name = "playerNumberValue";
            this.playerNumberValue.Size = new System.Drawing.Size(47, 20);
            this.playerNumberValue.TabIndex = 7;
            this.playerNumberValue.Text = "5";
            this.playerNumberValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerNumberValue.Leave += new System.EventHandler(this.playerNumberValue_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.withAssassin);
            this.groupBox1.Controls.Add(this.nonCustomValue);
            this.groupBox1.Controls.Add(this.customValue);
            this.groupBox1.Controls.Add(this.withMerlin);
            this.groupBox1.Controls.Add(this.withMorgana);
            this.groupBox1.Controls.Add(this.withMordred);
            this.groupBox1.Controls.Add(this.withOberon);
            this.groupBox1.Controls.Add(this.withPercival);
            this.groupBox1.Location = new System.Drawing.Point(19, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 119);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Special Cards";
            // 
            // withAssassin
            // 
            this.withAssassin.AutoSize = true;
            this.withAssassin.Location = new System.Drawing.Point(81, 66);
            this.withAssassin.Name = "withAssassin";
            this.withAssassin.Size = new System.Drawing.Size(67, 17);
            this.withAssassin.TabIndex = 8;
            this.withAssassin.Text = "Assassin";
            this.withAssassin.UseVisualStyleBackColor = true;
            // 
            // nonCustomValue
            // 
            this.nonCustomValue.AutoSize = true;
            this.nonCustomValue.Location = new System.Drawing.Point(81, 96);
            this.nonCustomValue.Name = "nonCustomValue";
            this.nonCustomValue.Size = new System.Drawing.Size(107, 17);
            this.nonCustomValue.TabIndex = 7;
            this.nonCustomValue.TabStop = true;
            this.nonCustomValue.Text = "Based on Players";
            this.nonCustomValue.UseVisualStyleBackColor = true;
            this.nonCustomValue.CheckedChanged += new System.EventHandler(this.nonCustomValue_CheckedChanged);
            // 
            // customValue
            // 
            this.customValue.AutoSize = true;
            this.customValue.Location = new System.Drawing.Point(7, 96);
            this.customValue.Name = "customValue";
            this.customValue.Size = new System.Drawing.Size(60, 17);
            this.customValue.TabIndex = 6;
            this.customValue.TabStop = true;
            this.customValue.Text = "Custom";
            this.customValue.UseVisualStyleBackColor = true;
            this.customValue.CheckedChanged += new System.EventHandler(this.customValue_CheckedChanged);
            // 
            // withMerlin
            // 
            this.withMerlin.AutoSize = true;
            this.withMerlin.Location = new System.Drawing.Point(7, 43);
            this.withMerlin.Name = "withMerlin";
            this.withMerlin.Size = new System.Drawing.Size(54, 17);
            this.withMerlin.TabIndex = 4;
            this.withMerlin.Text = "Merlin";
            this.withMerlin.UseVisualStyleBackColor = true;
            // 
            // withMorgana
            // 
            this.withMorgana.AutoSize = true;
            this.withMorgana.Location = new System.Drawing.Point(81, 19);
            this.withMorgana.Name = "withMorgana";
            this.withMorgana.Size = new System.Drawing.Size(68, 17);
            this.withMorgana.TabIndex = 3;
            this.withMorgana.Text = "Morgana";
            this.withMorgana.UseVisualStyleBackColor = true;
            // 
            // withMordred
            // 
            this.withMordred.AutoSize = true;
            this.withMordred.Location = new System.Drawing.Point(7, 66);
            this.withMordred.Name = "withMordred";
            this.withMordred.Size = new System.Drawing.Size(65, 17);
            this.withMordred.TabIndex = 2;
            this.withMordred.Text = "Mordred";
            this.withMordred.UseVisualStyleBackColor = true;
            // 
            // withOberon
            // 
            this.withOberon.AutoSize = true;
            this.withOberon.Location = new System.Drawing.Point(81, 43);
            this.withOberon.Name = "withOberon";
            this.withOberon.Size = new System.Drawing.Size(61, 17);
            this.withOberon.TabIndex = 1;
            this.withOberon.Text = "Oberon";
            this.withOberon.UseVisualStyleBackColor = true;
            // 
            // withPercival
            // 
            this.withPercival.AutoSize = true;
            this.withPercival.Location = new System.Drawing.Point(7, 20);
            this.withPercival.Name = "withPercival";
            this.withPercival.Size = new System.Drawing.Size(64, 17);
            this.withPercival.TabIndex = 0;
            this.withPercival.Text = "Percival";
            this.withPercival.UseVisualStyleBackColor = true;
            // 
            // withLadyLake
            // 
            this.withLadyLake.AutoSize = true;
            this.withLadyLake.Location = new System.Drawing.Point(138, 72);
            this.withLadyLake.Name = "withLadyLake";
            this.withLadyLake.Size = new System.Drawing.Size(106, 17);
            this.withLadyLake.TabIndex = 5;
            this.withLadyLake.Text = "Lady of the Lake";
            this.withLadyLake.UseVisualStyleBackColor = true;
            // 
            // logValue
            // 
            this.logValue.FormattingEnabled = true;
            this.logValue.Location = new System.Drawing.Point(251, 63);
            this.logValue.Name = "logValue";
            this.logValue.Size = new System.Drawing.Size(306, 160);
            this.logValue.TabIndex = 9;
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(194, 242);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(69, 23);
            this.startGame.TabIndex = 11;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // stopGame
            // 
            this.stopGame.Location = new System.Drawing.Point(342, 242);
            this.stopGame.Name = "stopGame";
            this.stopGame.Size = new System.Drawing.Size(69, 23);
            this.stopGame.TabIndex = 12;
            this.stopGame.Text = "Stop Game";
            this.stopGame.UseVisualStyleBackColor = true;
            this.stopGame.Click += new System.EventHandler(this.stopGame_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 290);
            this.Controls.Add(this.stopGame);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.logValue);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.playerNumberValue);
            this.Controls.Add(this.withLadyLake);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stopServer);
            this.Controls.Add(this.startServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipValue);
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avalon Server 0.3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portValue;
        private System.Windows.Forms.Button startServer;
        private System.Windows.Forms.Button stopServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox playerNumberValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton nonCustomValue;
        private System.Windows.Forms.RadioButton customValue;
        private System.Windows.Forms.CheckBox withLadyLake;
        private System.Windows.Forms.CheckBox withMerlin;
        private System.Windows.Forms.CheckBox withMorgana;
        private System.Windows.Forms.CheckBox withMordred;
        private System.Windows.Forms.CheckBox withOberon;
        private System.Windows.Forms.CheckBox withPercival;
        private System.Windows.Forms.CheckBox withAssassin;
        private System.Windows.Forms.ListBox logValue;
        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.Button stopGame;
    }
}

