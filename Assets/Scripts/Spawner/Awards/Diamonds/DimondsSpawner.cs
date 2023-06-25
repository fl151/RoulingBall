using UnityEngine;

public class DimondsSpawner : AwardSpawner
{
    [SerializeField] private TrampolileSpawner _trampolineSpawner;
    [SerializeField] private RoadSpawner _roadSpawner;
    [Range(0, 1)]
    [SerializeField] private float _chanceSpawnOnTrampoline;

    private Vector3 _upRangeTrampoline = new Vector3(0, 1, 0);

    private void OnEnable()
    {
        _trampolineSpawner.TrampolineSpawned += OnTrampolineSpawned;
        _roadSpawner.SpawnedAfterFinish += OnSpanwedAfterFinish;
    }

    private void OnDisable()
    {
        _trampolineSpawner.TrampolineSpawned -= OnTrampolineSpawned;
        _roadSpawner.SpawnedAfterFinish -= OnSpanwedAfterFinish;
    }

    private void OnTrampolineSpawned(Trampolne trampoline)
    {
        if (_chanceSpawnOnTrampoline != 0)
            if ((int)Random.Range(0, 1 / _chanceSpawnOnTrampoline) == 0)
                SpawnDiamond(trampoline.transform.position + _upRangeTrampoline);
    }

    private void OnSpanwedAfterFinish(PieceOfRoad piece)
    {
        IPattern pattern = _finderPattern.GetRandomDimondsPattern();

        EndPoint endPoint = piece.GetComponentInChildren<EndPoint>();

        Vector3 localPosition = (endPoint.transform.position - piece.transform.position) / 2;

        _patternExecuter.ExecutPattern(pattern, _prefab, piece.transform.position + localPosition);
    }


    private void SpawnDiamond(Vector3 position)
    {
        Diamond diamond = Instantiate(_prefab as Diamond);
        diamond.transform.position = position;
    }
}
