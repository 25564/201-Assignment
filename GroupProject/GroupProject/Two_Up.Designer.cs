﻿namespace GroupProject {
    partial class Two_Up {
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ThrowCoinsBtn = new System.Windows.Forms.Button();
            this.PlayAgainBtn = new System.Windows.Forms.Button();
            this.CancelGameBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerScore = new System.Windows.Forms.Label();
            this.ComputerScore = new System.Windows.Forms.Label();
            this.ResultLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(54, 98);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 231);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(494, 98);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(225, 231);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // ThrowCoinsBtn
            // 
            this.ThrowCoinsBtn.Location = new System.Drawing.Point(51, 455);
            this.ThrowCoinsBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ThrowCoinsBtn.Name = "ThrowCoinsBtn";
            this.ThrowCoinsBtn.Size = new System.Drawing.Size(177, 35);
            this.ThrowCoinsBtn.TabIndex = 2;
            this.ThrowCoinsBtn.Text = "Throw Coins";
            this.ThrowCoinsBtn.UseVisualStyleBackColor = true;
            this.ThrowCoinsBtn.Click += new System.EventHandler(this.ThrowCoinsBtn_Click);
            // 
            // PlayAgainBtn
            // 
            this.PlayAgainBtn.Location = new System.Drawing.Point(322, 455);
            this.PlayAgainBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PlayAgainBtn.Name = "PlayAgainBtn";
            this.PlayAgainBtn.Size = new System.Drawing.Size(177, 35);
            this.PlayAgainBtn.TabIndex = 3;
            this.PlayAgainBtn.Text = "Play Again";
            this.PlayAgainBtn.UseVisualStyleBackColor = true;
            this.PlayAgainBtn.Visible = false;
            this.PlayAgainBtn.Click += new System.EventHandler(this.PlayAgainBtn_Click);
            // 
            // CancelGameBtn
            // 
            this.CancelGameBtn.Location = new System.Drawing.Point(598, 455);
            this.CancelGameBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelGameBtn.Name = "CancelGameBtn";
            this.CancelGameBtn.Size = new System.Drawing.Size(177, 35);
            this.CancelGameBtn.TabIndex = 4;
            this.CancelGameBtn.Text = "Cancel Game";
            this.CancelGameBtn.UseVisualStyleBackColor = true;
            this.CancelGameBtn.Click += new System.EventHandler(this.CancelGameBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 371);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Player\'s Score:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 371);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Computer\'s Score:";
            // 
            // PlayerScore
            // 
            this.PlayerScore.AutoSize = true;
            this.PlayerScore.BackColor = System.Drawing.Color.White;
            this.PlayerScore.Location = new System.Drawing.Point(178, 371);
            this.PlayerScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PlayerScore.Name = "PlayerScore";
            this.PlayerScore.Size = new System.Drawing.Size(18, 20);
            this.PlayerScore.TabIndex = 7;
            this.PlayerScore.Text = "0";
            // 
            // ComputerScore
            // 
            this.ComputerScore.AutoSize = true;
            this.ComputerScore.BackColor = System.Drawing.Color.White;
            this.ComputerScore.Location = new System.Drawing.Point(638, 371);
            this.ComputerScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ComputerScore.Name = "ComputerScore";
            this.ComputerScore.Size = new System.Drawing.Size(18, 20);
            this.ComputerScore.TabIndex = 8;
            this.ComputerScore.Text = "0";
            // 
            // ResultLbl
            // 
            this.ResultLbl.AutoSize = true;
            this.ResultLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultLbl.Location = new System.Drawing.Point(820, 180);
            this.ResultLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ResultLbl.Name = "ResultLbl";
            this.ResultLbl.Size = new System.Drawing.Size(93, 33);
            this.ResultLbl.TabIndex = 9;
            this.ResultLbl.Text = "label3";
            this.ResultLbl.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Two_Up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 574);
            this.Controls.Add(this.ResultLbl);
            this.Controls.Add(this.ComputerScore);
            this.Controls.Add(this.PlayerScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelGameBtn);
            this.Controls.Add(this.PlayAgainBtn);
            this.Controls.Add(this.ThrowCoinsBtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Two_Up";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Two_Up";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button ThrowCoinsBtn;
        private System.Windows.Forms.Button PlayAgainBtn;
        private System.Windows.Forms.Button CancelGameBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PlayerScore;
        private System.Windows.Forms.Label ComputerScore;
        private System.Windows.Forms.Label ResultLbl;
        private System.Windows.Forms.Timer timer1;
    }
}