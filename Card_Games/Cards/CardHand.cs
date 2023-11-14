using System.Data.SqlTypes;
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

        //find a pair
        for (int i = 0; i < cardHand.Count; i++)
        {
            for (int j = 0; j < cardHand.Count; j++)
            {
                if (i != j)
                {
                    if (cardHand[i].cardValue == cardHand[j].cardValue)
                    {
                        best = new PokerHandValue(cardHand[i].cardValue * 2, 2);
                    }
                }
            }
        }

        //find two pair
        for (int i = 0; i < cardHand.Count; i++)
        {
            for (int j = 0; j < cardHand.Count; j++)
            {
                if (i != j)
                {
                    //found first pair
                    if (cardHand[i].cardValue == cardHand[j].cardValue)
                    {
                        for (int k = 0; i < cardHand.Count; k++)
                        {
                            for (int l = 0; l < cardHand.Count; l++)
                            {
                                //find second pair
                                if (k != l && k != i && l != j)
                                {
                                    if (cardHand[k].cardValue == cardHand[l].cardValue)
                                    {
                                        best = new PokerHandValue(cardHand[i].cardValue * 4, 3);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //find three of a kind
        for (int i = 0; i < cardHand.Count; i++)
        {
            for (int j = 0; j < cardHand.Count; j++)
            {
                for (int k = 0; k < cardHand.Count; k++)
                {
                    if (i != j && i != k && k != j)
                    {
                        if (cardHand[i].cardValue == cardHand[j].cardValue && cardHand[i].cardValue == cardHand[k].cardValue)
                        {
                            best = new PokerHandValue(cardHand[i].cardValue * 3, 4);
                        }
                    }
                }
            }
        }

        //find straight
        int tempcount = 0;
        for (int i = 0; i + 1 < cardHand.Count; i++)
        {
            if (cardHand[i].cardValue + 1 == cardHand[i+1].cardValue)
            {
                tempcount += 1;
            }
            else
            {
                tempcount = 0;
            }

            if (tempcount == 5)
            {
                tempcount = 0;
                best = new PokerHandValue(cardHand[i - 5].cardValue * 5, 5);
            }
        }

        //find flush
        for (int i = 0; i + 1 < cardHand.Count; i++)
        {
            if (cardHand[i].cardSuit == cardHand[i + 1].cardSuit)
            {
                tempcount += 1;
            }
            else
            {
                tempcount = 0;
            }

            if (tempcount == 5)
            {
                best = new PokerHandValue(cardHand[i - 5].cardValue * 5, 6);
            }
        }

        //find fullhouse
        for (int i = 0; i < cardHand.Count; i++)
        {
            for (int j = 0; j < cardHand.Count; j++)
            {
                for (int k = 0; k < cardHand.Count; k++)
                {
                    if (i != j && i != k && j != k)
                    {
                        //found three of a kind
                        if (cardHand[i].cardValue == cardHand[j].cardValue && cardHand[i].cardValue == cardHand[k].cardValue)
                        {
                            for (int e = 0; e < cardHand.Count; e++)
                            {
                                for (int d = 0; d < cardHand.Count; d++)
                                {
                                    if (e != d && e != i && e != j && e != k && d != i && d != j && d != k)
                                    {
                                        //found pair
                                        if (cardHand[e].cardValue == cardHand[d].cardValue)
                                        {
                                            best = new PokerHandValue(cardHand[e-5].cardValue * 5, 7);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //find 4 of a kind


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
}