namespace BlackjackCSharp;

public class Dealer() : Person("Dealer")
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
