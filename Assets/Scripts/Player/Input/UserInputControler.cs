using UnityEngine;

public class UserInputControler : MonoBehaviour
{
    [SerializeField] private UserInput _mobile;
    [SerializeField] private UserInput _decktop;

    [SerializeField] private RightLeftBallMover _playerRLMover;

    void Start()
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

    private void UseMobileInput()
    {
        _mobile.enabled = true;
        _playerRLMover.InstanceInput(_mobile);
    }

    private void UseDecktopInput()
    {
        _decktop.enabled = true;
        _playerRLMover.InstanceInput(_decktop);
    }
}
