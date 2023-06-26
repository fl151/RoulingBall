using System;
using Agava.WebUtility;
using UnityEngine;
using UnityEngine.Events;

public class HUDChanger : MonoBehaviour
{
    [SerializeField] private GameObject _mobileHUD;
    [SerializeField] private GameObject _decktopHUD;
    [SerializeField] private GameStatesControler _gameControler;

    private void OnEnable()
    {
        _gameControler.GameStarted += OnGameStarted;
    }    

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            _mobileHUD.SetActive(true);
        }
        else
        {
            _decktopHUD.SetActive(true);
        }
    }

    private void OnDisable()
    {
        _gameControler.GameStarted -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        _mobileHUD.SetActive(false);
        _decktopHUD.SetActive(false);
    }
}
