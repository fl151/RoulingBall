using TMPro;
using UnityEngine;
using Agava.YandexGames;

[RequireComponent(typeof(TMP_Text))]
public class TextLocilisation : MonoBehaviour
{
    [SerializeField] private string _ruText;
    [SerializeField] private string _enText;
    [SerializeField] private string _trText;

    [SerializeField] private LanguageLocalisation _languageLocalisation;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _languageLocalisation.LanguageChanged += OnLanguageChanged;
    }

    private void Start()
    {
        OnLanguageChanged();
    }

    private void OnDisable()
    {
        _languageLocalisation.LanguageChanged -= OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        switch (Progress.Instance.PlayerData.Language)
        {
            case Language.Ru:
                _text.text = _ruText;
                break;

            case Language.En:
                _text.text = _enText;
                break;

            case Language.Tr:
                _text.text = _trText;
                break;

            default:
                break;
        }
    }
}
