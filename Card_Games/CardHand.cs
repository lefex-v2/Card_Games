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


    public int GetValueOfHand()
    {
        int score = 0;
        foreach (var card in cardHand)
        {
            score += card.cardValue;
        }

        if(score > 21)
        {
            //find aces and reduce value untill score <= 21
            int numAces = CheckCardInHand("A");
            for (int i = 0; i < numAces; i++)
            {
                if(score > 21)
                {
                    score += - 10;
                }
            }
            return score;
        }
        else
        {
            return score;
        }
    }

    public int CheckCardInHand(string cardName)
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