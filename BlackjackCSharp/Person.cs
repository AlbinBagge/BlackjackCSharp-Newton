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
        Hand.Add(deck.DrawCard());
        //Console.Clear();
        //Console.WriteLine($"{Name} hit! Their hand is now:");
        Console.WriteLine($"{Name} hit!");
        //Console.WriteLine();

        //PresentInfo();
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
            Console.WriteLine(card.ToString());
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
