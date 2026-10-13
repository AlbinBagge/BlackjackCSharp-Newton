using System;

public class Card
{
    public string suit { get; set; }
    public string rank { get; set; }
    public int value { get; set; }
    public Card(string suit, string rank, int value)
    {
        this.suit = suit;
        this.rank = rank;
        this.value = value;
    }
    public override string ToString()
    {
        return $"{rank} of {suit} (Value: {value})";
    }
}
   
}
