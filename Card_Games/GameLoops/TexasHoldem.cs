class TexasHoldem
{
    CardHand playerHand = new CardHand();
    CardHand houseHand = new CardHand();
    List<Cards> theDeck;
    int cardDraw = 0;

    public TexasHoldem(List<Cards> deck)
    {
        theDeck = deck;
    }

    //place holder for main game while debugging and building
    public void Test()
    {
        playerHand.AddCardToHand(theDeck[cardDraw]);
        cardDraw++;
        houseHand.AddCardToHand(theDeck[cardDraw]);
        cardDraw++;
        playerHand.AddCardToHand(theDeck[cardDraw]);
        cardDraw++;
        houseHand.AddCardToHand(theDeck[cardDraw]);

        playerHand.Sorthand();
        houseHand.Sorthand();

        Console.WriteLine("The player has!");
        for (int i = 0; i < houseHand.cardHand.Count; i++)
        {
            Console.WriteLine(playerHand.cardHand[i].cardName);
        }

        Console.WriteLine("The house has!");
        for (int i = 0; i < houseHand.cardHand.Count; i++)
        {
            Console.WriteLine(houseHand.cardHand[i].cardName);
        }
        Console.ReadLine();
        //compair poker hands
        PokerHandValue player = playerHand.CalculatePokerHand();
        PokerHandValue house = houseHand.CalculatePokerHand();
        bool answer  = player.CompairPokerHand(house);
        Console.WriteLine("The player was lager then the house: " + answer);
    }
}