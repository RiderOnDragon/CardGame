using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardView))]
public abstract class Card : MonoBehaviour
{
    private CardView _view;
    protected CardData _data;

    public CardData Data => _data;

    public event Action<Card> CardPlayed;
    public event Action ReturnCard;
    public static event Action<Card> AnyCardPlayed;

    public void Init(CardData data)
    {
        _view = GetComponent<CardView>();

        _data = data;
        _view.Init(_data);
    }

    protected abstract bool TryPlayCard(Collider2D target);
    protected virtual void UseAbility<T>(T target)
    {

    }

    public void PlayCard(Collider2D target)
    {
        if (TryPlayCard(target) == false)
        {
            ReturnCard?.Invoke();
            return;
        }
        else
        {
            AnyCardPlayed?.Invoke(this);
            CardPlayed?.Invoke(this);

            Destroy(gameObject);
        }
    }
}
