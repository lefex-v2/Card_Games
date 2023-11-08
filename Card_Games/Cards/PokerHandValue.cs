using System.Data.SqlTypes;

class PokerHandValue
{
    public int handType = 0;
    public int score = 0;

    public PokerHandValue(int score, int handType)
    {
        this.handType = handType;
        this.score = score;
    }

    public bool CompairPokerHand(PokerHandValue oponentHand)
    {
        if(handType == oponentHand.handType)
        {
            if (score >= oponentHand.score)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if(handType > oponentHand.handType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}