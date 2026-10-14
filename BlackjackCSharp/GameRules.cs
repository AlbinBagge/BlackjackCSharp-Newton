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

        // Give dealer initial cards
        dealer.Hit(deck);
        dealer.Hit(deck);
        dealer.PresentInfo(); // Should display one card
        Console.ReadKey();

        // Give player initial cards
        Console.WriteLine();
        player.Hit(deck);
        player.Hit(deck);
        player.PresentInfo();
        Console.ReadKey();

        // Check for player Blackjack
    }
}
