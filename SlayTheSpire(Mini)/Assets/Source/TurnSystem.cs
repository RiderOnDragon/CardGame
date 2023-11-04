using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    [Header("Enemys")]
    [SerializeField] private List<EnemyData> _enemys;
    [SerializeField] private Transform _enemyContainer;

    [Space(5)]

    [Header("Deck")]
    [SerializeField] private RemainingDeck _remainingDeck;
    [SerializeField] private UsedDeck _usedDeck;
    [SerializeField] private DeckData _deck;

    public static event Action StartBattle;
    public static event Action EndTurn;

    private void Start()
    {
        InitBattle();
    }

    private void InitBattle()
    {
        foreach(EnemyData enemy in _enemys)
        {
            var newEnemy = Instantiate(enemy.Prefab, _enemyContainer);
            newEnemy.Init(enemy);
        }

        _remainingDeck.BaseInit();
        _remainingDeck.Init(_deck);

        _usedDeck.BaseInit();

        StartBattle?.Invoke();
    }

    public void FinishTurn()
    {
        EndTurn?.Invoke();
    }
}
