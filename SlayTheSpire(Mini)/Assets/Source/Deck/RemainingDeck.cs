using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemainingDeck : DeckBase
{
    [SerializeField] private UsedDeck _usedDeck;

    public void Init(DeckData data)
    {
        _cards.AddRange(data.Cards);
    }

    public List<Card> GetCards(int count, Transform container)
    {
        List<Card> cards = new List<Card>();

        for (int i = 0; i < count; i++)
        {
            if (_cards.Count == 0)
            {
                _cards.AddRange(_usedDeck.GetAllCards());
                if (_cards.Count == 0)
                    break;
            }

            int cardIndex = UnityEngine.Random.Range(0, _cards.Count);
            Card card = Instantiate(_cards[cardIndex].Prefab, container);

            card.Init(_cards[cardIndex]);
            cards.Add(card);

            _cards.RemoveAt(cardIndex);
        }

        _view.UpdateView(_cards.Count);

        return cards;
    }
}
