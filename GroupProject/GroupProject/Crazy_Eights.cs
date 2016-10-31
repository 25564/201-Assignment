using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Low_Level_Objects_Library;
using Games_Logic_Library;

namespace GroupProject {
    public partial class Crazy_Eights : Form {
        /// <summary>
        /// This form class provides a GUI for the Crazy Eights game
        /// Based off the spec in Part D
        /// </summary>
        public Crazy_Eights() {
            InitializeComponent();
            this.drawPilePictureBox.Image = Images.GetBackOfCardImage();
            this.statusLabel.Text = "Click Deal to start the game.";
        }

        /// <summary>
        /// Display 
        /// </summary>
        /// <param name="who"></param>
        /// <param name="hand"></param>
        /// <param name="tableLayoutPanel"></param>
        private void DisplayHand(int who, Hand hand, TableLayoutPanel tableLayoutPanel) {
            tableLayoutPanel.Controls.Clear(); // Clean existsing Table
            foreach (Card card in hand) {
                // Dynamically Create the picture Box
                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Margin = new Padding(0);
                pictureBox.Image = Images.GetCardImage(card);
                
                if (who == 0) { // Add click handling if player
                    pictureBox.Click += new EventHandler(CardClicked);
                    pictureBox.Tag = card;
                }

                tableLayoutPanel.Controls.Add(pictureBox);
            }
        } // End DisplayHand

        /// <summary>
        /// Called when one of the Users cards are clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardClicked(object sender, EventArgs e) {
            PictureBox ObjectClicked = (PictureBox)sender;
            Card CardClicked = (Card)ObjectClicked.Tag;
            if (Crazy_Eights_Game.isGameOver() == false) {
                if (Crazy_Eights_Game.CanPlayCard(CardClicked)) {
                    Crazy_Eights_Game.PlayCard(CardClicked, 0);

                    if (CardClicked.GetFaceValue() == FaceValue.Eight) { // If the player uses an 8
                        var SelectorForm = new SuitSelectorCrazyEights();

                        if (SelectorForm.ShowDialog(this) == DialogResult.OK) {
                            Crazy_Eights_Game.SetSuit(SelectorForm.ChosenSuit());
                        }
                    }

                    UpdateCardDisplay();
                    isGameOver();

                    if (Crazy_Eights_Game.isGameOver() == false) {
                        RefreshTheFormThenPause();
                        Crazy_Eights_Game.ComputerPlay();
                        isGameOver();
                        if (Crazy_Eights_Game.isGameOver() == false) { //Did the computer just win?
                            if (Crazy_Eights_Game.CanPlay(0)) {
                                statusLabel.Text = "Please Select a Card to play.";
                            } else {
                                statusLabel.Text = "There is no move you can make. Please select from the deck.";
                            }
                        }
                    }
                } else {
                    statusLabel.Text = "You cannot play this card at this moment";
                }
            }

            UpdateCardDisplay();
        } // End CardClicked

        /// <summary>
        /// Update the Card GUI's
        /// </summary>
        private void UpdateCardDisplay() {
            DisplayHand(0, Crazy_Eights_Game.getHand(0), PlayerCardPanel);
            DisplayHand(1, Crazy_Eights_Game.getHand(1), ComputerCardPanel);
            placedCardsPictureBox.Image = Images.GetCardImage(Crazy_Eights_Game.GetCurrentActiveCard());
        }
        
        /// <summary>
        /// Called when a draw button is clicked. Checks if a user can play and draws a new card if not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawPilePictureBox_Click(object sender, EventArgs e) {
            if (Crazy_Eights_Game.isGameOver() == false) { // Don't draw before a game starts
                if (Crazy_Eights_Game.CanPlay(0) == false) {
                    if (Crazy_Eights_Game.getHand(0).GetCount() < 13) {
                        Crazy_Eights_Game.DealCard(0);
                        UpdateCardDisplay();
                    }
                } else {
                    statusLabel.Text = "There is cards you can play.";
                }
            }
        } // end drawPilePictureBox

        /// <summary>
        /// Called when the deal button is clicked. Initialises a new round
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dealButton_Click(object sender, EventArgs e) {
            Crazy_Eights_Game.SetupGame();
            Crazy_Eights_Game.DealInitialHands();
            sortCardButton.Enabled = true;
            UpdateCardDisplay();
        } // end dealButtonClick

        /// <summary>
        /// Called when the sort button is clicked. Sorts the users hand by suit and face
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortCardButton_Click(object sender, EventArgs e) {
            Crazy_Eights_Game.SortHand(0);
            UpdateCardDisplay();
        } // end sortCardButtonClick


        /// <summary>
        /// Hides current window and displays landing form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e) {
            Form InitialForm = new Form1();
            InitialForm.Show();
            this.Close();
        } // End cancelButtonClick

        /// <summary>
        /// Checks if the game is over and updates the status text accordingly if it has ended 
        /// </summary>
        private void isGameOver() {
            Crazy_Eights_Game.checkGameOver();
            if (Crazy_Eights_Game.isGameOver()) {
                switch (Crazy_Eights_Game.getVictor()) { // Display Relevant Final message depending on victor
                    case Crazy_Eights_Game.Victor.Computer:
                        statusLabel.Text = "You lost. Press Deal to start again";
                        break;
                    case Crazy_Eights_Game.Victor.Player:
                        statusLabel.Text = "You Won. Press Deal to start again";
                        break;
                    case Crazy_Eights_Game.Victor.Tie:
                        statusLabel.Text = "It was a tie. Press Deal to start again";
                        break;
                }
            }
        } // end isGameOver

        private static void RefreshTheFormThenPause() { // Otherwise the computer plays too fast
            // form display any recent changes to any Controls
            Application.DoEvents();
            // Wait, then continue.
            const int HALF_SECOND = 500; // milliseconds.
            Thread.Sleep(HALF_SECOND);
        }
    }
}
