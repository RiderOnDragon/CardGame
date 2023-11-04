using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyView))]
public class Enemy : MonoBehaviour
{
    private EnemyData _data;

    private EnemyView _view;

    private int _hp;

    public void Init(EnemyData data)
    {
        _view = GetComponent<EnemyView>();

        _data = data;
        _hp = data.Hp;

        _view.UpdateView(_hp, _data.Hp);
    }

    public void GetDamage(int damage)
    {
        if (damage < 0)
            throw new Exception("The damage cannot be less than zero");

        _hp -= damage;

        _view.UpdateView(_hp, _data.Hp);

        if (_hp <= 0)
            Destroy(gameObject);
    }
}
