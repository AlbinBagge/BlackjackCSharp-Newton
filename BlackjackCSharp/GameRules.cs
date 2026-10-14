using System.Numerics;

namespace BlackjackCSharp;

internal class GameRules
{
    public GameRules()
    {
    }

    public void StartGame()
    {
        // Code:
        CardDeck deck = new();
        Dealer dealer = new("Dealer");
        Player player = new("Player");


        // PLACEHOLDER CODE

        List<int> phDeck = CreatePlaceholderDeck();
        List<int> phPlayerHand = new();
        List<int> phDealerHand = new();

        Console.WriteLine("Debug: Deck");
        PrintDeck(phDeck);

        // Deal to dealer:
        phDealerHand.Add(phDeck[0]);
        // Display card (add writeline)
        phDeck.RemoveAt(0);
        phDealerHand.Add(phDeck[0]);
        // Display an icon for hidden card
        phDeck.RemoveAt(0);

        // Deal to player:
        phPlayerHand.Add(phDeck[0]);
        // Display card
        phDeck.RemoveAt(0);
        phPlayerHand.Add(phDeck[0]);
        // Displaycard
        phDeck.RemoveAt(0);

        Console.WriteLine("Debug: Dealer hand");
        PrintHand(phDealerHand);
        Console.WriteLine("Debug: Player hand");
        PrintHand(phPlayerHand);
        Console.WriteLine("Debug: Deck");
        PrintDeck(phDeck);

        // Check for win: Blackjack (Ace + 10)
    }

    // PLACEHOLDERS METHODS

    // Placeholder: create placeholder deck
    private List<int> CreatePlaceholderDeck()
    {
        // Create placeholder deck
        List<int> placeHolderDeck = new();
        for (int i = 0; i < 4; i++)
        {
            // Add placeholder pip cards
            for (int j = 2; j <= 10; j++)
            {
                placeHolderDeck.Add(j);
            }
            // Add placeholder face cards
            for (int k = 0; k < 3; k++)
            {
                placeHolderDeck.Add(10);
            }
            // Add placeholder Ace card
            placeHolderDeck.Add(11);
        }
        return placeHolderDeck;
    }

    // Placeholder: print deck
    public void PrintDeck(List<int> deck)
    {
        foreach (int card in deck)
        {
            Console.Write($"{card, 3}");
        }
        Console.WriteLine();
    }

    // Placeholder: print hand
    public void PrintHand(List<int> hand)
    {
        foreach (int card in hand)
        {
            Console.WriteLine(card);
        }
    }
}
