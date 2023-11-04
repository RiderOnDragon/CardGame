using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard : AttackingCard
{
    protected override void UseAbility<T>(T target)
    {
        Enemy enemy = target as Enemy;

        enemy.GetDamage(_data.Damage);
    }
}
