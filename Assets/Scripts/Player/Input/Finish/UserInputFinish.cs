using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UserInputFinish : MonoBehaviour
{
    private const float _delay = 0.5f;

    private bool _isDelayFinished = false;

    public event UnityAction UserFindSpeed;

    private void Start()
    {
        StartCoroutine(WaitDelay(_delay));
    }

    private void Update()
    {
        if (_isDelayFinished&& (Input.touchCount > 0 || Input.anyKey))
        {
            UserFindSpeed?.Invoke();
        }
    }

    private IEnumerator WaitDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        _isDelayFinished = true;
    }
}
