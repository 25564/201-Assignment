using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games_Logic_Library;

namespace GroupProject {
    public partial class Two_Up : Form {

        // Definitely no magic numbers here
        const int ANIMATION_LENGTH = 10;

        protected int TimerTickCount = 0;

        public Two_Up() {
            InitializeComponent();
            // Initialize variables
            TwoUpGame.SetUpGame();
            // Set pictures on the form
            SetPictures();
        }

        private void UpdatePictureBoxImage(PictureBox whichPB, bool isHeads) {
            whichPB.Image = Images.GetCoinImage(isHeads);
        }// end UpdatePictureBoxImage

        // <SetPictures>
        // Sets the coin pictures to corresponding pictureboxes
        private void SetPictures() {
            UpdatePictureBoxImage(pictureBox1, TwoUpGame.isHeads(1));
            UpdatePictureBoxImage(pictureBox2, TwoUpGame.isHeads(2));
        }
        // </SetPictures>

        // <CancelButtonClick>
        // Handles cancelling the game by closing the current form and displaying the home screen
        // <param name="sender"></param>
        // <param name="e"></param>
        private void CancelGameBtn_Click(object sender, EventArgs e) {
            Form InitialForm = new Form1();
            InitialForm.Show();
            this.Close();
        }
        // </CancelButtonClick>

        // <PlayAgainButtonClick>
        // Resets the game by enabling buttins
        // <param name="sender"></param>
        // <param name="e"></param>
        private void PlayAgainBtn_Click(object sender, EventArgs e) {
            ThrowCoinsBtn.Enabled = true;
            PlayAgainBtn.Visible = false;
        }
        // </PlayAgainButtonClick>

        // <HandleOutcome>
        // Handles the end of a turn and enables buttons
        private void HandleOutcome() {
            ThrowCoinsBtn.Enabled = false;
            PlayAgainBtn.Visible = true;
        }
        // </HandleOutcome>

        private void AnimateToss() {
            timer1.Start();
        }

        // <TossCoin>
        // Tosses coins using the logic in the Games Logic Library
        private void TossCoin() {
            // Flip coins
            TwoUpGame.TossCoins();
            // Set pictures to new values
            SetPictures();
            // Get the outcome of the toss, this also updates the scores
            string TossOutcome = TwoUpGame.TossOutcome();
            ResultLbl.Text = TossOutcome + "!";
            // If both coins are heads...
            if (TossOutcome == "Heads") {
                // Update label text
                PlayerScore.Text = (TwoUpGame.GetPlayerScore()).ToString();
                HandleOutcome();
                // If the coins are both tails...
            } else if (TossOutcome == "Tails") {
                ComputerScore.Text = (TwoUpGame.GetComputerScore()).ToString();
                HandleOutcome();
                // If coins are both different
            } else {
                PlayerScore.Text = (TwoUpGame.GetPlayerScore()).ToString();
                ComputerScore.Text = (TwoUpGame.GetComputerScore()).ToString();
                HandleOutcome();
            }
        }
        // </TossCoins>

        // <ThrowCoins>
        // Disables the button, shows results label, Animates the coin toss
        private void ThrowCoinsBtn_Click(object sender, EventArgs e) {
            // Show the results label
            ResultLbl.Visible = true;

            // Disable the throw button
            ThrowCoinsBtn.Enabled = false;
            AnimateToss();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (TimerTickCount > ANIMATION_LENGTH) {
                timer1.Stop();
                TimerTickCount = 0;
                TossCoin();
            } else {

                TimerTickCount++;

                // If Count is even PictureBox1 is Heads and  PicutreBox2 is tails. The opposite is true for if Count is odd
                // Bypass the Game Logic Library as this change is purely visual and the library was creating a pointless
                // bottleneck which would cause the flip animation to stop working after 4 or 5 iterations
                UpdatePictureBoxImage(pictureBox1, (TimerTickCount % 2) == 0);
                UpdatePictureBoxImage(pictureBox2, ((TimerTickCount + 1) % 2) == 0);
            }
        }
    }
}
