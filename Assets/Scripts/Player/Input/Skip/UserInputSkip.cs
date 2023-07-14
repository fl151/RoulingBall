using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UserInputSkip : MonoBehaviour
{
    private const float _delay = 0.25f;

    private bool _isDelayFinished = false;

    public event UnityAction PlayerInteract;

    private void Start()
    {
        StartCoroutine(WaitDelay(_delay));
    }

    private void Update()
    {
        if (_isDelayFinished)
        {
            if (Application.isMobilePlatform && Input.touchCount > 0 || Input.anyKey)
            {
                PlayerInteract?.Invoke();
            }
        }
    }

    private IEnumerator WaitDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        _isDelayFinished = true;
    }
}
