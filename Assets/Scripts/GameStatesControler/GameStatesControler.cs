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
    [SerializeField] private UserInputFinish _inputFinish;
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

        _tryAgainButton.onClick.AddListener(OnButtonTryAgainClicked);

        _player.Died += OnPlayerDied;
        _player.Finish += OnPlayerFinish;

        _inputFinish.UserFindSpeed += OnUserFindSpeed;

        _thingsDroper.ThingsFinished += OnThingsFinished;
    }

    private void OnDisable()
    {
        _mobileInput.FirstContactHappend -= OnFirstContactHappened;
        _decktopInput.FirstContactHappend -= OnFirstContactHappened;

        _tryAgainButton.onClick.RemoveListener(OnButtonTryAgainClicked);

        _player.Died -= OnPlayerDied;
        _player.Finish += OnPlayerFinish;

        _inputFinish.UserFindSpeed -= OnUserFindSpeed;

        _thingsDroper.ThingsFinished -= OnThingsFinished;
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

    private void OnUserFindSpeed()
    {
        SpeedFinded?.Invoke();
    }

    private void OnThingsFinished()
    {
        GameFinished?.Invoke();
    }
}
