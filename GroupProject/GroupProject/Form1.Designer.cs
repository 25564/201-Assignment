namespace GroupProject {
    partial class Form1 {
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CardGame = new System.Windows.Forms.RadioButton();
            this.DiceGame = new System.Windows.Forms.RadioButton();
            this.CoinGame = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monaco Arena";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CardGame);
            this.groupBox1.Controls.Add(this.DiceGame);
            this.groupBox1.Controls.Add(this.CoinGame);
            this.groupBox1.Location = new System.Drawing.Point(68, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 179);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Game Type";
            // 
            // CardGame
            // 
            this.CardGame.AutoSize = true;
            this.CardGame.Location = new System.Drawing.Point(63, 112);
            this.CardGame.Name = "CardGame";
            this.CardGame.Size = new System.Drawing.Size(78, 17);
            this.CardGame.TabIndex = 2;
            this.CardGame.TabStop = true;
            this.CardGame.Text = "Card Game";
            this.CardGame.UseVisualStyleBackColor = true;
            this.CardGame.CheckedChanged += new System.EventHandler(this.CoinGame_CheckedChanged);
            // 
            // DiceGame
            // 
            this.DiceGame.AutoSize = true;
            this.DiceGame.Location = new System.Drawing.Point(63, 77);
            this.DiceGame.Name = "DiceGame";
            this.DiceGame.Size = new System.Drawing.Size(78, 17);
            this.DiceGame.TabIndex = 1;
            this.DiceGame.TabStop = true;
            this.DiceGame.Text = "Dice Game";
            this.DiceGame.UseVisualStyleBackColor = true;
            this.DiceGame.CheckedChanged += new System.EventHandler(this.CoinGame_CheckedChanged);
            // 
            // CoinGame
            // 
            this.CoinGame.AutoSize = true;
            this.CoinGame.Location = new System.Drawing.Point(63, 44);
            this.CoinGame.Name = "CoinGame";
            this.CoinGame.Size = new System.Drawing.Size(77, 17);
            this.CoinGame.TabIndex = 0;
            this.CoinGame.TabStop = true;
            this.CoinGame.Text = "Coin Game";
            this.CoinGame.UseVisualStyleBackColor = true;
            this.CoinGame.CheckedChanged += new System.EventHandler(this.CoinGame_CheckedChanged);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(111, 362);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(122, 23);
            this.ExitBtn.TabIndex = 2;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Enabled = false;
            this.StartBtn.Location = new System.Drawing.Point(111, 310);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(122, 23);
            this.StartBtn.TabIndex = 3;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 423);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monaco Arena";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CardGame;
        private System.Windows.Forms.RadioButton DiceGame;
        private System.Windows.Forms.RadioButton CoinGame;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button StartBtn;
    }
}

