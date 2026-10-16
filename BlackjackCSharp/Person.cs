namespace BlackjackCSharp;

public abstract class Person
{
    public List<Card> Hand;
    public bool HasStood;
    public string Name;

    protected Person(string name)
    {
        Name = name;
        Hand = new List<Card>();
        HasStood = false;
    }

    public void Hit(CardDeck deck)
    {
        var drawnCard = deck.DrawCard();
        
        Hand.Add(drawnCard);
        Console.WriteLine($"{Name} hit! {Name} has goten a {drawnCard}");
        Console.WriteLine();
    }

    public void Stand()
    {
        HasStood = true;
        Console.WriteLine($"{Name} has now stood. Their final hand is:");
        Console.WriteLine();
        PrintHand();
    }

    public int CountHandValue()
    {
        return Hand.Sum(card => card.Value);
    }

    public void PrintHand()
    {
        Console.WriteLine($"{Name}'s hand:");
        foreach (var card in Hand)
        {
            Console.Write($"{card.ToString()}{" ", 2}");
        }
        Console.WriteLine();
        Console.WriteLine($"The total value of the hand is {CountHandValue()}");
    }

    public void ClearHand()
    {
        Hand.Clear();
        HasStood = false;
    }

}
