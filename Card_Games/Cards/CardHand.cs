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