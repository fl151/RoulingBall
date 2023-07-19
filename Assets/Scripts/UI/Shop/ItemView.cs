using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _price;

    [SerializeField] private GameObject[] _buyElements;
    [SerializeField] private GameObject[] _activeElements;

    public void Fill(Sprite sprite, int price)
    {
        _icon.sprite = sprite;
        _price.text = price.ToString();
    }

    public void Buy()
    {
        foreach (var element in _buyElements)
        {
            element.SetActive(false);
        }
    }

    public void SetActive()
    {
        foreach (var element in _activeElements)
        {
            element.SetActive(true);
        }
    }

    public void SetInactive()
    {
        foreach (var element in _activeElements)
        {
            element.SetActive(false);
        }
    }
}
