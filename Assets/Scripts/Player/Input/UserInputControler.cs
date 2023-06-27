using UnityEngine;

public class UserInputControler : MonoBehaviour
{
    [SerializeField] private UserInput _mobile;
    [SerializeField] private UserInput _decktop;

    [SerializeField] private RightLeftBallMover _playerRLMover;

    [SerializeField] private GameStatesControler _gameControler;

    private void OnEnable()
    {
        _gameControler.PlayerDied += OnPlayerDied;
    }

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            UseMobileInput();
        }
        else
        {
            UseDecktopInput();
        }
    }

    private void OnDisable()
    {
        _gameControler.PlayerDied -= OnPlayerDied;
    }

    private void UseMobileInput()
    {
        _mobile.gameObject.SetActive(true);
        _playerRLMover.InstanceInput(_mobile);
    }

    private void UseDecktopInput()
    {
        _decktop.enabled = true;
        _playerRLMover.InstanceInput(_decktop);
    }

    private void OnPlayerDied()
    {
        _decktop.enabled = false;
        _mobile.gameObject.SetActive(false);
    }
}
