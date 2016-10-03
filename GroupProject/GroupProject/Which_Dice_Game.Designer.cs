namespace GroupProject {
    partial class Which_Dice_Game {
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
            this.ToMenu = new System.Windows.Forms.Button();
            this.DiceGameSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ToMenu
            // 
            this.ToMenu.Location = new System.Drawing.Point(65, 162);
            this.ToMenu.Name = "ToMenu";
            this.ToMenu.Size = new System.Drawing.Size(156, 40);
            this.ToMenu.TabIndex = 5;
            this.ToMenu.Text = "Exit";
            this.ToMenu.UseVisualStyleBackColor = true;
            this.ToMenu.Click += new System.EventHandler(this.ToMenu_Click);
            // 
            // DiceGameSelection
            // 
            this.DiceGameSelection.FormattingEnabled = true;
            this.DiceGameSelection.Items.AddRange(new object[] {
            "Snake Eyes",
            "Ship Captain & Crew"});
            this.DiceGameSelection.Location = new System.Drawing.Point(83, 93);
            this.DiceGameSelection.Name = "DiceGameSelection";
            this.DiceGameSelection.Size = new System.Drawing.Size(121, 21);
            this.DiceGameSelection.TabIndex = 4;
            this.DiceGameSelection.SelectedIndexChanged += new System.EventHandler(this.DiceGameSelection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose a Game to Play";
            // 
            // Which_Dice_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ToMenu);
            this.Controls.Add(this.DiceGameSelection);
            this.Controls.Add(this.label1);
            this.Name = "Which_Dice_Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Which_Dice_Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ToMenu;
        private System.Windows.Forms.ComboBox DiceGameSelection;
        private System.Windows.Forms.Label label1;
    }
}