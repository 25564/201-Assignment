using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Low_Level_Objects_Library;
using Games_Logib_Library;

namespace GroupProject {
    public partial class Twenty_One : Form {
        public Twenty_One() {
            InitializeComponent();
            Twenty_One_Game.SetUpGame();
        }

        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel) {
            tableLayoutPanel.Controls.Clear(); // Remove any cards already being shown.
            foreach (Card card in hand) {
                // Construct a PictureBox object.
                PictureBox pictureBox = new PictureBox();
                // Tell the PictureBox to use all the space inside its square.
                pictureBox.Dock = DockStyle.Fill;
                // Remove spacing around the PictureBox. (Default is 3 pixels.)
                pictureBox.Margin = new Padding(0);
                pictureBox.Image = Images.GetCardImage(card);
                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }// End DisplayGuiHand

        private void Twenty_One_Load(object sender, EventArgs e) {

        }

        private void Twenty_One_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Visible = false;
        }

        private void checkPlayerAces() {
            int ignoreCount = Twenty_One_Game.GetNumOfUserAcesWithValueOne();
            foreach (Card card in Twenty_One_Game.GetHand(0)) {
                if ((int)card.GetFaceValue() == 12) { // is an Ace
                    if (ignoreCount <= 0) {
                        // Pop up message box
                        DialogResult result = MessageBox.Show("Count Aces as 1?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // If user wants to quit
                        if (result == DialogResult.Yes) {
                            Twenty_One_Game.IncrementNumOfUserAcesWithValueOne();
                        }
                    } else {
                        ignoreCount -= 1;
                    }
                } 
            }

            AceValueOneLabel.Text = Twenty_One_Game.GetNumOfUserAcesWithValueOne().ToString();
        }

        private void dealButton_Click(object sender, EventArgs e) {
            Twenty_One_Game.ResetTotals();
            Twenty_One_Game.DealOneCardTo(0);
            Twenty_One_Game.DealOneCardTo(0);
            Twenty_One_Game.DealOneCardTo(1);
            Twenty_One_Game.DealOneCardTo(1);

            checkPlayerAction();

            DisplayGuiHand(Twenty_One_Game.GetHand(0), playerTableLayoutPanel);
            DisplayGuiHand(Twenty_One_Game.GetHand(1), dealerTableLayoutPanel);

            checkPlayerAces();
            checkPlayerAction();

            DealerPointsLabel.Text = Twenty_One_Game.GetTotalPoints(1).ToString();

            if (Twenty_One_Game.GetTotalPoints(1) >= 21 || Twenty_One_Game.GetTotalPoints(0) >= 21) {
                gameOver();
            }

            DealerBustedLabel.Visible = false;
            PlayerBustedLabel.Visible = false;
            dealButton.Enabled = false;
            standButton.Enabled = true;
            hitButton.Enabled = true;
        }

        private void checkPlayerAction() {
            int Score = Twenty_One_Game.CalculateHandTotal(0);

            PlayerPointsLabel.Text = Score.ToString();

            if (Score >= 21) { // Player Caused Ending
                if (Score > 21) {
                    PlayerBustedLabel.Visible = true;
                }
                gameOver();
            }
        }

        private void calculateWinner() {
            int playerScore = Twenty_One_Game.GetTotalPoints(0);
            int dealerScore = Twenty_One_Game.GetTotalPoints(1);

            if (dealerScore != playerScore) { // Not a tie
                if (playerScore > 21) { // Player Busted
                    Twenty_One_Game.IncrementNumOfGamesWon(1);
                } else if (dealerScore > 21) { // Dealer Busted
                    Twenty_One_Game.IncrementNumOfGamesWon(0);
                } else {
                    if (playerScore > dealerScore) { // Player won
                        Twenty_One_Game.IncrementNumOfGamesWon(0);
                    } else {
                        Twenty_One_Game.IncrementNumOfGamesWon(1);
                    }
                }
            }

            DealerGamesWonLabel.Text = Twenty_One_Game.GetNumOfGamesWon(1).ToString();
            PlayerGamesWonLabel.Text = Twenty_One_Game.GetNumOfGamesWon(0).ToString();
        }

        private void gameOver() {

            calculateWinner();

            hitButton.Enabled = false;
            standButton.Enabled = false;
            dealButton.Enabled = true;
        }

        private void testButton_Click(object sender, EventArgs e) {
            const int testNumOfCardsForDealer = 2;
            const int testNumOfCardsForPlayer = 4;
            CardPile testCardPile = new CardPile(true);
            testCardPile.Shuffle();
            Hand testHandForDealer = new Hand(testCardPile.DealCards(testNumOfCardsForDealer));
            Hand testHandForPlayer = new Hand(testCardPile.DealCards(testNumOfCardsForPlayer));
            DisplayGuiHand(testHandForDealer, dealerTableLayoutPanel);
            DisplayGuiHand(testHandForPlayer, playerTableLayoutPanel);
        }

        private void standButton_Click(object sender, EventArgs e) {
            Twenty_One_Game.PlayForDealer();
            DealerPointsLabel.Text = Twenty_One_Game.GetTotalPoints(1).ToString();
            DisplayGuiHand(Twenty_One_Game.GetHand(1), dealerTableLayoutPanel);

            if (Twenty_One_Game.GetTotalPoints(1) > 21) {
                DealerBustedLabel.Visible = true;
            }

            gameOver();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            Form InitialForm = new Form1();
            InitialForm.Show();
            this.Close();
        }


        private void hitButton_Click(object sender, EventArgs e) {
            Twenty_One_Game.DealOneCardTo(0);
            DisplayGuiHand(Twenty_One_Game.GetHand(0), playerTableLayoutPanel);
            checkPlayerAces();
            checkPlayerAction();
        }
    }
}
