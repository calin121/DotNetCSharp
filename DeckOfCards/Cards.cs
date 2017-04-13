namespace BlackJack {
    public class Card {
        public string StringVal {get; set; }
        public string Suit {get; set; }
        public int Val {get; set; }

        public Card(string suit, string stringval, int val) {
            Suit = suit;
            StringVal = stringval;
            Val = val;
        }
    }
}