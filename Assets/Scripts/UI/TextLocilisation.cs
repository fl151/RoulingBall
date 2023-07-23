using TMPro;
using UnityEngine;
using Agava.YandexGames;

[RequireComponent(typeof(TMP_Text))]
public class TextLocilisation : MonoBehaviour
{
    private const string _ruLang = "ru";
    private const string _trLang = "tr";
    private const string _enLang = "en";

    [SerializeField] private string _ruText;
    [SerializeField] private string _enText;
    [SerializeField] private string _trText;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        switch(YandexGamesSdk.Environment.browser.lang){
            case _ruLang:
                _text.text = _ruText;
                break;

            case _enLang:
                _text.text = _enText;
                break;

            case _trLang:
                _text.text = _trText;
                break;
        }
    }
}
