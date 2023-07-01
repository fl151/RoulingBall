using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private CheckerFinish _checker;

    public event UnityAction Died;
    public event UnityAction Finish;

    private void OnEnable()
    {
        _checker.PlayerFinish += OnPlayerFinish;
    }

    private void OnDisable()
    {
        _checker.PlayerFinish -= OnPlayerFinish;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Barrier barrier))
        {
            Died?.Invoke();
        }
    }

    private void OnPlayerFinish()
    {
        Finish?.Invoke();
    }
}
