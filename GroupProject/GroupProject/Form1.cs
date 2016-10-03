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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        // Initial variables
        int SelectedGame;

        private void CoinGame_CheckedChanged(object sender, EventArgs e) {
            if (CoinGame.Checked || DiceGame.Checked || CardGame.Checked) {
                StartBtn.Enabled = true;
            }

            if (CoinGame.Checked) {
                SelectedGame = 1;
            } else if (DiceGame.Checked) {
                SelectedGame = 2;
            } else if (CardGame.Checked) {
                SelectedGame = 3;
            }
        }

        private void StartBtn_Click(object sender, EventArgs e) {
            // 1 = Coin Game
            if (SelectedGame == 1) {
                Form GameForm = new Two_Up();
                GameForm.Show();
                // Hides the current form
                this.Hide();

            // 2 = Dice Game Selection
            } else if (SelectedGame == 2) {
                Form GameForm = new Which_Dice_Game();
                GameForm.Show();
                this.Hide();

            // 3 = Card Game Selection
            } else if (SelectedGame == 3) {
                Form GameForm = new Which_Card_Game();
                GameForm.Show();
                this.Close();
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e) {
            System.Windows.Forms.Application.Exit();
        }
    }
}
