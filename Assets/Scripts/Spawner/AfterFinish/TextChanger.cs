using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
