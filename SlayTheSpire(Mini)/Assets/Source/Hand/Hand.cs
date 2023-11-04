using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] private int _maxCardCountOnHand;


    [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;

    [SerializeField] private RemainingDeck _remainingDeck;

    private List<Card> _cardOnHand = new List<Card>();

    private void Awake()
    {
        TurnSystem.StartBattle += OnStartBattle;
        TurnSystem.EndTurn += OnEndTurn;

        CardMover.ShowCard += OnShowCard;
        CardMover.HideCard += OnHideCard;
    }

    private void OnDestroy()
    {
        TurnSystem.StartBattle -= OnStartBattle;
        TurnSystem.EndTurn -= OnEndTurn;

        CardMover.ShowCard -= OnShowCard;
        CardMover.HideCard -= OnHideCard;
    }

    private void OnStartBattle()
    {
        AddCardToHand(3);
    }
    private void OnEndTurn()
    {
        AddCardToHand(3);
    }

    private void OnCardPlayed(Card card)
    {
        card.CardPlayed -= OnCardPlayed;
        _cardOnHand.Remove(card);
    }

    private void OnShowCard()
    {
        _horizontalLayoutGroup.enabled = false;
    }
    private void OnHideCard()
    {
        _horizontalLayoutGroup.enabled = true;
    }

    private void AddCardToHand(int count)
    {
        if (_cardOnHand.Count + count > _maxCardCountOnHand)
            count = _maxCardCountOnHand - _cardOnHand.Count;

        _cardOnHand = _remainingDeck.GetCards(count, transform);

        foreach (var card in _cardOnHand)
            card.CardPlayed += OnCardPlayed;
    }
}
