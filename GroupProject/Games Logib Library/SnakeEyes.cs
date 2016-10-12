using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logib_Library {
    public class SnakeEyes {
        static public int rollTotal;
        static public int playerTotal;
        static public int houseTotal;
        static public int possiblePoints;
        static public int numRolls;
        static public Die[] dice = new Die[2];

        public static void SetUpGame() {
            rollTotal = 0;
            playerTotal = 0;
            houseTotal = 0;
            possiblePoints = 0;
            numRolls = 0;
            dice[0] = new Die();
            dice[1] = new Die();
        }

        // Method to check roll of the dice
        public static bool PlayRoll() {
            bool RollAgain;

            for (int i = 0; i < (dice.Length); i++) {
                dice[i].RollDie();
            }
            numRolls++;

            rollTotal = GetRollTotal();

            if (rollTotal == 2) {
                RollAgain = false;
            } else if (rollTotal == 7 || rollTotal == 11) {
                RollAgain = false;
            } else if (rollTotal == 3 || rollTotal == 12) {
                RollAgain = false;
            } else if (rollTotal == possiblePoints) {
                playerTotal += possiblePoints;
                RollAgain = false;
            } else {
                GetPossiblePoints();
                RollAgain = true;
            }

            return RollAgain;
        }

        public static bool FirstRoll() {
            bool RollAgain = PlayRoll();
            return RollAgain;
        }

        public static bool AnotherRoll() {
            bool RollAgain = PlayRoll();
            return RollAgain;
        }

        public static int DiceFacevalue(int whichDie) {
            int DiceValue = dice[whichDie].GetFaceValue();
            return DiceValue;
        }

        public static int GetPlayersPoints() {
            return playerTotal;
        }

        public static int GetHousePoints() {
            return houseTotal;
        }

        public static int GetPossiblePoints() {
            possiblePoints = GetRollTotal();
            return possiblePoints;
        }

        public static int GetRollTotal() {
            int DiceOne = DiceFacevalue(0);
            int DiceTwo = DiceFacevalue(1);
            rollTotal = DiceOne + DiceTwo;

            return rollTotal;
        }

        public static string GetRollOutcome() {
            string outcome;

            if (rollTotal == 2) {
                outcome = "Player wins!";
                playerTotal += 2;
            } else if (rollTotal == 7 || rollTotal == 11) {
                outcome = "Player wins!";
                playerTotal += 1;
            } else if (rollTotal == 3 || rollTotal == 12) {
                outcome = "Player loses";
                houseTotal += 2;
            
            } else {
                outcome = "No result, roll " + possiblePoints + " again to win!";
            }

            return outcome;
        }
    }
}
