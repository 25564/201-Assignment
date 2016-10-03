using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProject {
    public partial class Which_Card_Game : Form {
        public Which_Card_Game() {
            InitializeComponent();
        }

        private void CardGameSelection_SelectedIndexChanged(object sender, EventArgs e) {
            int SelectedGame = CardGameSelection.SelectedIndex;
            if (SelectedGame == 0) {
                Form CardGame = new Twenty_One();
                CardGame.Show();
                this.Hide();
            } else {
                Form CardGame = new Crazy_Eights();
                CardGame.Show();
                this.Hide();
            }
        }

        private void ToMenu_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", // Question text
                                                   "WARNING", // Box title
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Form InitialForm = new Form1();
                InitialForm.Show();
                this.Close();
            }
        }
    }
}
