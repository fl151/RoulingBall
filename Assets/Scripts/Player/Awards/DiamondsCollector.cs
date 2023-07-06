using UnityEngine;
using UnityEngine.Events;

public class DiamondsCollector : MonoBehaviour
{
    private int _count = 0;

    public event UnityAction DiamondTaken;

    public int Count => _count;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Diamond diamond))
        {
            other.gameObject.SetActive(false);

            _count++;

            DiamondTaken?.Invoke();
        }
    }

}
