using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public class Twenty_One_Game {

        // Initial Variables
        static protected CardPile cardPile;
        static protected Hand[] hands;
        static protected int[] totalPoints;
        static protected int[] numOfGamesWon;
        static protected int numOfUserAcesWithValueOne;

        /// <summary>
        /// Set the intial game variable
        /// </summary>
        public static void SetUpGame() {
            numOfGamesWon = new int[2] { 0, 0 };
            ResetTotals();
        } // end SetupGame

        /// <summary>
        /// Deal one card to a hand at an index.
        /// </summary>
        /// <param name="who"></param>
        public static void DealOneCardTo(int who) {
            hands[who].Add(cardPile.DealOneCard());
            totalPoints[who] = CalculateHandTotal(who);
        } // end DealOneCard

        /// <summary>
        /// Calculates the sum value of a hand
        /// </summary>
        /// <param name="who"></param>
        /// <returns>The Score of that hand</returns>
        public static int CalculateHandTotal(int who) {
            int Score = 0; // Store total hand value
            int AceCount = 0; // The Amount of aces currently witnessed in the player hand

            foreach (Card card in hands[who]) { // Loop through relevant hand
                if (card.GetFaceValue() <= FaceValue.Ten) { // If the Value is less than 10 add the number on the card
                    Score += (int)(card.GetFaceValue() + 2);
                } else {
                    if (card.GetFaceValue() == FaceValue.Ace) {
                        if (who == 0) {
                            if (AceCount < GetNumOfUserAcesWithValueOne()) { // If this ace counts as a one or eleven
                                Score += 1;
                            } else {
                                Score += 11;
                            }
                        } else {
                            Score += 11;
                        }
                    } else { // King, Queen or Jack. They are all valued 10
                        Score += 10;
                    }
                }

                Console.WriteLine(Score);
            }

            return Score; // Return final tally
        } // end Calculate Hand

        /// <summary>
        /// Play until the dealer is greater than 17
        /// </summary>
        public static void PlayForDealer() {
            while (GetTotalPoints(1) < 17) {
                Console.WriteLine(GetTotalPoints(1));
                DealOneCardTo(1);
            }
        } // end PlayForDealer

        /// <summary>
        /// Return the hand at a certain index
        /// </summary>
        /// <param name="who"></param>
        /// <returns></returns>
        public static Hand GetHand(int who) {
            return hands[who];
        } // end GetHand

        /// <summary>
        /// Returns the pre calculated points of a hand. (Does not update them)
        /// </summary>
        /// <param name="who"></param>
        /// <returns></returns>
        public static int GetTotalPoints(int who) {
            return totalPoints[who];
        } // end GetTotalPoints


        /// <summary>
        /// Return number of games won
        /// </summary>
        /// <param name="who"></param>
        /// <returns></returns>
        public static int GetNumOfGamesWon(int who) {
            return numOfGamesWon[who];
        } // end GetNumOfGamesWon


        /// <summary>
        /// Increment Games won for a certain player
        /// </summary>
        /// <param name="who"></param>
        public static void IncrementNumOfGamesWon(int who) { // Was not in UML but is neccessary 
            numOfGamesWon[who]++;
        } // end IncrementNumOfGamesWon

        /// <summary>
        /// Get Number of aces with the value of one
        /// </summary>
        /// <returns></returns>
        public static int GetNumOfUserAcesWithValueOne() {
            return numOfUserAcesWithValueOne;
        } // end GetNumOfUserAcesWithValueOne

        /// <summary>
        /// Increment the number of aces being treated as 1
        /// </summary>
        public static void IncrementNumOfUserAcesWithValueOne() {
            numOfUserAcesWithValueOne++;
        } // end IncrementNumOfUserAcesWithValueOne

        /// <summary>
        /// Reset the players hand, Deck and other globals to initial state
        /// </summary>
        public static void ResetTotals() {
            hands = new Hand[2] { new Hand(), new Hand() };

            cardPile = new CardPile(true);
            cardPile.Shuffle();

            totalPoints = new int[2] { 0, 0 };
            numOfUserAcesWithValueOne = 0;
        } // end ResetTotals
    }
}
