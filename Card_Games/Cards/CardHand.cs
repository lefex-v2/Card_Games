using System.Data.SqlTypes;
using System.Diagnostics;
using System.Net.Http.Headers;

class CardHand
{
    public new List<Cards> cardHand = new List<Cards>();

    public CardHand()
    {

    }

    public void AddCardToHand(Cards addedCard)
    {
        cardHand.Add(addedCard);
    }

    public void RemoveCardFromHand(int cardInx)
    {
        cardHand.Remove(cardHand[cardInx]);
    }


    public int GetValueOfHandBJ()
    {
        int score = 0;
        foreach (var card in cardHand)
        {
            score += card.cardValue;
        }

        if (score > 21)
        {
            //find aces and reduce value untill score <= 21
            int numAces = CheckNameCardInHand("A");
            for (int i = 0; i < numAces; i++)
            {
                if (score > 21)
                {
                    score += -10;
                }
            }
            return score;
        }
        else
        {
            return score;
        }
    }

    public PokerHandValue CalculatePokerHand()
    {
        int tempcount = 0;
        //find high card
        Cards temp = cardHand[0];
        for (int i = 0; i < cardHand.Count; i++)
        {
            if (temp.cardValue < cardHand[i].cardValue)
            {
                temp = cardHand[i];
            }
        }

        PokerHandValue best = new PokerHandValue(temp.cardValue, 1);

        //find four of a kind, three of a kind, pair.
        int threeKind = 0;
        int numRow = 0;
        int value = 0;
        for (int i = 0; i < cardHand.Count; i++)
        {
            for (int j = i + 1; j < cardHand.Count; j++)
            {
                if (cardHand[i].cardValue == cardHand[j].cardValue)
                {
                    numRow += 1;
                    value = cardHand[i].cardValue;
                }
            }
        }

        numRow -= numRow / 2;
        
        //pair
        if (numRow >= 1)
        {
            best = new PokerHandValue(value, 2);
            Console.WriteLine("Pair");
        }

        //find two pair
        int numPairs = 0;
        int highPair = 0;
        for (aint i = 0; i < cardHand.Count; i++)
        {
            for (int j = 0; j < cardHand.Count; j++)
            {
                if (i != j)
                {
                    if (cardHand[i].cardValue == cardHand[j].cardValue)
                    {
                        numPairs++;
                        if(highPair < cardHand[i].cardValue)
                        {
                            highPair = cardHand[i].cardValue;
                        }
                    }
                }
            }
        }
        numPairs = numPairs - (numPairs/2) + 1;

        if(numPairs > 1)
        {
            best = new PokerHandValue(highPair, 3);
            Console.WriteLine("2 pair");
        }



        //three of a kind
        if (numRow == 2)
        {
            threeKind = value;
            best = new PokerHandValue(value, 4);
            Console.WriteLine("3 of kind");
        }

        //find straight
        for (int i = 0; i + 1 < cardHand.Count-4; i++)
        {
            tempcount = 0;
            int currentValue = cardHand[i].cardValue;
            for (int j = i + 1; j < cardHand.Count; j++)
            {
                if (currentValue == cardHand[j].cardValue - 1)
                {
                    currentValue = cardHand[j].cardValue;
                    tempcount += 1;
                }
            }

            if (tempcount == 5)
            {
                Console.WriteLine("Straight");
                tempcount = 0;
                best = new PokerHandValue(currentValue, 5);
            }
        }

        //find flush
        tempcount = 0;
        for (int i = 0; i + 1 < cardHand.Count-4; i++)
        {
            tempcount = 0;
            int highValue = 0;
            string currentValue = cardHand[i].cardSuit;
            for (int j = i + 1; j < cardHand.Count; j++)
            {
                if (currentValue == cardHand[j].cardSuit)
                {
                    currentValue = cardHand[j].cardSuit;
                    tempcount += 1;
                    highValue = cardHand[i].cardValue;
                }
            }

            if (tempcount == 5)
            {
                Console.WriteLine("Flush");
                best = new PokerHandValue(highValue, 6);
            }
        }

        //find fullhouse
        if(highPair > 0 && threeKind > 0 && highPair != threeKind)
        {
            Console.WriteLine("full house");
            best = new PokerHandValue(threeKind, 7);
        }

        // four of a kind
        if (numRow == 3)
        {
            Console.WriteLine("4 of kind");
            best = new PokerHandValue(value, 8);
        }
        //find straight flush

        //find royal flush

        return best;
    }

    public int CheckNameCardInHand(string cardName)
    {
        //serch for a card im my hand
        var cardsInHand = cardHand.Where(a => a.cardName.Contains(cardName));

        foreach (var card in cardsInHand)
        {
            return cardsInHand.Count();
        }
        return 0;
    }

    public void Sorthand()
    {
        Cards temp;
        for (int i = 1; i < cardHand.Count; i++)
        {
            if (cardHand[i].cardValue < cardHand[i-1].cardValue)
            {
                temp = cardHand[i-1];
                cardHand[i - 1] = cardHand[i];
                cardHand[i] = temp;
            }
        }
    }
}