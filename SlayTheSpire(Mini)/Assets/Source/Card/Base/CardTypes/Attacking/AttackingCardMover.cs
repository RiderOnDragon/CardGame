using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackingCardMover : CardMover
{
    public override void OnBeginDrag(PointerEventData eventData)
    {
        _cardMoving = true;

        _mainCamera = Camera.main;
        _cursorPosition = Input.mousePosition;

        _oldPosition = transform.position;
        _oldParent = transform.parent;
        _childIndex = transform.GetSiblingIndex();

        TrajectoryLine.Singleton.EnableLine(transform.position);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        _cursorPosition = Input.mousePosition;
        Vector2 newPosition = _mainCamera.ScreenToWorldPoint(_cursorPosition);

        TrajectoryLine.Singleton.UpdateLine(newPosition);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        TrajectoryLine.Singleton.DisableLine();

        var point = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(_cursorPosition));

        if (point != null && point.TryGetComponent(out Hand hand) == true)
        {
            ReturnCard();
        }
        else
        {
            _card.PlayCard(point);
            HideCardEventInvoke();
        }

        _cardMoving = false;
    }
}
