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
using Games_Logic_Library;

namespace GroupProject {
    /// <summary>
    /// This form class provides a GUI for the Twenty One game
    /// Based off the spec in Part C2
    /// </summary>
    public partial class Twenty_One : Form {

        const int BLACK_JACK_SCORE = 21;

        public Twenty_One() {
            InitializeComponent();
            Twenty_One_Game.SetUpGame();
        }

        /// <summary>
        /// Generate GUIs to represent a hand of cards
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="tableLayoutPanel"></param>
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
        }

        /// <summary>
        /// Ask the user via a popup if they would like the ace to count as 11 or 1
        /// </summary>
        private void checkPlayerAces() {
            int ignoreCount = Twenty_One_Game.GetNumOfUserAcesWithValueOne();
            foreach (Card card in Twenty_One_Game.GetHand(0)) {
                if (card.GetFaceValue() == FaceValue.Ace) { // is an Ace
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
        } // End checkPlayerAces

        /// <summary>
        /// Deal Initial cards to the computer and player then setup controls 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dealButton_Click(object sender, EventArgs e) {
            Twenty_One_Game.ResetTotals();
            Twenty_One_Game.DealOneCardTo(0);
            Twenty_One_Game.DealOneCardTo(0);
            Twenty_One_Game.DealOneCardTo(1);
            Twenty_One_Game.DealOneCardTo(1);
            
            PlayerPointsLabel.Text = Twenty_One_Game.CalculateHandTotal(0).ToString();

            DisplayGuiHand(Twenty_One_Game.GetHand(0), playerTableLayoutPanel);
            DisplayGuiHand(Twenty_One_Game.GetHand(1), dealerTableLayoutPanel);

            checkPlayerAces();

            DealerPointsLabel.Text = Twenty_One_Game.GetTotalPoints(1).ToString();

            DealerBustedLabel.Visible = false;
            PlayerBustedLabel.Visible = false;
            dealButton.Enabled = false;
            standButton.Enabled = true;
            hitButton.Enabled = true;

            checkPlayerAction();
        } // end dealButtonClick

        /// <summary>
        /// Check if the players most recent action won the game and update the score label
        /// </summary>
        private void checkPlayerAction() {
            int Score = Twenty_One_Game.CalculateHandTotal(0);

            PlayerPointsLabel.Text = Score.ToString();

            if (Score >= BLACK_JACK_SCORE) { // Player Caused Ending
                if (Score > BLACK_JACK_SCORE) {
                    PlayerBustedLabel.Visible = true;
                }
                gameOver();
            }
        } // End checkPlayerAction

        /// <summary>
        /// Evalutate who won and incrememnt win count appropriately
        /// </summary>
        private void calculateWinner() {
            int playerScore = Twenty_One_Game.GetTotalPoints(0);
            int dealerScore = Twenty_One_Game.GetTotalPoints(1);

            if (dealerScore != playerScore) { // Not a tie
                if (playerScore > BLACK_JACK_SCORE) { // Player Busted
                    Twenty_One_Game.IncrementNumOfGamesWon(1);
                } else if (dealerScore > BLACK_JACK_SCORE { // Dealer Busted
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
        } // end calculateWinner()

        /// <summary>
        /// Reset UI to prepare for next game and display final result
        /// </summary>
        private void gameOver() {
            if (PlayerBustedLabel.Visible == false) { // Dealer only needs to play if it hasn't already won
                Twenty_One_Game.PlayForDealer();
                DisplayGuiHand(Twenty_One_Game.GetHand(0), playerTableLayoutPanel);
                DisplayGuiHand(Twenty_One_Game.GetHand(1), dealerTableLayoutPanel);
                DealerPointsLabel.Text = Twenty_One_Game.GetTotalPoints(1).ToString();
                if (Twenty_One_Game.GetTotalPoints(1) > 21) {
                    DealerBustedLabel.Visible = true;
                }
            }

            calculateWinner();

            hitButton.Enabled = false;
            standButton.Enabled = false;
            dealButton.Enabled = true;
        } // End gameOver()

        /// <summary>
        /// Testing. No possible to access in final game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testButton_Click(object sender, EventArgs e) {
            const int testNumOfCardsForDealer = 2;
            const int testNumOfCardsForPlayer = 4;
            CardPile testCardPile = new CardPile(true);
            testCardPile.Shuffle();
            Hand testHandForDealer = new Hand(testCardPile.DealCards(testNumOfCardsForDealer));
            Hand testHandForPlayer = new Hand(testCardPile.DealCards(testNumOfCardsForPlayer));
            DisplayGuiHand(testHandForDealer, dealerTableLayoutPanel);
            DisplayGuiHand(testHandForPlayer, playerTableLayoutPanel);
        }// end TestButtonClick

        /// <summary>
        /// On click proceed with computer turn and update UI appropraitely
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void standButton_Click(object sender, EventArgs e) {
            Twenty_One_Game.PlayForDealer();
            DealerPointsLabel.Text = Twenty_One_Game.GetTotalPoints(1).ToString();
            DisplayGuiHand(Twenty_One_Game.GetHand(1), dealerTableLayoutPanel);

            if (Twenty_One_Game.GetTotalPoints(1) > BLACK_JACK_SCORE) {
                DealerBustedLabel.Visible = true;
            }

            gameOver();
        } // end StandButtonClick

        /// <summary>
        /// Close the form and return to the landing form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e) {
            Form InitialForm = new Form1();
            InitialForm.Show();
            this.Close();
        }// end cancelButtonClick

        /// <summary>
        /// on click deal a new card to the player, Update the UI and then check for win  conditions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hitButton_Click(object sender, EventArgs e) {
            Twenty_One_Game.DealOneCardTo(0);
            DisplayGuiHand(Twenty_One_Game.GetHand(0), playerTableLayoutPanel);
            checkPlayerAces();
            checkPlayerAction();
        } // end hitButtonClick
    }
}
