using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeckData", menuName = "Data/Create DeckData")]
public class DeckData : ScriptableObject
{
    [SerializeField] private List<CardData> _cards = new List<CardData>();

    public List<CardData> Cards { get => _cards; }
}
