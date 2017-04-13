using System;
using System.Collections.Generic;

namespace BlackJack {
    public class Player {
        public string Name {get; set; }
        public List<Card> Hand { get; set; }

        public PLayer(string name) {
            Name = name;
            Hand - new List<Card>();
        }

        public Card Draw(Deck deck) {
            Card DealtCard = deck.Deal();
            Hand.Add(DealtCard);
            Return DealtCard;
        }
        
        public Card Discard(int idx) {
            idx--;
            if(idx >= Hand.Count || idx < 0){
                return null;
            }
            Card DiscardedCard = Hand[idx];
            Hand.RemoveAt(idx);
            return DiscardedCard;
        }
    }
}