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
        public Crazy_Eights() {
            InitializeComponent();
            this.drawPilePictureBox.Image = Images.GetBackOfCardImage();
            this.statusLabel.Text = "Click Deal to start the game.";
            Crazy_Eights_Game.SetupGame();
        }

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
        }
        

        private void CardClicked(object sender, EventArgs e) {
            PictureBox ObjectClicked = (PictureBox)sender;
            Card CardClicked = (Card)ObjectClicked.Tag;

            if (Crazy_Eights_Game.CanPlayCard(CardClicked)) {
                Crazy_Eights_Game.PlayCard(CardClicked, 0);

                if (CardClicked.GetFaceValue() == FaceValue.Eight) { // If the player uses an 8
                    var SelectorForm = new SuitSelectorCrazyEights();

                    if (SelectorForm.ShowDialog(this) == DialogResult.OK) {
                        Crazy_Eights_Game.SetSuit(SelectorForm.ChosenSuit());
                    }
                }

                UpdateCardDisplay();
                RefreshTheFormThenPause();
                Crazy_Eights_Game.ComputerPlay();
            } else {
                statusLabel.Text = "You cannot play this card at this moment";
            }

            UpdateCardDisplay();
        }

        private void UpdateCardDisplay() {
            DisplayHand(0, Crazy_Eights_Game.getHand(0), PlayerCardPanel);
            DisplayHand(1, Crazy_Eights_Game.getHand(1), ComputerCardPanel);
            placedCardsPictureBox.Image = Images.GetCardImage(Crazy_Eights_Game.GetCurrentActiveCard());
        }

        private void drawPilePictureBox_Click(object sender, EventArgs e) {
            if (Crazy_Eights_Game.CanPlay(0) == false) {
                if (Crazy_Eights_Game.getHand(0).GetCount() < 13) {
                    Crazy_Eights_Game.DealCard(0);
                    UpdateCardDisplay();
                }
            } else {
                statusLabel.Text = "There is cards you can play.";
            }
        }

        private void statusLabel_Enter(object sender, EventArgs e) {

        }

        private void dealButton_Click(object sender, EventArgs e) {
            Crazy_Eights_Game.DealInitialHands();
            UpdateCardDisplay();
        }

        private void sortCardButton_Click(object sender, EventArgs e) {
            Crazy_Eights_Game.SortHand(0);
            UpdateCardDisplay();
        }

        private void cancelButton_Click(object sender, EventArgs e) {

        }

        private static void RefreshTheFormThenPause() { // Otherwise the computer plays too fast
            // form display any recent changes to any Controls
            Application.DoEvents();
            // Wait, then continue.
            const int HALF_SECOND = 500; // milliseconds.
            Thread.Sleep(HALF_SECOND);
        }
    }
}
