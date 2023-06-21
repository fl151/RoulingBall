using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    private bool _isOnceConnected = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player) && _isOnceConnected == false)
        {
            gameObject.transform.parent = player.transform;
            _isOnceConnected = true;
        }
    }
}
