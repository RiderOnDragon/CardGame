using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _img;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;

    public void Init(CardData data)
    {
        _background.sprite = data.Background;
        _img.sprite = data.Img;

        _name.text = data.Name;
        _description.text = data.Description;
    }
}
