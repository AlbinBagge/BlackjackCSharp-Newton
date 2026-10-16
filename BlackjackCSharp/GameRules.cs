namespace BlackjackCSharp;

public class GameRules
{
    public GameRules()
    {
    }

    public void StartGame()
    {
        Console.Clear();
        
        // Give dealer initial cards
        Game.s_dealer.Hit(Game.s_deck);
        Game.s_dealer.Hand.Add(Game.s_deck.DrawCard());
        Console.WriteLine($"{Game.s_dealer.Name} got a hidden card.");

        // Print dealer's hand
        Console.WriteLine($"{Game.s_dealer.Name}'s hand:  {Game.s_dealer.Hand[0]}  *Hidden card*");

        // Give player initial cards
        Console.WriteLine();
        Game.s_player.Hit(Game.s_deck);
        Game.s_player.Hit(Game.s_deck);

        // Change the value of an ace if the player would otherwise bust (11 + 11 > 21)
        BustCheck(Game.s_player);

        // Print player's hand
        Game.s_player.PrintHand();

        // Check if player got Blackjack (11 + 10 == 21)
        BlackjackCheck(Game.s_player);
    }
    public void PlayerTurn()
    {
        while (Game.s_gameActive && !Game.s_player.HasStood)
        {
            Console.WriteLine();
            Console.WriteLine($"Would {Game.s_player.Name} like to hit or stand? (h/s)");
            string input = Console.ReadLine() ?? "";
            if (input.ToLower() == "h")
            {
                Game.s_player.Hit(Game.s_deck);
                if (!BustCheck(Game.s_player))
                {
                    Game.s_player.PrintHand();
                }
            }
            else if (input.ToLower() == "s")
            {
                Game.s_player.Stand();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'h' to hit or 's' to stand.");
            }
        }
    }

    public void DealerTurn()
    {
        Console.WriteLine();
        Console.WriteLine($"Dealer's hidden card is revealed. It is {Game.s_dealer.Hand[1].ToString()}.");

        // Return method early if dealer got Blackjack
        if (BlackjackCheck(Game.s_dealer))
        {
            return;
        }
        
        //  Thread.Sleep

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
        }
        while (!Game.s_dealer.HasStood);
        
        // Check if dealer busted
        if (!BustCheck(Game.s_dealer))
        {
            Game.s_dealer.PrintHand(); // Print hand if dealer didn't bust
            Console.WriteLine();
        }
    }

    public void WinCheck()
    {
        //  To simplfy and better the readability:
        var dealer = Game.s_dealer;
        var player = Game.s_player;

        //  Comparison
        if (dealer.CountHandValue() > player.CountHandValue())  //  Loss
        {
            Console.WriteLine($"{dealer.Name} has a greater hand value. {dealer.Name} wins the round.");
        }
        else if (dealer.CountHandValue() == player.CountHandValue())    //  Draw
        {
            Console.WriteLine($"{dealer.Name} and {player.Name} has the same hand value. It's a draw.");
        }
        else   //   Win
        {
            Console.WriteLine($"{player.Name}'s hand is greater than the {dealer.Name}'s. {player.Name} wins the round.");
        }

        Game.s_gameActive = false;
    }

    // Check if player got Blackjack (11 + 10)
    public bool BlackjackCheck(Person person)
    {
        if (person.Hand.Any(card => card.Value == 11) && person.Hand.Any(card => card.Value == 10))
        {
            // Win message
            Console.WriteLine();
            Console.WriteLine($"{person.Name} win - {person.Name} got Blackjack!");       
        
            // End round
            Game.s_gameActive = false;

            return true;
        }

        return false;
    }

    // Check if person busted (> 21)
    public bool BustCheck(Person person)
    {
        while (person.CountHandValue() > 21)
        {
            // If the person has any Aces
            if (person.Hand.Any(card => card.Value == 11))
            {
                // Change the value of one Ace from 11 to 1
                int index = person.Hand.FindIndex(card => card.Value == 11);
                Card newCard = person.Hand[index];
                newCard.Value = 1;
                person.Hand[index] = newCard;
            }
            else
            {
                // Bust message
                person.PrintHand();
                Console.WriteLine();
                Console.WriteLine($"{person.Name} loss - {person.Name} busted!");
                
                // End round
                Game.s_gameActive = false;

                return true; ;
            }
        }

        return false;
    }

    public bool AskToPlayAgain()
    {
        Console.WriteLine();
        Console.WriteLine("Would you like to play again? (y/n)");
        string answer = Console.ReadLine() ?? "";
        if (answer.ToLower() == "y")
        {
            return true; //loopgame();
        }
        else if (answer.ToLower() == "n")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter 'y' to play again or 'n' to exit.");
            return AskToPlayAgain();
        }
    }

    public void ResetHands()
    {
        Game.s_dealer.ClearHand();
        Game.s_player.ClearHand();
    }

    public void ResetCardDeck()
    {
        if (Game.s_deck.CutCardIsFound)
        {            
            Game.s_deck = new CardDeck();
        }
    }
    
    public void welcomeMessage()
    {
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine("                                                   WELCOME TO BLACKJACK                                                         ");
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine();
    }
    public void exitMessage()
    {
        Console.WriteLine();
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine("                                                   THANK YOU FOR PLAYING!                                                         ");
        Console.WriteLine("================================================================================================================================");
    }
    public void displayRules()
    {
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine("                                                   GAME RULES                                                                   ");
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine("1. The game is played with a standard deck of 52 cards.");
        Console.WriteLine("2. The goal of the game is to beat the dealer by having a hand value closer to 21 than the dealer's hand value without going over 21.");
        Console.WriteLine("3. Each player is dealt two cards, and the dealer is dealt one card face up and one card face down.");
        Console.WriteLine("4. Players can choose to 'hit' (draw another card) or 'stand' (keep their current hand).");
        Console.WriteLine("5. If a player's hand value exceeds 21, they bust and lose the round.");
        Console.WriteLine("6. The dealer must hit until their hand value is at least 17.");
        Console.WriteLine("7. If the dealer busts, all remaining players win the round.");
        Console.WriteLine("8. If a player has a hand value of 21 with their first two cards (an Ace and a 10-value card), they have Blackjack and win the round unless the dealer also has Blackjack.");
        Console.WriteLine("9. If both the player and dealer have the same hand value, it is a draw.");
        Console.WriteLine();
    }
    public void displayControls()
    {
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine("                                                   GAME CONTROLS                                                                ");
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine("1. To hit, type 'h' and press Enter.");
        Console.WriteLine("2. To stand, type 's' and press Enter.");
        Console.WriteLine("3. To play again after a round, type 'y' and press Enter.");
        Console.WriteLine("4. To exit the game after a round, type 'n' and press Enter.");
        Console.WriteLine();
    }
}
