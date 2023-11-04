using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;

    public void UpdateView(float currentHp, float maxHp)
    {
        if (currentHp < 0)
            currentHp = 0;

        _hpBar.value = currentHp / maxHp;
    }
}
