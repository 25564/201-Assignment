using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Low_Level_Objects_Library {
    public class Hand : IEnumerable {
        // List of cards
        private List<Card> hand = new List<Card>();

        // Empty Constructur
        public Hand() {
        }

        // Constructor with parameters
        public Hand(List<Card> cards) {
            this.hand = cards;
        }

        // Return number of cards in the hand
        public int GetCount() {
            return this.hand.Count;
        }

        // Return the card at the a certain position indexing from 0
        public Card GetCard(int index) {
            return this.hand.ElementAt(index);
        }

        // Append a card to the end of the hand
        public void Add(Card card) {
            this.hand.Add(card);
        }

        // Return true if the card is in the current hand
        public bool Contains(Card card) {
            return this.hand.Contains(card);
        }

        // Removes a specific card from the hand
        public bool Remove(Card card) {
            return this.hand.Remove(card);
        }

        // Removes card at position
        public void RemoveAt(int index) {
            this.hand.RemoveAt(index);
        }

        // Sorts the hand
        public void Sort() {
            this.hand.Sort();
        }

        // Interface method
        public IEnumerator GetEnumerator() {
            return hand.GetEnumerator();
        }
    }
}
