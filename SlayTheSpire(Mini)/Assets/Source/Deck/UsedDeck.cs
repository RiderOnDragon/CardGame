using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedDeck : DeckBase
{
    protected override void SubscribeToEvent()
    {
        Card.AnyCardPlayed += OnCardPlayed;
    }

    protected override void UnsubscribeFromEvent()
    {
        Card.AnyCardPlayed -= OnCardPlayed;
    }

    private void OnCardPlayed(Card card)
    {
        _cards.Add(card.Data);
        _view.UpdateView(_cards.Count);
    }

    public List<CardData> GetAllCards()
    {
        List<CardData> cards = new List<CardData>();
        cards.AddRange(_cards);

        _cards.Clear();

        _view.UpdateView(_cards.Count);

        return cards;
    }
}
