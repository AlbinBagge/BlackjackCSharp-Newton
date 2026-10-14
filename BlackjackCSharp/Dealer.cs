namespace BlackjackCSharp;

public class Dealer : Person
{
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