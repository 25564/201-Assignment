using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    /// <summary>
    /// This class is used to control the logic for the Snake Eyes game
    /// Based of the UML diagram provided in the Part C1 spec
    /// </summary>
    public class SnakeEyes {
        // Define variables
        static public int rollTotal;
        static public int playerTotal;
        static public int houseTotal;
        static public int possiblePoints;
        static public int numRolls;
        static public bool PointsSet;
        static public Die[] dice = new Die[2];

        // <SetupGame>
        // Initialise variables
        public static void SetUpGame() {
            rollTotal = 0;
            playerTotal = 0;
            houseTotal = 0;
            possiblePoints = 0;
            numRolls = 0;
            dice[0] = new Die();
            dice[1] = new Die();
        }
        // </SetupGame>

        // <PlayRoll>
        // Rolls the dice, checking the total of the roll
        // Checks conditions to see who is awarded points
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
                PointsSet = false;
                RollAgain = false;
            // Alternatively have a different method used for AnotherRoll...
            // This seemed more concise
            } else if (possiblePoints == 0) {
                GetPossiblePoints();
                PointsSet = true;
                RollAgain = true;
            } else {
                
                RollAgain = true;
            }

            return RollAgain;
        }
        // </PlayRoll> 

        // <FirstRoll>
        // Plays the first roll of the game
        public static bool FirstRoll() {
            bool RollAgain = PlayRoll();
            return RollAgain;
        }
        // </FirstRoll>

        // <AnotherRoll>
        // Plays another roll of the dice
        public static bool AnotherRoll() {
            bool RollAgain = PlayRoll();
            return RollAgain;
        }
        // </AnotherRoll>

        // <DiceFaceValue>
        // <param name="whichDie"/>
        // returns the face value of the specified die
        public static int DiceFacevalue(int whichDie) {
            int DiceValue = dice[whichDie].GetFaceValue();
            return DiceValue;
        }
        // </DiceFaceValue>

        // Return player points
        public static int GetPlayersPoints() {
            return playerTotal;
        }

        // Return house points
        public static int GetHousePoints() {
            return houseTotal;
        }

        // Defines possible points for player to win
        public static int GetPossiblePoints() {
            possiblePoints = GetRollTotal();
            return possiblePoints;
        }

        // <GetRollTotal>
        // Method for getting the total of the current dice
        public static int GetRollTotal() {
            int DiceOne = DiceFacevalue(0);
            int DiceTwo = DiceFacevalue(1);
            rollTotal = DiceOne + DiceTwo;

            return rollTotal;
        }
        // </GetRollTotal>

        // <GetRollOutcome>
        // Determines the outcome of the roll
        // Returns the outcome as a formatted string
        public static string GetRollOutcome() {
            string outcome;
            
            if (rollTotal == 2) {
                outcome = String.Format("Player wins {0} points!", 2);
                playerTotal += 2;
            } else if (rollTotal == 7 || rollTotal == 11) {
                outcome = String.Format("Player wins {0} point!", 1);
                playerTotal += 1;
            } else if (rollTotal == 3 || rollTotal == 12) {
                outcome = String.Format("House wins {0} points!", 2);
                houseTotal += 2;
            } else if (rollTotal == possiblePoints && PointsSet == false) {
                outcome = String.Format("Player wins {0} points!", possiblePoints);
                playerTotal += possiblePoints;
            } else {
                outcome = "No result, roll " + possiblePoints + " again to win!";
            }

            return outcome;
        }
        // </GetRollOutcome>
    }
}
