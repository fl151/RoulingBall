using UnityEngine;

public class DimondsSpawner : AwardSpawner
{
    [SerializeField] private TrampolileSpawner _trampolineSpawner;
    [Range(0, 1)]
    [SerializeField] private float _chanceSpawnOnTrampoline;

    private Vector3 _upRangeTrampoline = new Vector3(0, 1, 0);

    private void OnEnable()
    {
        _trampolineSpawner.TrampolineSpawned += OnTrampolineSpawned;
    }

    private void OnDisable()
    {
        _trampolineSpawner.TrampolineSpawned -= OnTrampolineSpawned;
    }

    private void OnTrampolineSpawned(Trampolne trampoline)
    {
        if (_chanceSpawnOnTrampoline != 0)
            if ((int)Random.Range(0, 1 / _chanceSpawnOnTrampoline) == 0)
                SpawnDiamond(trampoline.transform.position + _upRangeTrampoline);
    }


    private void SpawnDiamond(Vector3 position)
    {
        Diamond diamond = Instantiate(_prefab as Diamond);
        diamond.transform.position = position;
    }
}
