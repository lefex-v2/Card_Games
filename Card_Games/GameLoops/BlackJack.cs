using System.ComponentModel.Design;
using System.Runtime.InteropServices;

class BlackJackHands
{
    CardHand playerHand = new CardHand();
    CardHand houseHand = new CardHand();
    public Dev dev = new Dev();
    int cardDrawn = 0;
    bool playerStand = false;
    bool houseStand = false;
    public bool end = false;
    public int betAmount = 100;
    public int playerValue = 0;
    public int houseValue = 0;

    public BlackJackHands(int draw)
    {

    }

    public void PlayerHand(bool standQ, List<Cards> theDeck)
    {
        //check if you can hit or force stand
        if (playerStand == false && standQ == false && BustCheck(true) == false)
        {
            Console.WriteLine("You drew " + theDeck[cardDrawn].cardName);
            
            playerHand.AddCardToHand(theDeck[cardDrawn]);
            playerValue = playerHand.GetValueOfHandBJ();
            
            Console.WriteLine("You have " + playerValue + "\r\n");

            cardDrawn++;
        }
        //if you stood
        else 
        {
            this.playerStand = true;
            Console.WriteLine("You have stood with " + playerValue);
        }

        //if oyu busted
        if (BustCheck(true) == true)
        {
            Console.WriteLine("You have busted over 21!\r\n");
        }
    }

    public void HouseHand(List<Cards> theDeck)
    {
        //checking if the house should hit or stand
        if (houseValue < 17 && BustCheck(false) == false && BustCheck(true) == false && (playerValue > houseValue && playerStand == true || playerStand == false))
        {
            Console.WriteLine("The house drew " + theDeck[cardDrawn].cardName);

            houseHand.AddCardToHand(theDeck[cardDrawn]);
            houseValue = houseHand.GetValueOfHandBJ();

            Console.WriteLine("The house has " + houseValue + "\r\n");

            cardDrawn++;
        }
        
        else if (BustCheck(false) == false)
        {
            Console.WriteLine("The house stands with " + houseValue);
            houseStand = true;
        }
        //if the house busteted its forced to do nothing
        if (BustCheck(false) == true)
        {
            Console.WriteLine("The house has busted over 21!\r\n");
        }
        //check win
        if ((houseStand == true || BustCheck(false) == true) && (playerStand == true || BustCheck(true) == true))
        {
            if(CheckWin() == true)
            {
                Console.WriteLine("You win!");
                Console.WriteLine("Money is " + dev.money);

            }
            else
            {
                Console.WriteLine("You lost!");
                Console.WriteLine("Money is " + dev.money);
            }
            end = true;
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
        if(BustCheck(true) == false)
        {
            if (BustCheck(false) == false)
            {
                if(playerValue > houseValue)
                {
                    dev.money += betAmount;
                    return true;
                }
                else if(playerValue <= houseValue)
                {
                    dev.money -= betAmount;
                    return false;
                }
            }
            else
            {
                dev.money += betAmount;
                return true;
            }
        }
        else
        {
            dev.money -= betAmount;
            return false;
        }
        dev.money -= betAmount;
        return false;
    }
}