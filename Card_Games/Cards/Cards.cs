using System.Transactions;
using System.Collections;
using System.Drawing;
using System.ComponentModel.DataAnnotations;


class Cards
{
    public int cardValue;
    public string cardName;
    public string cardSuit;

    public Cards(string Name, int value, string suit)
    {
        this.cardValue = value;
        this.cardName = Name;
        this.cardSuit = suit;
    }

    public bool CompareValue(Cards card)
    {
        //ture = the card that is runing is lower and if false then the card that was pasted was lower!
        if (this.cardValue >= card.cardValue)
        {
            return true;
        }
        else if (this.cardValue <= card.cardValue)
        {
            return false;
        }
        return false;
    }
}