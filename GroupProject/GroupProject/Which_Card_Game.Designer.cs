﻿namespace GroupProject {
    partial class Which_Card_Game {
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
            this.CardGameSelection = new System.Windows.Forms.ComboBox();
            this.ToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a Game to Play";
            // 
            // CardGameSelection
            // 
            this.CardGameSelection.FormattingEnabled = true;
            this.CardGameSelection.Items.AddRange(new object[] {
            "Twenty-one",
            "Crazy Eights"});
            this.CardGameSelection.Location = new System.Drawing.Point(73, 93);
            this.CardGameSelection.Name = "CardGameSelection";
            this.CardGameSelection.Size = new System.Drawing.Size(121, 21);
            this.CardGameSelection.TabIndex = 1;
            this.CardGameSelection.SelectedIndexChanged += new System.EventHandler(this.CardGameSelection_SelectedIndexChanged);
            // 
            // ToMenu
            // 
            this.ToMenu.Location = new System.Drawing.Point(57, 163);
            this.ToMenu.Name = "ToMenu";
            this.ToMenu.Size = new System.Drawing.Size(156, 40);
            this.ToMenu.TabIndex = 2;
            this.ToMenu.Text = "Exit";
            this.ToMenu.UseVisualStyleBackColor = true;
            this.ToMenu.Click += new System.EventHandler(this.ToMenu_Click);
            // 
            // Which_Card_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ToMenu);
            this.Controls.Add(this.CardGameSelection);
            this.Controls.Add(this.label1);
            this.Name = "Which_Card_Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Which_Card_Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CardGameSelection;
        private System.Windows.Forms.Button ToMenu;
    }
}