using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public class Crazy_Eights_Game {

        // Initial Variables
        static protected CardPile DrawCards;
        static protected CardPile DeadCards;
        static protected Card CurrentActiveCard; // Current top of played cards
        static protected Hand[] hands; // Hand[0] is the Player
        static protected Suit CurrentSuit;
        static protected bool isFirstMove; 

        public static void SetupGame() {
            hands = new Hand[2] { new Hand(), new Hand() };

            isFirstMove = true;
            DrawCards = new CardPile(true);
            DeadCards = new CardPile();
            DrawCards.Shuffle();

            CurrentActiveCard = new Card(Suit.Clubs, FaceValue.Eight);
        }

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
        }

        public static Card GetCurrentActiveCard() {
            return CurrentActiveCard;
        }

        public static void RolloverDeadCards() {
            DrawCards = DeadCards;
            DrawCards.Shuffle();
        }

        public static void DealInitialHands() {
            hands = new Hand[2] { new Hand(DrawCards.DealCards(8)), new Hand(DrawCards.DealCards(8)) };
        }

        public static void DealCard(int who) {
            hands[who].Add(DrawCards.DealOneCard());
            if (DrawCards.GetCount() == 0) { // If that was the last card in the draw pile
                RolloverDeadCards();
            }
        }

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
        }

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
        }

        public static void SetSuit (Suit NewSuit) {
            // For when an 8 is played and a suit must be manually set
            CurrentSuit = NewSuit;
        }

        public static void PlayCard(Card playCard, int who) {
            DeadCards.Add(CurrentActiveCard);
            CurrentActiveCard = playCard;
            CurrentSuit = playCard.GetSuit();
            hands[who].Remove(playCard);

            isFirstMove = false;
        }

        public static Hand getHand(int who) {
            return hands[who];
        }

        public static void SortHand(int who) {
            hands[who].Sort();
        }
    }
}
