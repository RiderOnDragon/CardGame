using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeckView))]
public abstract class DeckBase : MonoBehaviour
{
    protected List<CardData> _cards = new List<CardData>();

    protected DeckView _view;

    public void BaseInit()
    {
        SubscribeToEvent();

        _view = GetComponent<DeckView>();
        _view.UpdateView(_cards.Count);
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvent();
    }

    protected virtual void SubscribeToEvent()
    {

    }
    protected virtual void UnsubscribeFromEvent()
    {

    }
}
