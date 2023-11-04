using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Data/Create CardData")]
public class CardData : ScriptableObject
{

    [SerializeField] private Card _prefab;

    [Space(20)]

    [SerializeField] private int _manaCost;
    [SerializeField] private int _damage;
    [SerializeField] private int _addedShield;
    [SerializeField] private int _healing;

    [Space(20)]

    [SerializeField] private string _name;
    [SerializeField] private string _description;

    [Space(20)]
    [SerializeField] private Sprite _background;
    [SerializeField] private Sprite _img;


    public Card Prefab { get => _prefab; }
    public string Name { get => _name; }
    public string Description { get => _description; }
    public Sprite Background { get => _background; }
    public Sprite Img { get => _img; }
    public int ManaCost { get => _manaCost; }
    public int Damage { get => _damage; }
    public int AddedShield { get => _addedShield; }
    public int Healing { get => _healing; }
}
