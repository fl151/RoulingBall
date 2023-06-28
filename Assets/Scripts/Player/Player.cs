using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction Died;
    public event UnityAction Finish;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Barrier barrier))
        {
            Died?.Invoke();
        }

        if (other.TryGetComponent(out FinishLine finishLine))
        {
            Finish?.Invoke();
        }
    }
}
