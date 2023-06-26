using UnityEngine;
using UnityEngine.Events;

public class GameStatesControler : MonoBehaviour
{
    [SerializeField] private UserInput _mobileInput;
    [SerializeField] private UserInput _decktopInput;
    [SerializeField] private HUDChanger _hudsChanger;

    public UnityAction GameStarted;

    private void OnEnable()
    {
        if (Application.isMobilePlatform)
        {
            _mobileInput.FirstContactHappend += OnFirstContactHappened;
        }
        else
        {
            _decktopInput.FirstContactHappend += OnFirstContactHappened;
        }
    }

    private void OnDisable()
    {
        if (Application.isMobilePlatform)
        {
            _mobileInput.FirstContactHappend -= OnFirstContactHappened;
        }
        else
        {
            _decktopInput.FirstContactHappend -= OnFirstContactHappened;
        }
    }

    private void OnFirstContactHappened()
    {
        GameStarted?.Invoke();
    }
}
