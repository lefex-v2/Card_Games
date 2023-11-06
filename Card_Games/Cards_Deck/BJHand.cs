using System.ComponentModel.Design;
using System.Runtime.InteropServices;

class BlackJackHands
{
    Deck allCards = new Deck();
    int drawAmount = 0;
    int cardDrawn = 0;
    public bool end = false;
    public int playerValue = 0;
    public int houseValue = 0;

    public BlackJackHands(int draw)
    {
        this.drawAmount = draw;
        allCards.ShuffleDeck();
    }

    public void PlayerHand(bool playerStand)
    {
        if (BustCheck(true) == true)
        {
            Console.WriteLine("You have busted over 21!");
        }
        else if (playerStand == false)
        {
            Console.WriteLine("You drew " + allCards.deck[cardDrawn].cardName);
            playerValue += allCards.deck[cardDrawn].cardValue;
            Console.WriteLine("You have " + playerValue);

            cardDrawn++;
        }
        else 
        {
            Console.WriteLine("You have stood with " + playerValue);
        }
    }

    public void HouseHand()
    {
        if (BustCheck(false) == true)
        {
            Console.WriteLine("The house has busted over 21!");
        }

        else if (houseValue <= 16)
        {
            Console.WriteLine("The house drew " + allCards.deck[cardDrawn].cardName);
            houseValue += allCards.deck[cardDrawn].cardValue;
            Console.WriteLine("The house has " + houseValue);

            cardDrawn++;
        }
        else 
        {
            Console.WriteLine("The house stands with " + houseValue);
        }
    }

    bool BustCheck(bool player)
    {
        if(player)
        {
            if(playerValue > 21)
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
            if (houseValue > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool CheckWin()
    {
        return true;
    }
}