
class GameLoop
{
    public void HigherOrLower()
    {

        Deck allCards = new Deck();

        Console.WriteLine("This game is a higher or lower card game!");
        Console.WriteLine("You can pick higher or lower with H and L! (Q to quit!) \r\n");

        allCards.deck = allCards.ShuffleDeck(allCards.deck);

        int points = 0;
        int cinx = 0;
        string HorL = string.Empty;
        bool exit = false;

        while (true)
        {
            Console.WriteLine(allCards.deck[cinx].cardName + "\r\n");
            Console.WriteLine("Higher or lower?");

            
            bool loop = true;
            while (loop == true)
            {
                string d = Console.ReadLine();
                if (d == "H" || d == "h" || d == "l" || d == "L")
                {
                    HorL = d;
                    loop = false;
                }
                else if (d == "Q" || d == "q")
                {
                    exit = true;
                    break;
                }
            }

            if(exit == true)
            {
                break;
            }

            Console.Clear();

            bool yes = allCards.deck[cinx + 1].CompareValue(allCards.deck[cinx]);

            if (yes && (HorL == "h" || HorL == "H"))
            {
                points++;
                Console.WriteLine("You where right! The card was {0}, and it was agents {1}.", allCards.deck[cinx].cardName, allCards.deck[cinx + 1].cardName);
                Console.WriteLine("You have " + points + " points!");
            }
            else if (!yes && (HorL == "l" || HorL == "L"))
            {
                points++;
                Console.WriteLine("You where right! The card was {0}, and it was agents {1}.", allCards.deck[cinx].cardName, allCards.deck[cinx + 1].cardName);
                Console.WriteLine("You have " + points + " points!");
            }
            else
            {
                Console.WriteLine("That was wrong! The card was {0}, and it was agents {1}.", allCards.deck[cinx].cardName, allCards.deck[cinx + 1].cardName);
            }
            cinx += 2;

            if (cinx >= allCards.deck.Count - 1)
            {
                Console.Clear();
                Console.WriteLine("The game is over!");
                Console.WriteLine("You have " + points + " points!");
                break;
            }
        }
        Console.WriteLine("Press enter to exit!");
        Console.ReadLine();
        Console.Clear();
    }

    public void BlackJack()
    {
        Deck allCards = new Deck();
        allCards.bjdeck = allCards.ShuffleDeck(allCards.bjdeck);

        Console.WriteLine("This is blackjack!\r\nYou need to get as close to 21 as possible with the value of cards!\r\nBut don't go over or you bust!\r\n");

        BlackJackHands deck = new BlackJackHands(1);
        string choice = string.Empty;
        bool stand = false;
        while (true)
        {
            deck.HouseHand(allCards.bjdeck);

            if (deck.end == true)
            {
                break;
            }

            if(stand == false)
            {
                Console.WriteLine("It is your turn to draw!\r\n");
                Console.WriteLine("Stand or hit (S for stand and H for hit)");
                Console.WriteLine("You have " + deck.playerValue);
            }
  

            bool loop = true;
            while (loop && stand == false)
            {
                choice = Console.ReadLine();

                if (choice == "H"|| choice == "h"|| choice == "s"|| choice == "S")
                {
                    loop = false;
                }
            }

            if (choice == "H" || choice == "h" && stand == false)
            {
                Console.Clear();
                deck.PlayerHand(false, allCards.bjdeck);
            }
            else if((choice == "s" || choice == "S") && stand == false)
            {
                Console.Clear();
                deck.PlayerHand(true, allCards.bjdeck);
                stand = true;
            }   

            if(stand)
            {
                Console.WriteLine("Press enter to continue!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        Console.WriteLine("Press enter to exit!");
        Console.ReadLine();
        Console.Clear();
    }
}
