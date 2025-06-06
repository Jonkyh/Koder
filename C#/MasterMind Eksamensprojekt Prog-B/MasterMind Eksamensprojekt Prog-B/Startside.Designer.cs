namespace MasterMind_Eksamensprojekt_Prog_B
{
    partial class Startside
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.BtnHowToPlay = new System.Windows.Forms.Button();
            this.btnContinueGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(193, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "MASTERMIND";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(265, 176);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(230, 78);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(265, 133);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 37);
            this.txtName.TabIndex = 3;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // BtnHowToPlay
            // 
            this.BtnHowToPlay.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnHowToPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHowToPlay.ForeColor = System.Drawing.Color.White;
            this.BtnHowToPlay.Location = new System.Drawing.Point(265, 344);
            this.BtnHowToPlay.Name = "BtnHowToPlay";
            this.BtnHowToPlay.Size = new System.Drawing.Size(230, 78);
            this.BtnHowToPlay.TabIndex = 4;
            this.BtnHowToPlay.Text = "How To Play?";
            this.BtnHowToPlay.UseVisualStyleBackColor = false;
            this.BtnHowToPlay.Click += new System.EventHandler(this.btnHowToPlay_Click);
            // 
            // btnContinueGame
            // 
            this.btnContinueGame.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnContinueGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinueGame.ForeColor = System.Drawing.Color.White;
            this.btnContinueGame.Location = new System.Drawing.Point(265, 260);
            this.btnContinueGame.Name = "btnContinueGame";
            this.btnContinueGame.Size = new System.Drawing.Size(230, 78);
            this.btnContinueGame.TabIndex = 5;
            this.btnContinueGame.Text = "Continue Game";
            this.btnContinueGame.UseVisualStyleBackColor = false;
            this.btnContinueGame.Click += new System.EventHandler(this.btnContinueGame_Click);
            // 
            // Startside
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnContinueGame);
            this.Controls.Add(this.BtnHowToPlay);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Name = "Startside";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button BtnHowToPlay;
        private System.Windows.Forms.Button btnContinueGame;
    }
}

