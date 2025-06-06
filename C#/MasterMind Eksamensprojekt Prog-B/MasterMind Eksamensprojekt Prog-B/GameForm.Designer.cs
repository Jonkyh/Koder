namespace MasterMind_Eksamensprojekt_Prog_B
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblName1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOrange = new System.Windows.Forms.Button();
            this.btnYellow = new System.Windows.Forms.Button();
            this.btnPink = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.BtnRed = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.canvas1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtHighScore = new System.Windows.Forms.TextBox();
            this.btnSaveGame = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.BtnHowToPlay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName1.ForeColor = System.Drawing.Color.White;
            this.lblName1.Location = new System.Drawing.Point(12, 2);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(57, 20);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOrange);
            this.groupBox1.Controls.Add(this.btnYellow);
            this.groupBox1.Controls.Add(this.btnPink);
            this.groupBox1.Controls.Add(this.btnGreen);
            this.groupBox1.Controls.Add(this.btnBlue);
            this.groupBox1.Controls.Add(this.BtnRed);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(325, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 181);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors";
            this.groupBox1.Visible = false;
            // 
            // btnOrange
            // 
            this.btnOrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOrange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrange.ForeColor = System.Drawing.Color.Black;
            this.btnOrange.Location = new System.Drawing.Point(80, 130);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.Size = new System.Drawing.Size(67, 44);
            this.btnOrange.TabIndex = 10;
            this.btnOrange.Text = "Orange";
            this.btnOrange.UseVisualStyleBackColor = false;
            this.btnOrange.Click += new System.EventHandler(this.btnOrange_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYellow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYellow.ForeColor = System.Drawing.Color.Black;
            this.btnYellow.Location = new System.Drawing.Point(6, 130);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(67, 44);
            this.btnYellow.TabIndex = 9;
            this.btnYellow.Text = "Yellow";
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnPink
            // 
            this.btnPink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPink.ForeColor = System.Drawing.Color.Black;
            this.btnPink.Location = new System.Drawing.Point(80, 80);
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(67, 44);
            this.btnPink.TabIndex = 8;
            this.btnPink.Text = "Pink";
            this.btnPink.UseVisualStyleBackColor = false;
            this.btnPink.Click += new System.EventHandler(this.btnPink_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGreen.Location = new System.Drawing.Point(6, 80);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(67, 44);
            this.btnGreen.TabIndex = 7;
            this.btnGreen.Text = "Green";
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlue.ForeColor = System.Drawing.Color.White;
            this.btnBlue.Location = new System.Drawing.Point(80, 30);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(67, 44);
            this.btnBlue.TabIndex = 6;
            this.btnBlue.Text = "Blue";
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // BtnRed
            // 
            this.BtnRed.BackColor = System.Drawing.Color.Red;
            this.BtnRed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRed.ForeColor = System.Drawing.Color.White;
            this.BtnRed.Location = new System.Drawing.Point(6, 30);
            this.BtnRed.Name = "BtnRed";
            this.BtnRed.Size = new System.Drawing.Size(67, 44);
            this.BtnRed.TabIndex = 5;
            this.BtnRed.Text = "Red";
            this.BtnRed.UseVisualStyleBackColor = false;
            this.BtnRed.Click += new System.EventHandler(this.BtnRed_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.Color.White;
            this.btnCheck.Location = new System.Drawing.Point(325, 383);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(153, 66);
            this.btnCheck.TabIndex = 12;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // canvas1
            // 
            this.canvas1.Location = new System.Drawing.Point(6, 45);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(313, 604);
            this.canvas1.TabIndex = 16;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(325, 383);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(153, 237);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.ForeColor = System.Drawing.Color.White;
            this.btnUndo.Location = new System.Drawing.Point(325, 455);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(153, 50);
            this.btnUndo.TabIndex = 18;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(12, 22);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(51, 20);
            this.lblTime.TabIndex = 20;
            this.lblTime.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtHighScore
            // 
            this.txtHighScore.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.txtHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighScore.ForeColor = System.Drawing.Color.White;
            this.txtHighScore.Location = new System.Drawing.Point(331, 31);
            this.txtHighScore.Multiline = true;
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHighScore.Size = new System.Drawing.Size(147, 159);
            this.txtHighScore.TabIndex = 21;
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnSaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGame.ForeColor = System.Drawing.Color.White;
            this.btnSaveGame.Location = new System.Drawing.Point(325, 511);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(153, 50);
            this.btnSaveGame.TabIndex = 22;
            this.btnSaveGame.Text = "Save Game";
            this.btnSaveGame.UseVisualStyleBackColor = false;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(325, 567);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(153, 50);
            this.btnRestart.TabIndex = 23;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore.ForeColor = System.Drawing.Color.White;
            this.lblHighScore.Location = new System.Drawing.Point(344, 10);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(93, 20);
            this.lblHighScore.TabIndex = 24;
            this.lblHighScore.Text = "HighScore";
            // 
            // BtnHowToPlay
            // 
            this.BtnHowToPlay.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnHowToPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHowToPlay.ForeColor = System.Drawing.Color.White;
            this.BtnHowToPlay.Location = new System.Drawing.Point(405, 623);
            this.BtnHowToPlay.Name = "BtnHowToPlay";
            this.BtnHowToPlay.Size = new System.Drawing.Size(73, 35);
            this.BtnHowToPlay.TabIndex = 25;
            this.BtnHowToPlay.Text = "?";
            this.BtnHowToPlay.UseVisualStyleBackColor = false;
            this.BtnHowToPlay.Click += new System.EventHandler(this.BtnHowToPlay_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(325, 623);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 35);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.BtnHowToPlay);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveGame);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblName1);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Panel canvas1;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button BtnRed;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnOrange;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button btnPink;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtHighScore;
        private System.Windows.Forms.Button btnSaveGame;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblHighScore;
        private System.Windows.Forms.Button BtnHowToPlay;
        private System.Windows.Forms.Button btnExit;
    }
}