using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolne : MonoBehaviour
{
    private Rigidbody _rb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ForwardBackMover mover))
        {
            _rb = mover.GetComponent<Rigidbody>();
            _rb.isKinematic = false;

            mover.Moved += OnPlayerMoved;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ForwardBackMover mover))
        {
            _rb.isKinematic = true;

            mover.Moved -= OnPlayerMoved;
        }
    }

    private void OnPlayerMoved(Vector3 direction)
    {
        _rb.transform.position += new Vector3(0, direction.z, 0);
    }
}
