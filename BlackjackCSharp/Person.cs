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
        Console.WriteLine($"{Name} hit:  {drawnCard}");
    }

    public void Stand()
    {
        HasStood = true;
        Console.WriteLine($"{Name} stood.");
    }

    public int CountHandValue()
    {
        return Hand.Sum(card => card.Value);
    }

    public void PrintHand()
    {
        Console.Write($"{Name}'s hand:  ");
        foreach (var card in Hand)
        {
            Console.Write($"{card.ToString()}  ");
        }
        Console.WriteLine();
        Console.WriteLine($"The total value of the hand is:  {CountHandValue()}");
    }

    public void ClearHand()
    {
        Hand.Clear();
        HasStood = false;
    }

}
