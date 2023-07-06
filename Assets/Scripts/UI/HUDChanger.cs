using UnityEngine;


public class HUDChanger : MonoBehaviour
{
    [SerializeField] private GameObject _mobileHUD;
    [SerializeField] private GameObject _decktopHUD;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _findSpeedAfterFinishCanvas;
    [SerializeField] private GameStatesControler _gameControler;
    [SerializeField] private GameObject _playingCanvas;

    private GameObject _currentHud;

    private void OnEnable()
    {
        _gameControler.GameStarted += OnGameStarted;
        _gameControler.PlayerDied += OnPlayerDied;
        _gameControler.PlayerFinish += OnPlayerFinished;
        _gameControler.SpeedFinded += OnSpeedFinded;
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
        _gameControler.PlayerFinish -= OnPlayerFinished;
        _gameControler.SpeedFinded -= OnSpeedFinded;
    }

    private void OnPlayerDied()
    {
        _gameOverCanvas.SetActive(true);
        _playingCanvas.SetActive(false);
    }

    private void OnGameStarted()
    {
        _currentHud.SetActive(false);

        _playingCanvas.SetActive(true);
    }

    private void OnPlayerFinished()
    {
        _findSpeedAfterFinishCanvas.SetActive(true);

        _playingCanvas.SetActive(false);
    }

    private void OnSpeedFinded()
    {
        _findSpeedAfterFinishCanvas.SetActive(false);
    }
}
