using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logib_Library {
    public static class TwoUpGame {

        static public Coin coin1;
        static public Coin coin2;
        static public int playerScore;
        static public int computerScore;

        public static void SetUpGame() {
            // Initialises variables
            coin1 = new Coin();
            coin2 = new Coin();
            playerScore = 0;
            computerScore = 0;
        }

        public static void TossCoins() {
            // flips coins
            coin1.Flip();
            coin2.Flip();
        }

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

        public static bool isHeads(int whichCoin) {
            bool heads = true;
            if (whichCoin == 1) {
                heads = coin1.IsHeads();
            } else if (whichCoin == 2) {
                heads = coin2.IsHeads();
            }
            return heads;
        }

        public static int GetPlayerScore() {
            return playerScore;
        }

        public static int GetComputerScore() {
            return computerScore;
        }

    }
}
