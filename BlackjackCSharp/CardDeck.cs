using System;

public class CardDeck
{
	public List<Card> CardList = new List<Card>();
    public Random Random = new Random();
    public bool CutCardIsFound;

    public CardDeck()
    {
        // Initialize the deck of cards
        // Create a standard deck of 52 cards
        // Set console.OutputEncoding = System.Text.Encoding.UTF8; in Main as instructed
       

        InitializeDeck();
        Shuffle();
        CutCardIsFound = false;
    }

    public void InitializeDeck()
    {
        char[] suitSymbols = { '\u2665', '\u2666', '\u2663', '\u2660' }; // Hearts, Diamonds, Clubs, Spades
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        
        
            for (int s = 0; s < suitSymbols.Length; s++)
            {
                string suitName = suits[s];
                char suitSymbol = suitSymbols[s];

                for (int i = 0; i < ranks.Length; i++)
                {

                    string cardrank = ranks[i];
                    int cardvalue = 0;

                    if (cardrank == "Ace")
                    {
                        cardvalue = 11; // Ace
                    }
                    else if (cardrank == "Jack" || cardrank == "Queen" || cardrank == "King")
                    {
                        cardvalue = 10; //  face card
                    }
                    else
                    {
                        cardvalue = int.Parse(cardrank); // Number cards
                    }

                    CardList.Add(new Card(cardrank, suitName, cardvalue, suitSymbol));

                }
            }
        
    }

    public void Shuffle()
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
    
    public Card DrawCard()
    {
        if (CardList.Count < 13 && !CutCardIsFound)
        {
            CutCardFound();
        }
        
        Card drawnCard = CardList[0];
        CardList.RemoveAt(0);
        return drawnCard;
    }

    public void CutCardFound()
    {
        Console.WriteLine("The deck is low on cards, the deck will be replaced with a new one next round.");
        CutCardIsFound = true;
    }
}
