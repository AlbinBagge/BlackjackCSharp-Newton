using System.Numerics;

namespace BlackjackCSharp;

public class GameRules
{
    public GameRules()
    {
    }

    public void StartGame()
    {
        // Give dealer initial cards
        Game.s_dealer.Hit(Game.s_deck);
        Game.s_dealer.Hit(Game.s_deck);
        Console.WriteLine($"{Game.s_dealer.Hand[0]}"); // Print first card in the hand
        Console.WriteLine("*2nd hidden card*");

        // Give player initial cards
        Console.WriteLine();
        Game.s_player.Hit(Game.s_deck);
        Game.s_player.Hit(Game.s_deck);
        Game.s_player.PresentInfo();

        //BustCheck();
        BlackjackCheck();
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

    // Check if the player got Blackjack (11 + 10)
    public void BlackjackCheck()
    {
        if (Game.s_player.CountHandValue() == 21)
        {
            Console.WriteLine("Player win - player has Blackjack!");
            Game.s_gameActive = false;
        }
    }
}
