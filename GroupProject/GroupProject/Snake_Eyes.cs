﻿using System;
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
    public partial class Snake_Eyes : Form {
        public Snake_Eyes() {
            InitializeComponent();
            SnakeEyes.SetUpGame();
            // Set pictures on the form
            SetPictures();
        }

        private void UpdatePictureBoxImage(PictureBox whichPB, int faceValue) {
            whichPB.Image = Images.GetDieImage(faceValue);
        }// end UpdatePictureBoxImage

        private void SetPictures() {
            UpdatePictureBoxImage(pictureBox1, SnakeEyes.DiceFacevalue(0));
            UpdatePictureBoxImage(pictureBox2, SnakeEyes.DiceFacevalue(1));
        }

        private void CheckOutcome(bool outcome) {
            
            if (outcome == true) {
                RollOutcome.Text = SnakeEyes.GetRollOutcome();
            } else {
                RollOutcome.Text = SnakeEyes.GetRollOutcome();
                RollDice.Enabled = false;
                ContinueGame.Visible = true;
            }
            RollOutcome.Visible = true;
            PlayerScore.Text = (SnakeEyes.playerTotal).ToString();
            HouseScore.Text = (SnakeEyes.houseTotal).ToString();
        }

        private void RollDice_Click(object sender, EventArgs e) {
            
            if (SnakeEyes.numRolls == 0) {
                bool RollAgain = SnakeEyes.FirstRoll();
                SetPictures();
                CheckOutcome(RollAgain);
            } else {
                bool RollAgain = SnakeEyes.AnotherRoll();
                SetPictures();
                CheckOutcome(RollAgain);
            }
            
        }

        private void ContinueGame_Click(object sender, EventArgs e) {
            ContinueGame.Visible = false;
            RollDice.Enabled = true;
            SnakeEyes.possiblePoints = 0;
        }

        private void HandleEnd() {
            Form InitialForm = new Form1();
            InitialForm.Show();
            this.Close();
        }

        private void S_Click(object sender, EventArgs e) {
            if (SnakeEyes.playerTotal > SnakeEyes.houseTotal) {
                MessageBox.Show("You've won!");
                HandleEnd();
            } else if (SnakeEyes.playerTotal < SnakeEyes.houseTotal) {
                MessageBox.Show("You've lost");
                HandleEnd();
            } else {
                MessageBox.Show("Nobody won!");
                HandleEnd();
            }
        }
    }
}
