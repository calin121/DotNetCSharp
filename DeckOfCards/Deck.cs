using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack {
    public class Deck {
        public List<Card> cards = new List<Card>();

        public Deck() {
            BuildDeck();
        }
        public void BuildDeck() {
            string[] Suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
            string[] Vals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"}
            
            for (int i = 0; i < Suits.Length; i++) {
                for(int j = 0; j < Vals.Length; j++) {
                    cards.Add(new Card(Suits[i], Vals[j], j+1));
                }
            }
        }
        public Card Deal() {
            Card card = cards.First();
            cards.RemoveAt(0);
            return card;
        }
        public Deck Shuffle() {
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++) {
                int randIdx = rand.Next(i, cards.Count);
                Card temp = cards[randIdx];
                cards[randIdx] = cards[i];
                cards[i] = temp;
            }
            return this;
        }
    }
    
}