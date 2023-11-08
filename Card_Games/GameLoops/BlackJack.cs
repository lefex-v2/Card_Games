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

        if (playerStand == false && standQ == false && BustCheck(true) == false)
        {
            Console.WriteLine("You drew " + theDeck[cardDrawn].cardName);
            
            playerHand.AddCardToHand(theDeck[cardDrawn]);
            playerValue = playerHand.GetValueOfHandBJ();
            
            Console.WriteLine("You have " + playerValue + "\r\n");

            cardDrawn++;
        }
        else 
        {
            this.playerStand = true;
            Console.WriteLine("You have stood with " + playerValue);
        }

        if (BustCheck(true) == true)
        {
            Console.WriteLine("You have busted over 21!\r\n");
        }
    }

    public void HouseHand(List<Cards> theDeck)
    {
        if ((houseValue <= 16 && playerStand == false || playerValue >= houseValue) && BustCheck(true) == false && houseStand == false && BustCheck(false) == false)
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

        if (BustCheck(false) == true)
        {
            Console.WriteLine("The house has busted over 21!\r\n");
        }

        if ((houseStand == true || BustCheck(false) == true) && (playerStand == true || BustCheck(true) == true))
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