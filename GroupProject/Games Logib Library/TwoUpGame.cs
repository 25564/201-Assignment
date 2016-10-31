using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    /// <summary>
    /// Class that controls the logic for Two up
    /// Based off the UML diagram provided in Part B spec
    /// </summary>
    public static class TwoUpGame {
        // Defines variables
        static public Coin coin1;
        static public Coin coin2;
        static public int playerScore;
        static public int computerScore;

        // <SetupGame>
        // Initialises variables
        public static void SetUpGame() {
            coin1 = new Coin();
            coin2 = new Coin();
            playerScore = 0;
            computerScore = 0;
        }
        // </SetupGame>

        // <TossCoins>
        // Flips coin 1 and 2 for new values
        public static void TossCoins() {
            // flips coins
            coin1.Flip();
            coin2.Flip();
        }
        // </TossCoin>

        // <TossOutcome>
        // Check the outcome and update scores
        // returns a string value for the result
        public static string TossOutcome() {
            string result;
            if (coin1.IsHeads() && coin2.IsHeads()) {
                playerScore += 1;
                result = "Heads";
            } else if (!coin1.IsHeads() && !coin2.IsHeads()) {
                computerScore += 1;
                result = "Tails";
            } else {
                result = "Odds";
            }
            return result;
        }
        // </TossOutcome

        // <isHeads>
        // Checks if coins are heads, used for updating images in the form
        // returns true if the coin is heads
        public static bool isHeads(int whichCoin) {
            bool heads = true;
            if (whichCoin == 1) {
                heads = coin1.IsHeads();
            } else if (whichCoin == 2) {
                heads = coin2.IsHeads();
            }
            return heads;
        }
        // </isHeads>

        // Returns players score
        public static int GetPlayerScore() {
            return playerScore;
        }

        // Returns computer's score
        public static int GetComputerScore() {
            return computerScore;
        }

    }
}
