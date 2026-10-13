namespace BlackjackCSharp;

public abstract class Person
{
    public List<Card> Hand { get; set; }
    public bool HasStood { get; set; }
    public string Name { get; set; }

    protected Person(string name)
    {
        Name = name;
        Hand = new List<Card>();
        HasStood = false;
    }
    
    public void Hit(CardDeck drawDeck, CardDeck usedCard)
    {
        Hand.Add(cardDeck.DrawCard(drawDeck, usedCard));
    }

    public void Stand()
    {
        HasStood = true;
    }

    public int CountHandValue()
    {
        int total = 0;
        
        foreach (var Card in Hand)
        {
            total += Card.value;
        }

        return total;
    } 
}