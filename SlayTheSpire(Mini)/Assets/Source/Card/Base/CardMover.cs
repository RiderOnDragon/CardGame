using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Card))]
public abstract class CardMover : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected Card _card;

    protected Camera _mainCamera;
    protected Vector2 _cursorPosition;
    protected Vector2 _offsetCursor;

    protected Vector2 _oldPosition;
    protected Transform _oldParent;
    protected int _childIndex;

    protected static bool _cardMoving = false;

    private Vector2 _showCardPosition = new Vector2(0, 120);

    public static event Action ShowCard;
    public static event Action HideCard;

    private void Awake()
    {
        _card = GetComponent<Card>();

        _card.ReturnCard += ReturnCard;
    }

    private void OnDestroy()
    {
        _card.ReturnCard -= ReturnCard;
    }


    public abstract void OnEndDrag(PointerEventData eventData);
    public abstract void OnDrag(PointerEventData eventData);
    public abstract void OnBeginDrag(PointerEventData eventData);


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_cardMoving == true) 
            return;

        ShowCard?.Invoke();

        _oldPosition = transform.localPosition;

        transform.localPosition += (Vector3)_showCardPosition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_cardMoving == true)
            return;

        HideCard.Invoke();

        transform.localPosition = _oldPosition;
    }

    protected void ReturnCard()
    {
        transform.SetParent(_oldParent);
        transform.SetSiblingIndex(_childIndex);
        transform.localPosition = _oldPosition;
        HideCard.Invoke();
    }

    protected void HideCardEventInvoke()
    {
        HideCard?.Invoke();
    }
}
