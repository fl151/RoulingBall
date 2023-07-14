using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStatesControler : MonoBehaviour
{
    [SerializeField] private UserInput _mobileInput;
    [SerializeField] private UserInput _decktopInput;
    [SerializeField] private HUDChanger _hudsChanger;
    [SerializeField] private UserInputSkip _tryAgainCanvas;
    [SerializeField] private Player _player;
    [SerializeField] private UserInputSkip _findSpeedCanvas;
    [SerializeField] private ThingsDroper _thingsDroper;

    private const string _mainSceneTitle = "Main";

    public event UnityAction GameStarted;
    public event UnityAction PlayerDied;
    public event UnityAction PlayerFinish;
    public event UnityAction SpeedFinded;
    public event UnityAction GameFinished;

    private void OnEnable()
    {
        _mobileInput.FirstContactHappend += OnFirstContactHappened;
        _decktopInput.FirstContactHappend += OnFirstContactHappened;

        _tryAgainCanvas.PlayerInteract += OnCanvasTryAgainInteracted;

        _player.Died += OnPlayerDied;
        _player.Finish += OnPlayerFinish;

        _findSpeedCanvas.PlayerInteract += OnUserFindSpeed;

        _thingsDroper.ThingsFinished += OnThingsFinished;
    }

    private void OnDisable()
    {
        _mobileInput.FirstContactHappend -= OnFirstContactHappened;
        _decktopInput.FirstContactHappend -= OnFirstContactHappened;

        _tryAgainCanvas.PlayerInteract -= OnCanvasTryAgainInteracted;

        _player.Died -= OnPlayerDied;
        _player.Finish += OnPlayerFinish;

        _findSpeedCanvas.PlayerInteract -= OnUserFindSpeed;

        _thingsDroper.ThingsFinished -= OnThingsFinished;
    }

    private void OnCanvasTryAgainInteracted()
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

    private void OnUserFindSpeed()
    {
        SpeedFinded?.Invoke();
    }

    private void OnThingsFinished()
    {
        GameFinished?.Invoke();
    }
}
