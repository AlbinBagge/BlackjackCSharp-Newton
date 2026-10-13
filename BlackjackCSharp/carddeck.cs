using System;

public class CardDeck
{
	private List<Card> cardlist = new List<Card>();
    private Random random = new Random();

    public CardDeck()
    {
        // Initialize the deck of cards
        // Create a standard deck of 52 cards
        // Set console.OutputEncoding = System.Text.Encoding.UTF8; in Main as instructed
       

        InitializeDeck();
        shuffle();
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
                cardlist.Add(new Card(ranks[i], suit));

                string value = ranks[i];
                int value = i + 2;
                if (value == "Ace") value = 11; // Ace
                else if (value == "Jack" || value == "Queen" || value == "King") value = 10; // Face cards
                else value = int.Parse(value); // Number cards

            }
        }
    private void shuffle()
    {
        int n = cardlist.Count;
        for (int i = 0; i < n; i++)
        {
            int j = random.Next(i, n);
            var temp = cardlist[i];
            cardlist[i] = cardlist[j];
            cardlist[j] = temp;
        }
    }

    }
    private void drawCard()
    {

    if (cardlist.Count > 13)


    else
    {


                Console.WriteLine("Deck is low on cards. Please reshuffle the deck.");
                CardDeck Deck1 = new CardDeck(); // make new deck shuffle
                for (int i = 0; i < 39; i++)
                {
                    cardlist.Add(Deck1.cardlist[i]);
                }
                
    }
    return drawCard

    






}

}
