using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonLanguage : MonoBehaviour
{
    [SerializeField] private Sprite _ruSprite;
    [SerializeField] private Sprite _enSprite;
    [SerializeField] private Sprite _trSprite;

    [SerializeField] private LanguageLocalisation _languageLocalisation;

    private Language[] _languages = {Language.Ru, Language.En, Language.Tr};

    private Button _button;
    private Image _image;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _languageLocalisation.LanguageChanged += OnLanguageChanged;
        _button.onClick.AddListener(OnButtonClick);
    }

    private void Start()
    {
        OnLanguageChanged();
    }

    private void OnDisable()
    {
        _languageLocalisation.LanguageChanged -= OnLanguageChanged;
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnLanguageChanged()
    {
        switch (Progress.Instance.PlayerData.Language)
        {
            case Language.Ru:
                _image.sprite = _ruSprite;
                break;

            case Language.En:
                _image.sprite = _enSprite;
                break;

            case Language.Tr:
                _image.sprite = _trSprite;
                break;
        }
    }

    private void OnButtonClick()
    {
        int currentLanguageIndex = GetCurrentLanguageIndex();

        if (currentLanguageIndex == _languages.Length - 1)
            currentLanguageIndex = 0;
        else
            currentLanguageIndex++;

        _languageLocalisation.SetLanguage(_languages[currentLanguageIndex]);
    }

    private int GetCurrentLanguageIndex()
    {
        for (int i = 0; i < _languages.Length; i++)
        {
            if (_languages[i] == Progress.Instance.PlayerData.Language)
                return i;
        }

        return 0;
    }
}
