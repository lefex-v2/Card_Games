class CardHand
{
    new List<Cards> cardHand = new List<Cards>();

    public CardHand()
    {
        
    }

    void AddCardToHand(Cards addedCard)
    {
        cardHand.Add(addedCard);
    }

    void RemoveCardFromHand(int cardInx)
    {
        cardHand.Remove(cardHand[cardInx]);
    }
}