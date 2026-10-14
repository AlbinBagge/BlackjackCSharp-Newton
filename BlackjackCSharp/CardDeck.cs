using System;

public class CardDeck
{
	private List<Card> CardList = new List<Card>();
    private Random Random = new Random();
    private bool CutCardIsFound;

    public CardDeck()
    {
        // Initialize the deck of cards
        // Create a standard deck of 52 cards
        // Set console.OutputEncoding = System.Text.Encoding.UTF8; in Main as instructed
       

        InitializeDeck();
        shuffle();
        CutCardIsFound = false;
    }

    private void InitializeDeck()
    {
        char[] suitSymbols = { '\u2665', '\u2666', '\u2663', '\u2660' }; // Hearts, Diamonds, Clubs, Spades
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        foreach (var suit in suits)
        {
            for (int i = 0; i < ranks.Length; i++)
            {
                CardList.Add(new Card(ranks[i], suit));

                string value = ranks[i];
                int value = i + 2;
                if (value == "Ace") value = 11; // Ace
                else if (value == "Jack" || value == "Queen" || value == "King") value = 10; // Face cards
                else value = int.Parse(value); // Number cards

            }
        }
    }

    private void shuffle()
    {
        int n = CardList.Count;
        for (int i = 0; i < n; i++)
        {
            int j = Random.Next(i, n);
            var temp = CardList[i];
            CardList[i] = CardList[j];
            CardList[j] = temp;
        } 
    }
    
    //  Uppdaterad kortdragnings och kortlek logik nedan
    
    private Card DrawCard()
    {
        if (CardList.Count < 13)
        {
            CutCardFound();
        }
        
        Card drawnCard = CardList[0];
        return DrawCard;
    }

    private void CutCardFound()
    {
        Console.WriteLine("The deck is low on cards, the deck will be replaced with a new one next round.");
        CutCardIsFound = true;
    }
}
