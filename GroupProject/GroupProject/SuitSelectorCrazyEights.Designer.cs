namespace GroupProject {
    partial class SuitSelectorCrazyEights {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SpadesRadioButton = new System.Windows.Forms.RadioButton();
            this.HeartsRadioButton = new System.Windows.Forms.RadioButton();
            this.DiamondsRadioButton = new System.Windows.Forms.RadioButton();
            this.ClubsRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SpadesRadioButton);
            this.groupBox1.Controls.Add(this.HeartsRadioButton);
            this.groupBox1.Controls.Add(this.DiamondsRadioButton);
            this.groupBox1.Controls.Add(this.ClubsRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose a suit";
            // 
            // SpadesRadioButton
            // 
            this.SpadesRadioButton.AutoSize = true;
            this.SpadesRadioButton.Location = new System.Drawing.Point(6, 89);
            this.SpadesRadioButton.Name = "SpadesRadioButton";
            this.SpadesRadioButton.Size = new System.Drawing.Size(84, 25);
            this.SpadesRadioButton.TabIndex = 3;
            this.SpadesRadioButton.TabStop = true;
            this.SpadesRadioButton.Text = "Spades";
            this.SpadesRadioButton.UseVisualStyleBackColor = true;
            // 
            // HeartsRadioButton
            // 
            this.HeartsRadioButton.AutoSize = true;
            this.HeartsRadioButton.Location = new System.Drawing.Point(6, 66);
            this.HeartsRadioButton.Name = "HeartsRadioButton";
            this.HeartsRadioButton.Size = new System.Drawing.Size(81, 25);
            this.HeartsRadioButton.TabIndex = 2;
            this.HeartsRadioButton.TabStop = true;
            this.HeartsRadioButton.Text = "Hearts";
            this.HeartsRadioButton.UseVisualStyleBackColor = true;
            // 
            // DiamondsRadioButton
            // 
            this.DiamondsRadioButton.AutoSize = true;
            this.DiamondsRadioButton.Location = new System.Drawing.Point(6, 43);
            this.DiamondsRadioButton.Name = "DiamondsRadioButton";
            this.DiamondsRadioButton.Size = new System.Drawing.Size(105, 25);
            this.DiamondsRadioButton.TabIndex = 1;
            this.DiamondsRadioButton.TabStop = true;
            this.DiamondsRadioButton.Text = "Diamonds";
            this.DiamondsRadioButton.UseVisualStyleBackColor = true;
            // 
            // ClubsRadioButton
            // 
            this.ClubsRadioButton.AutoSize = true;
            this.ClubsRadioButton.Location = new System.Drawing.Point(6, 20);
            this.ClubsRadioButton.Name = "ClubsRadioButton";
            this.ClubsRadioButton.Size = new System.Drawing.Size(73, 25);
            this.ClubsRadioButton.TabIndex = 0;
            this.ClubsRadioButton.TabStop = true;
            this.ClubsRadioButton.Text = "Clubs";
            this.ClubsRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SuitSelectorCrazyEights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 186);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuitSelectorCrazyEights";
            this.Text = "ChooseSuitForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton SpadesRadioButton;
        public System.Windows.Forms.RadioButton HeartsRadioButton;
        public System.Windows.Forms.RadioButton DiamondsRadioButton;
        public System.Windows.Forms.RadioButton ClubsRadioButton;
        private System.Windows.Forms.Button button1;
    }
}