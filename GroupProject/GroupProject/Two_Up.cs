using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games_Logib_Library;

namespace GroupProject {
    public partial class Two_Up : Form {
        public Two_Up() {
            InitializeComponent();
            TwoUpGame.SetUpGame();
            SetPictures();
        }

        private void SetPictures() {
            UpdatePictureBoxImage(pictureBox1, TwoUpGame.isHeads(1));
            UpdatePictureBoxImage(pictureBox2, TwoUpGame.isHeads(2));
        }

        private void UpdatePictureBoxImage(PictureBox whichPB, bool isHeads) {
            whichPB.Image = Images.GetCoinImage(isHeads);
        }// end UpdatePictureBoxImage

        private void CancelGameBtn_Click(object sender, EventArgs e) {
            Form InitialForm = new Form1();
            InitialForm.Show();
            this.Close();
        }

        private void PlayAgainBtn_Click(object sender, EventArgs e) {
            ThrowCoinsBtn.Enabled = true;
            PlayAgainBtn.Visible = false;
        }

        private void HandleWin() {
            ThrowCoinsBtn.Enabled = false;
            PlayAgainBtn.Visible = true;
        }

        private void ThrowCoinsBtn_Click(object sender, EventArgs e) {
            ResultLbl.Visible = true;
            TwoUpGame.TossCoins();
            SetPictures();
            string TossOutcome = TwoUpGame.TossOutcome();
            ResultLbl.Text = TossOutcome;
            if (TossOutcome == "Heads") {
                PlayerScore.Text = (TwoUpGame.GetPlayerScore()).ToString();
                HandleWin();
            } else if (TossOutcome == "Tails") {
                ComputerScore.Text = (TwoUpGame.GetComputerScore()).ToString();
                HandleWin();
            } else {
                PlayerScore.Text = (TwoUpGame.GetPlayerScore()).ToString();
                ComputerScore.Text = (TwoUpGame.GetComputerScore()).ToString();
            }
        }
    }
}
