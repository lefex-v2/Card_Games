
class GameLoop
{
    public int money = 1000;
    public void HigherOrLower()
    {
        Dev dev = new Dev();
        Deck allCards = new Deck();

        Console.WriteLine("This game is a higher or lower card game!");
        Console.WriteLine("You can pick higher or lower with H and L! (Q to quit!) \r\n");
        Console.WriteLine("You have " + money + " money");

        allCards.deck = allCards.ShuffleDeck(allCards.deck);

        int points = 0;
        int cinx = 0;
        string HorL = string.Empty;
        bool exit = false;
        int bet = 0;



        while(true)
        {
            if (money <= 0)
            {
                Console.WriteLine("You can kill youself... type k ...");
            }
            else
            {
                Console.WriteLine("How much do you want to bet?");
            }

            while (true && money > 0)
            {
                string temp = Console.ReadLine();
                bool temp1 = int.TryParse(temp, out bet);

                if (temp == "q" || temp == "Q")
                {
                    exit = true;
                    break;
                }
                if (temp1 == true && bet <= money)
                {
                    break;
                }
            }

            if(exit)
            {
                break;
            }
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
                else if ((d == "k" || d == "K") && money <= 0)
                {
                    Console.WriteLine("You pulled the trigger...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }

            if (exit == true)
            {
                break;
            }

            Console.Clear();

            bool yes = allCards.deck[cinx + 1].CompareValue(allCards.deck[cinx]);

            if (yes && (HorL == "h" || HorL == "H"))
            {
                money += bet;
                Console.WriteLine("You were right! The card was {0}, and it was agents {1}.", allCards.deck[cinx].cardName, allCards.deck[cinx + 1].cardName);
                Console.WriteLine("You have " + money + " money!");
            }
            else if (!yes && (HorL == "l" || HorL == "L"))
            {
                money += bet;
                Console.WriteLine("You were right! The card was {0}, and it was agents {1}.", allCards.deck[cinx].cardName, allCards.deck[cinx + 1].cardName);
                Console.WriteLine("You have " + money + " money!");
            }
            else
            {
                money -= bet;
                Console.WriteLine("That was wrong! The card was {0}, and it was agents {1}.", allCards.deck[cinx].cardName, allCards.deck[cinx + 1].cardName);
                Console.WriteLine("You have " + money + " money!");
            }
            cinx += 2;

            if (cinx >= allCards.deck.Count - 1)
            {
                Console.Clear();
                Console.WriteLine("The game is over!");
                Console.WriteLine("You have " + money + " money!");
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

        Console.WriteLine("This is blackjack!\r\nYou need to get as close to 21 as possible with the value of cards!\r\nBut don't go over or you bust!\r\nYou have " + money + " dollers\r\nPress Q to exit!\r\n");

        BlackJackHands deck = new BlackJackHands(1);

        deck.dev.money = money;
        string choice = string.Empty;
        bool stand = false;
        int bet = 0;

        if (money <= 0)
        {
            Console.WriteLine("You can kill youself... type k ...\r\n");
        }
        else
        {
            Console.WriteLine("How much do you want to bet?");
        }

        while (true && money > 0)
        {
            choice = Console.ReadLine();
            bool temp = int.TryParse(choice, out bet);

            if(choice == "q" || choice == "Q")
            {
                deck.end = true;
                break;
            }
            if (temp == true && bet <= money)
            {
                deck.betAmount = bet;
                break;
            }
        }

        while (true)
        {
            if (deck.end == true)
            {
                break;
            
            }
            deck.HouseHand(allCards.bjdeck);

            if (deck.end == true)
            {
                money = deck.dev.money;
                Console.ReadLine();
                Console.Clear();
                BlackJack();
            }

            if (stand == false && money > 0)
            {
                Console.WriteLine("It is your turn to draw!\r\n");
                Console.WriteLine("Stand or hit (S for stand and H for hit)");
                Console.WriteLine("You have " + deck.playerValue);
            }

            bool loop = true;
            while (loop && stand == false)
            {
                choice = Console.ReadLine();

                if ((choice == "H" || choice == "h" || choice == "s" || choice == "S" || choice == "q" || choice == "Q") && money > 0)
                {
                    loop = false;
                }

                if (choice == "q" || choice == "Q")
                {
                    Console.Clear();
                    deck.end = true;
                    break;
                }
                else if ((choice == "k" || choice == "K") && money <= 0)
                {
                    Console.WriteLine("You pulled the trigger...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            if (deck.end == true)
            {
                break;
            }
            if (choice == "H" || choice == "h" && stand == false)
            {
                Console.Clear();
                deck.PlayerHand(false, allCards.bjdeck);
            }
            else if ((choice == "s" || choice == "S") && stand == false)
            {
                Console.Clear();
                deck.PlayerHand(true, allCards.bjdeck);
                stand = true;
            }

            if (stand)
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
    public void TexHoldPoker()
    { 
        Deck allCards = new Deck();
        //allCards.deck = allCards.ShuffleDeck(allCards.deck);
        TexasHoldem game = new TexasHoldem(allCards.deck);

        Console.WriteLine("This is Texas Holdem! \r\n It is a poker game with the standard poker hands.\r\n First both players get 2 cards!\r\n Over 5 rounds 5 new cards will be added drawn face up for all to use!\r\n Have fun!");

        Console.ReadLine();
        
        game.Test();
           
        Console.ReadLine();
    }
}
