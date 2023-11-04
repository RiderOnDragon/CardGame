using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackingCardMover))]
public abstract class AttackingCard : Card
{
    protected override bool TryPlayCard(Collider2D target)
    {
        if (target != null && target.TryGetComponent(out Enemy enemy) == true)
        {
            UseAbility(enemy);
            return true;
        }
        else
        {
            return false;
        }
    }
}
