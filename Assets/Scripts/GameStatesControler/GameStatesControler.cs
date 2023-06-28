using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStatesControler : MonoBehaviour
{
    [SerializeField] private UserInput _mobileInput;
    [SerializeField] private UserInput _decktopInput;
    [SerializeField] private HUDChanger _hudsChanger;
    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private Player _player;

    private const string _mainSceneTitle = "Main";

    public event UnityAction GameStarted;
    public event UnityAction PlayerDied;
    public event UnityAction PlayerFinish;

    private void OnEnable()
    {
        _mobileInput.FirstContactHappend += OnFirstContactHappened;
        _decktopInput.FirstContactHappend += OnFirstContactHappened;

        _tryAgainButton.onClick.AddListener(OnButtonTryAgainClicked);
        _player.Died += OnPlayerDied;
        _player.Finish += OnPlayerFinish;
    }

    private void OnDisable()
    {
        _mobileInput.FirstContactHappend -= OnFirstContactHappened;
        _decktopInput.FirstContactHappend -= OnFirstContactHappened;

        _tryAgainButton.onClick.RemoveListener(OnButtonTryAgainClicked);
        _player.Died -= OnPlayerDied;
        _player.Finish += OnPlayerFinish;
    }

    private void OnButtonTryAgainClicked()
    {
        SceneManager.LoadScene(_mainSceneTitle);
    }

    private void OnFirstContactHappened()
    {
        GameStarted?.Invoke();
    }

    private void OnPlayerDied()
    {
        PlayerDied?.Invoke();
    }

    private void OnPlayerFinish()
    {
        PlayerFinish?.Invoke();
    }
}
