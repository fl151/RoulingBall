using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction Died;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Barrier barrier))
        {
            Died?.Invoke();
        }
    }
}
