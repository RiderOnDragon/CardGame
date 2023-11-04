using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cardCoutText;

    public void UpdateView(int cardCount)
    {
        _cardCoutText.text = cardCount.ToString();
    }
}
