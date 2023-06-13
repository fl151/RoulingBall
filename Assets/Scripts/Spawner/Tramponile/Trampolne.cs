using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolne : MonoBehaviour
{
    [SerializeField] private float _speedIncreaseTimese;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ForwardBackMover mover))
        {
            mover.UpSpeed(_speedIncreaseTimese);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ForwardBackMover mover))
        {
            mover.DownSpeed(_speedIncreaseTimese);
        }
    }
}
