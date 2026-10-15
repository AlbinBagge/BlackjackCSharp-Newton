using System.Numerics;

namespace BlackjackCSharp;

public class GameRules
{
    public GameRules()
    {
    }

    public void StartGame()
    {
        // Create instances
        CardDeck deck = new();
        Dealer dealer = new("Dealer");
        Player player = new("Player");

        DebugPrintDeck(deck); // Debug
        Console.WriteLine(); // Debug

        // Give dealer initial cards
        dealer.Hit(deck);
        dealer.Hit(deck);
        Console.WriteLine($"{dealer.Hand[0]}"); // Print first card in the hand
        Console.WriteLine("*2nd hidden card*");

        DebugPrintDeck(deck); // Debug

        // Give player initial cards
        Console.WriteLine();
        player.Hit(deck);
        player.Hit(deck);
        player.PresentInfo();

        DebugPrintDeck(deck); // Debug

        // Check for player Blackjack
        if (player.CountHandValue() == 21)
        {
            Console.WriteLine("Player win - player has Blackjack!");
        }

        // Check for loss & account for ace (two aces is 22 > 21)
    }

    // Debug: print the deck's card values
    private void DebugPrintDeck(CardDeck deck)
    {
        Console.WriteLine();
        Console.WriteLine("Debug: deck");
        foreach (Card card in deck.CardList)
        {
            Console.Write($"{card.Value,3}");
        }
        Console.WriteLine();
    }
}
