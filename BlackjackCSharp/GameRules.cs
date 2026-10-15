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

        DebugPrintDeck(); // Debug
        Console.WriteLine(); // Debug

        // Give Game.dealer initial cards
        Game.s_dealer.Hit(Game.s_deck);
        Game.s_dealer.Hit(Game.s_deck);
        Console.WriteLine($"{Game.s_dealer.Hand[0]}"); // Print first card in the hand
        Console.WriteLine("*2nd hidden card*");

        DebugPrintDeck(); // Debug

        // Give player initial cards
        Console.WriteLine();
        Game.s_player.Hit(Game.s_deck);
        Game.s_player.Hit(Game.s_deck);
        Game.s_player.PresentInfo();

        DebugPrintDeck(); // Debug

        // Check for player Blackjack
        if (Game.s_player.CountHandValue() == 21)
        {
            Console.WriteLine("Player win - player has Blackjack!");
        }

        // Check for loss & account for ace (two aces is 22 > 21)
    }

    // Debug: print the Game.deck's card values
    private void DebugPrintDeck()
    {
        Console.WriteLine();
        Console.WriteLine("Debug: deck");
        foreach (Card card in Game.s_deck.CardList)
        {
            Console.Write($"{card.Value,3}");
        }
        Console.WriteLine();
    }

    public void DealerTurn()
    {
        do
        {
            if (Game.s_dealer.DealerCanDraw())
            {
                Game.s_dealer.Hit(Game.s_deck);
            }
            else
            {
                Game.s_dealer.Stand();
            }
        } while (!Game.s_dealer.HasStood);
    }
}
