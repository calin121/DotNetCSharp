using System;

namespace BlackJack {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Let's Play Some BlackJack!");
            Deck MyDeck = New Deck();
            Card DealCard = Mydeck.Deal();
            Card DealCard1 = MyDeck.Deal();
            Card DealCard2 = MyDeck.Deal();
            System.Console.WriteLine(MyDeck);
            Player Donovan - New Player("Donovan");
            System.Console.WriteLine(Donavan.Name);
            
        }
    }
}
