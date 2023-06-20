using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PatternChecker : MonoBehaviour
{
    [SerializeField] private bool _ternOn;
    [SerializeField] private ThingsSpawner _spawner;

    private bool _currentTern;

    private void Update()
    {
        if(Application.isPlaying == false)
        {
            if(_ternOn != _currentTern)
            {
                _currentTern = _ternOn;

                _spawner.ExecutPattern(transform.position, new LinePattern(), 1.6f);
            }
        }
    }
}
