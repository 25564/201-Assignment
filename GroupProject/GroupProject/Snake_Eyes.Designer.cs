namespace GroupProject {
    partial class Snake_Eyes {
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
            this.RollCount = new System.Windows.Forms.Label();
            this.RollDice = new System.Windows.Forms.Button();
            this.RollOutcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerScore = new System.Windows.Forms.Label();
            this.HouseScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ContinueGame = new System.Windows.Forms.Button();
            this.CancelGame = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(71, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(392, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // RollCount
            // 
            this.RollCount.AutoSize = true;
            this.RollCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollCount.Location = new System.Drawing.Point(218, 42);
            this.RollCount.Name = "RollCount";
            this.RollCount.Size = new System.Drawing.Size(92, 24);
            this.RollCount.TabIndex = 2;
            this.RollCount.Text = "First Roll";
            // 
            // RollDice
            // 
            this.RollDice.Location = new System.Drawing.Point(222, 143);
            this.RollDice.Name = "RollDice";
            this.RollDice.Size = new System.Drawing.Size(75, 23);
            this.RollDice.TabIndex = 3;
            this.RollDice.Text = "Roll Dice";
            this.RollDice.UseVisualStyleBackColor = true;
            this.RollDice.Click += new System.EventHandler(this.RollDice_Click);
            // 
            // RollOutcome
            // 
            this.RollOutcome.AutoSize = true;
            this.RollOutcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollOutcome.Location = new System.Drawing.Point(209, 212);
            this.RollOutcome.Name = "RollOutcome";
            this.RollOutcome.Size = new System.Drawing.Size(110, 24);
            this.RollOutcome.TabIndex = 4;
            this.RollOutcome.Text = "Dummyyyy";
            this.RollOutcome.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Player\'s Score: ";
            // 
            // PlayerScore
            // 
            this.PlayerScore.AutoSize = true;
            this.PlayerScore.BackColor = System.Drawing.Color.White;
            this.PlayerScore.Location = new System.Drawing.Point(152, 292);
            this.PlayerScore.Name = "PlayerScore";
            this.PlayerScore.Size = new System.Drawing.Size(13, 13);
            this.PlayerScore.TabIndex = 6;
            this.PlayerScore.Text = "0";
            // 
            // HouseScore
            // 
            this.HouseScore.AutoSize = true;
            this.HouseScore.BackColor = System.Drawing.Color.White;
            this.HouseScore.Location = new System.Drawing.Point(459, 291);
            this.HouseScore.Name = "HouseScore";
            this.HouseScore.Size = new System.Drawing.Size(13, 13);
            this.HouseScore.TabIndex = 8;
            this.HouseScore.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(319, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "House Score: ";
            // 
            // ContinueGame
            // 
            this.ContinueGame.Location = new System.Drawing.Point(27, 330);
            this.ContinueGame.Name = "ContinueGame";
            this.ContinueGame.Size = new System.Drawing.Size(118, 39);
            this.ContinueGame.TabIndex = 9;
            this.ContinueGame.Text = "Continue Playing";
            this.ContinueGame.UseVisualStyleBackColor = true;
            this.ContinueGame.Visible = false;
            this.ContinueGame.Click += new System.EventHandler(this.ContinueGame_Click);
            // 
            // CancelGame
            // 
            this.CancelGame.Location = new System.Drawing.Point(354, 330);
            this.CancelGame.Name = "CancelGame";
            this.CancelGame.Size = new System.Drawing.Size(118, 39);
            this.CancelGame.TabIndex = 10;
            this.CancelGame.Text = "Cancel Game";
            this.CancelGame.UseVisualStyleBackColor = true;
            this.CancelGame.Click += new System.EventHandler(this.S_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Snake_Eyes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 381);
            this.Controls.Add(this.CancelGame);
            this.Controls.Add(this.ContinueGame);
            this.Controls.Add(this.HouseScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PlayerScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RollOutcome);
            this.Controls.Add(this.RollDice);
            this.Controls.Add(this.RollCount);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Snake_Eyes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake_Eyes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label RollCount;
        private System.Windows.Forms.Button RollDice;
        private System.Windows.Forms.Label RollOutcome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PlayerScore;
        private System.Windows.Forms.Label HouseScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ContinueGame;
        private System.Windows.Forms.Button CancelGame;
        private System.Windows.Forms.Timer timer1;
    }
}