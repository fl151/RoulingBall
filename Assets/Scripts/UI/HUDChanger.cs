using System;
using Agava.WebUtility;
using UnityEngine;
using UnityEngine.Events;

public class HUDChanger : MonoBehaviour
{
    [SerializeField] private GameObject _mobileHUD;
    [SerializeField] private GameObject _decktopHUD;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameStatesControler _gameControler;

    private GameObject _currentHud;

    private void OnEnable()
    {
        _gameControler.GameStarted += OnGameStarted;
        _gameControler.PlayerDied += OnPlayerDied;
    }

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            _mobileHUD.SetActive(true);
            _currentHud = _mobileHUD;
        }
        else
        {
            _decktopHUD.SetActive(true);
            _currentHud = _decktopHUD;
        }
    }

    private void OnDisable()
    {
        _gameControler.GameStarted -= OnGameStarted;
        _gameControler.PlayerDied -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _gameOverCanvas.SetActive(true);
    }

    private void OnGameStarted()
    {
        _currentHud.SetActive(false);
    }
}
