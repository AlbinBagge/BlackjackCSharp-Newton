namespace BlackjackCSharp;

public class Dealer : Person
{
    public Dealer(string name) : base(name)
    {
    }

    public bool DealerCanDraw()
    {
        if (CountHandValue() >= 17)
        {
            return false;
        }
        else
        {
            return true;   
        }
    }
}