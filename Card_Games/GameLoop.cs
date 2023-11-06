
class GameLoop
{
    public void HigherOrLower()
    {

        Deck allCards = new Deck();

        Console.WriteLine("This game is a higher or lower card game!");
        Console.WriteLine("You can pick higher or lower with H and L! (Q to quit!) \r\n");

        allCards.ShuffleDeck();

        int points = 0;
        int cinx = 0;
        string HorL = string.Empty;

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
                if (d == "Q" || d == "q")
                {
                    Environment.Exit(0);
                }
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
                Console.WriteLine("The game is over!!!!11!1!");
                Console.WriteLine("You have " + points + " points!");
                break;
            }
        }
        Console.WriteLine("Press enter to exit!");
        Console.ReadLine();
    }
}
