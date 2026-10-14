using System;

public class Card
{
    public string Suit { get; set; }
    public string Rank { get; set; }
    public int Value { get; set; }
    public char Symbole { get; set; }
    public Card(string rank, string suit, int value, char symbole)
    {
        Suit = suit;
        Rank = rank;
        Value = value;
        Symbole = symbole;
    }
    public override string ToString()
    {
        return $"{rank} of {suit} {symbole} (Value: {value})";
    }
}
