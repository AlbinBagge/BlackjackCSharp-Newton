namespace BlackjackCSharp;

public abstract class Person
{
    private List<Card> Hand;
    private bool HasStood;
    private string Name;

    protected Person(string name)
    {
        Name = name;
        Hand = new List<Card>();
        HasStood = false;
    }
    
    public void Hit()
    {
        Hand.Add(CardDeck.DrawCard());
        Console.Clear();
        Console.WriteLine($"{Name} hit! Their hand now is:");
        Console.WriteLine();

        PresentInfo();
    }

    public void Stand()
    {
        HasStood = true;
        Console.WriteLine($"{Name} has now stood. Their final hand is:");
        Console.WriteLine();
        PresentInfo();
    }

    private int CountHandValue()
    {
        int total = 0;
        
        foreach (var Card in Hand)
        {
            total += Card.value;
        }
        return total;
    }

    private void PresentInfo()
    {
        foreach (var Card in Hand)
        {
            Console.WriteLine(Card.ToString);
        }
        Console.WriteLine();
        Console.WriteLine($"The total value of the hand is {CountHandValue()}");
    }
}