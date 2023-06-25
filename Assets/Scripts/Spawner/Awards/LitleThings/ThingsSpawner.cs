using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsSpawner : AwardSpawner
{
    [SerializeField] private BarriersSpawner _barrierSpawner;

    private void OnEnable()
    {
        _barrierSpawner.BarrierSpawned += OnBarrierSpawned;
    }

    private void OnDisable()
    {
        _barrierSpawner.BarrierSpawned -= OnBarrierSpawned;
    }

    private void OnBarrierSpawned(Barrier barrier)
    {
        IPattern pattern = _finderPattern.GetRandomThingsPattern(barrier);

        _patternExecuter.ExecutPattern(pattern, _prefab, barrier.transform.position);
    }
}
