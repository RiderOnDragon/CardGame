using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Create EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _hp;

    public int Hp { get => _hp; }
    public Enemy Prefab { get => _prefab; }
}
