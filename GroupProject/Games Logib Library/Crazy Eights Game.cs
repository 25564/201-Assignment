using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    class Crazy_Eights_Game {

        // Initial Variables
        static protected CardPile DrawCards;
        static protected CardPile DeadCards;
        static protected Card CurrentActiveCard; // Current top of played cards
        static protected Hand[] hands; // Hand[0] is the Player
        static protected Suit CurrentSuit;

        public static void SetupGame() {
            hands = new Hand[2] { new Hand(), new Hand() };

            DrawCards = new CardPile(true);
            DeadCards = new CardPile();
            DrawCards.Shuffle();

            CurrentActiveCard = new Card(Suit.Clubs, FaceValue.Eight);
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
            foreach (Card currentCard in hands[who]) {
                if (CanPlayCard(currentCard)) {
                    return true;
                }
            }
            return false;
        }

        public static bool CanPlayCard(Card Attempt) {
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
        }
    }
}
