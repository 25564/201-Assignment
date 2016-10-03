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
    public partial class Which_Dice_Game : Form {
        public Which_Dice_Game() {
            InitializeComponent();
        }

        private void DiceGameSelection_SelectedIndexChanged(object sender, EventArgs e) {
            int SelectedGame = DiceGameSelection.SelectedIndex;
            if (SelectedGame == 0) {
                Form DiceGame = new Snake_Eyes();
                DiceGame.Show();
                this.Hide();
            } else {
                Form DiceGame = new Ship_Captain_Crew();
                DiceGame.Show();
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
