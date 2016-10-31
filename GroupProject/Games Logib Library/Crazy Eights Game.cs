using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public class Crazy_Eights_Game {

        private const int MAX_HAND_SIZE = 13;

        public enum Victor {None, Player, Computer, Tie};

        // Initial Variables
        static protected CardPile DrawCards;
        static protected CardPile DeadCards;
        static protected Card CurrentActiveCard; // Current top of played cards
        static protected Hand[] hands; // Hand[0] is the Player
        static protected Suit CurrentSuit;
        static protected bool isFirstMove;
        static protected Victor GameOver = Victor.Tie;

        /// <summary>
        /// Intiialise global variables
        /// </summary>
        public static void SetupGame() {
            hands = new Hand[2] { new Hand(), new Hand() };

            isFirstMove = true;
            DrawCards = new CardPile(true);
            DeadCards = new CardPile();
            DrawCards.Shuffle();
            GameOver = Victor.None;

            CurrentActiveCard = new Card(Suit.Clubs, FaceValue.Eight);
        } // end SetupGame

        /// <summary>
        /// Computer takes its turn as per the rules stated in the spec.
        /// </summary>
        public static void ComputerPlay() {
            bool mustPass = false;

            while (CanPlay(1) == false && mustPass == false) { // Deal Cards until the computer can play or must pass
                if (getHand(1).GetCount() < 13) {
                    DealCard(1);
                } else {
                    mustPass = true;
                }
            }

            if (mustPass && CanPlay(1) == false) { // Computer can't play and passes
                return;
            }
            
            var EightCards = new List<Card>();
            var ValidSuitCards = new List<Card>(); // Cards that can be played because of suit
            var ValidFaceCards = new List<Card>();

            /* Cards are placed by priority
             * 1. Suit
             * 2. Face value
             * 3. Being an eight
             * 
             * For example if the current card is a king of spades and the ace of spades is an option
             * it will be sorted into the Suits list as being the same suit is a higher priority than
             * being an eight
             */

            foreach (Card currentCard in hands[1]) {
                if (currentCard.GetSuit() == CurrentSuit) {
                    ValidSuitCards.Add(currentCard);
                } else if (currentCard.GetFaceValue() == CurrentActiveCard.GetFaceValue()) {
                    EightCards.Add(currentCard);
                } else if (currentCard.GetFaceValue() == FaceValue.Eight) {
                    EightCards.Add(currentCard);
                } 
            }

            if (ValidSuitCards.Count > 0) { // Attempt same suit first
                PlayCard(ValidSuitCards[0], 1);
            } else if (ValidFaceCards.Count > 0) { // Then Face value
                PlayCard(ValidFaceCards[0], 1);
            } else if (EightCards.Count > 0) { // Then Give up and try eight
                PlayCard(EightCards[0], 1);
            }
        } // end ComputerPlay

        /// <summary>
        /// Return the most recently placed card
        /// </summary>
        /// <returns>The Top Card</returns>
        public static Card GetCurrentActiveCard() {
            return CurrentActiveCard;
        }

        /// <summary>
        /// For use when the Draw deck is empty. Shuffles the dead cards then makes the the draw deck.
        /// </summary>
        public static void RolloverDeadCards() {
            DrawCards = DeadCards;
            DrawCards.Shuffle();
            DeadCards = new CardPile();
        } //  end RolloverDeadCards

        /// <summary>
        /// Deals 8 cards to each of teh two players.
        /// </summary>
        public static void DealInitialHands() {
            hands = new Hand[2] { new Hand(DrawCards.DealCards(8)), new Hand(DrawCards.DealCards(8)) };
        } // end DealInitialHands


        /// <summary>
        /// Deals a single card to a player
        /// </summary>
        /// <param name="who">The Index of the player being dealt to</param>
        public static void DealCard(int who) {
            hands[who].Add(DrawCards.DealOneCard());
            if (DrawCards.GetCount() == 0) { // If that was the last card in the draw pile
                RolloverDeadCards();
            }
        } // end DealCard

        /// <summary>
        /// Is it possible for that player to move without drawing
        /// </summary>
        /// <param name="who"></param>
        /// <returns>Can the player move</returns>
        public static bool CanPlay(int who) {
            if (isFirstMove) { // First move of the game by passes the check.
                return true;
            }

            foreach (Card currentCard in hands[who]) {
                if (CanPlayCard(currentCard)) {
                    return true;
                }
            }
            return false;
        } // end CanPlay

        /// <summary>
        /// Returns if a certain card can be the next placed on the pile
        /// </summary>
        /// <param name="Attempt">The card that is attempting to be placed</param>
        /// <returns>If the card can be placed</returns>
        public static bool CanPlayCard(Card Attempt) {
            if (isFirstMove) { // First move of the game by passes the check.
                return true;
            }

            if (Attempt.GetFaceValue() == FaceValue.Eight) {
                return true;
            }

            if (Attempt.GetFaceValue() == CurrentActiveCard.GetFaceValue()) {
                return true;
            }

            if (Attempt.GetSuit() == CurrentSuit) {
                return true;
            }

            return false;
        } // end CanPlayCard

        /// <summary>
        /// Manually set the suit the next card has to be
        /// </summary>
        /// <param name="NewSuit"></param>
        public static void SetSuit (Suit NewSuit) {
            // For when an 8 is played and a suit must be manually set
            CurrentSuit = NewSuit;
        }// SetSuit

        /// <summary>
        /// Add a card to the pile, set the active card then remove it from the user hand
        /// </summary>
        /// <param name="playCard"></param>
        /// <param name="who"></param>
        public static void PlayCard(Card playCard, int who) {
            DeadCards.Add(CurrentActiveCard);
            CurrentActiveCard = playCard;
            CurrentSuit = playCard.GetSuit();
            hands[who].Remove(playCard);

            isFirstMove = false;
        }// end PlayCard
        
        /// <summary>
        /// Return the hand at that index
        /// </summary>
        /// <param name="who"></param>
        /// <returns>a Hand</returns>
        public static Hand getHand(int who) {
            return hands[who];
        }

        /// <summary>
        /// Sorts the hand at that index by suit and value
        /// </summary>
        /// <param name="who"></param>
        public static void SortHand(int who) {
            if (isGameOver() == false) {
                hands[who].Sort();
            }
        } // end SortHand

        /// <summary>
        /// Checks the state of the game. Is it over?
        /// </summary>
        public static void checkGameOver() {
            if (getHand(0).GetCount() == 0) {
                GameOver = Victor.Player;
                return;
            }

            if (getHand(1).GetCount() == 0) {
                GameOver = Victor.Computer;
                return;
            }

            // Is there a tie
            if (getHand(0).GetCount() == MAX_HAND_SIZE && getHand(1).GetCount() == MAX_HAND_SIZE) {
                if (CanPlay(0) == false && CanPlay(1) == false) {
                    GameOver = Victor.Tie;
                }
            }
        } // end checkGameOver()

        /// <summary>
        /// Returns the state of the match
        /// </summary>
        /// <returns></returns>
        public static bool isGameOver() {
            return GameOver != Victor.None;
        } // checkGameOver

        /// <summary>
        /// Returns the victor (Game state)
        /// </summary>
        /// <returns></returns>
        public static Victor getVictor() {
            return GameOver;
        } // end getVictor
    }
}
