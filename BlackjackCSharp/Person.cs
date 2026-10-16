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
        PresentInfo();
    }

    public int CountHandValue()
    {
        return Hand.Sum(Card => Card.Value);
    }

    public void PresentInfo()
    {
        Console.WriteLine($"{Name}'s hand:");
        foreach (var Card in Hand)
        {
            Console.WriteLine(Card.ToString());
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
