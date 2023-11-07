using System.ComponentModel.Design;
using System.Runtime.InteropServices;

class BlackJackHands
{
    CardHand playerHand = new CardHand();
    CardHand houseHand = new CardHand();
    int cardDrawn = 0;
    bool playerStand = false;
    bool houseStand = false;
    public bool end = false;
    public int playerValue = 0;
    public int houseValue = 0;

    public BlackJackHands(int draw)
    {

    }

    public void PlayerHand(bool standQ, List<Cards> theDeck)
    {
        if (BustCheck(true) == true)
        {
            Console.WriteLine("You have busted over 21!");
        }
        else if (playerStand == false && standQ == false)
        {
            Console.WriteLine("You drew " + theDeck[cardDrawn].cardName);
            
            playerHand.AddCardToHand(theDeck[cardDrawn]);
            playerValue += theDeck[cardDrawn].getValue(playerValue, playerHand);
            
            Console.WriteLine("You have " + playerValue);

            cardDrawn++;
        }
        else 
        {
            this.playerStand = true;
            Console.WriteLine("You have stood with " + playerValue);
        }
    }

    public void HouseHand(List<Cards> theDeck)
    {
        if (BustCheck(false) == true)
        {
            Console.WriteLine("The house has busted over 21!");
        }

        else if ((houseValue <= 16 || playerValue >= houseValue) && BustCheck(true) == false)
        {
            Console.WriteLine("The house drew " + theDeck[cardDrawn].cardName);

            houseHand.AddCardToHand(theDeck[cardDrawn]);
            houseValue += theDeck[cardDrawn].getValue(houseValue, houseHand);
            
            Console.WriteLine("The house has " + houseValue + "\r\n");

            cardDrawn++;
        }
        else 
        {
            Console.WriteLine("The house stands with " + houseValue);
            houseStand = true;
        }

        if((houseStand == true || BustCheck(false) == true) && (playerStand == true || BustCheck(true) == true))
        {
            if(CheckWin() == true)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("You lost!");
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
                    return true;
                }
                else if(playerValue <= houseValue)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
        return false;
    }
}