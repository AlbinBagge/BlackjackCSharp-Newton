namespace BlackjackCSharp;

public class Card
{
    public string Suit { get; set; }
    public string Rank { get; set; }
    public int Value { get; set; }
    public char Symbol { get; set; }
    public Card(string rank, string suit, int value, char symbol)
    {
        Suit = suit;
        Rank = rank;
        Value = value;
        Symbol = symbol;
    }
    public override string ToString()
    {
        return $"{Rank}{Symbol, 1}"; 
    }
}
