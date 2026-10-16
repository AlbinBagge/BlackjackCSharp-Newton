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
        Console.WriteLine($"{Game.s_dealer.Hand[0]}"); // Print first card
        Console.WriteLine("*2nd hidden card*");

        // Give player initial cards
        Console.WriteLine();
        Game.s_player.Hit(Game.s_deck);
        Game.s_player.Hit(Game.s_deck);
        Game.s_player.PrintHand();

        // Check player hand for Blackjack (11 + 10 = 21)
        BlackjackCheck(Game.s_player);

        // Check player hand for two Aces (11 + 11 = 22)
        BustCheck(Game.s_player);
    }
    public void PlayerTurn()
    {
        while (!Game.s_player.HasStood)
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to hit or stand? (h/s)");
            string input = Console.ReadLine() ?? "";
            if (input.ToLower() == "h")
            {
                Game.s_player.Hit(Game.s_deck);
                Game.s_player.PrintHand();
                if (Game.s_player.CountHandValue() > 21)
                {
                    Console.WriteLine("Player busts! Dealer wins.");
                    return;
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

    // Check if player got Blackjack (11 + 10)
    public void BlackjackCheck(Person person)
    {
        if (person.CountHandValue() == 21)
        {
            // Win message
            Console.WriteLine($"{person.Name} win - {person.Name} has Blackjack!");
            
            // End round
            Game.s_gameActive = false;
        }
    }

    // Check if person busted (> 21)
    public void BustCheck(Person person)
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
                Console.WriteLine($"{person.Name} loss - {person.Name} has busted!");
                
                // End round
                Game.s_gameActive = false;

                break;
            }
        }
    }   

    public bool askToPlayAgain()
    {
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
            return askToPlayAgain();
        }

    public void WinCheck()
    {
        //  To simplfy and better the readability:
        var dealer = Game.s_dealer;
        var player = Game.s_player;
        
        //  Comparison
        if (dealer.CountHandValue() > player.CountHandValue())  //  Loss
        {
            Console.WriteLine($"{dealer.Name} has greater hand value, {dealer.Name} wins the round.");
        }
        else if (dealer.CountHandValue() == player.CountHandValue())    //  Draw
        {
            Console.WriteLine($"{dealer.Name} and {player.Name} has the same hand value, it's a draw.");
        }
        else   //   Win
        {
            Console.WriteLine($"{player.Name}'s hand is greater than the {dealer.Name}'s. {player.Name} wins the round.");
        }

        Game.s_gameActive = false;
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
            Console.WriteLine("CutcardisFound");
            
            foreach (var card in Game.s_deck.CardList)
            {
                Console.Write($"/////// {card.Value}      ");
            }

            Console.WriteLine();
            
            Game.s_deck = new CardDeck();

            foreach (var card in Game.s_deck.CardList)
            {
                Console.Write($"/////// {card.Value}      ");
            }
        }
    }
}
