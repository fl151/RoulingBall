using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class LanguageLocalisation : MonoBehaviour
{
    private const string _ruLang = "ru";
    private const string _trLang = "tr";
    private const string _enLang = "en";

    public event UnityAction LanguageChanged;

    private void OnEnable()
    {
        Progress.Instance.DataLoaded += OnDataLoaded;
    }

    private void OnDisable()
    {
        Progress.Instance.DataLoaded -= OnDataLoaded;
    }

    public void SetLanguage(Language language)
    {
        ChangeLanguage(language);
    }

    private void OnDataLoaded()
    {
        if (Progress.Instance.PlayerData.Language == Language.Null)
        {
            switch (YandexGamesSdk.Environment.browser.lang)
            {
                case _ruLang:
                    ChangeLanguage(Language.Ru);
                    break;

                case _enLang:
                    ChangeLanguage(Language.En);
                    break;

                case _trLang:
                    ChangeLanguage(Language.Tr);
                    break;
            }
        }
        else
        {
            ChangeLanguage(Progress.Instance.PlayerData.Language);
        }
    }

    private void ChangeLanguage(Language language)
    {
        Progress.Instance.PlayerData.Language = language;

        Progress.SaveDataCloud();

        LanguageChanged?.Invoke();
    }
}
