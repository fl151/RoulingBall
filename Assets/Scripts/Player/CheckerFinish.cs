using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class CheckerFinish : MonoBehaviour
{
    private bool _isPlayerFinished = false;
    private FinishLine _finish;

    public event UnityAction PlayerFinish;

    private void Update()
    {
        if(_finish != null && _isPlayerFinished == false)
        {
            if(transform.position.z >= _finish.transform.position.z)
            {
                PlayerFinish?.Invoke();
                _isPlayerFinished = true;
            }
        }
    }

    public void SetFinish(FinishLine finish)
    {
        _finish = finish;
    }
}
