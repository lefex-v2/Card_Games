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

    public bool CheckCardsInHand(string cardName)
    {
        var cardInHand = cardHand.Where(a => a.cardName.Contains(cardName));

        foreach (var card in cardInHand)
        {
            Console.WriteLine(card.cardName);
            return true;
        }
        return false;
    }
}