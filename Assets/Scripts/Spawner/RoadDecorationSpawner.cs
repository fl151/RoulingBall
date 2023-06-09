using UnityEngine;
using System.Collections.Generic;

public class RoadDecorationSpawner : MonoBehaviour
{
    [SerializeField] private RoadSpawner _spawner;

    [SerializeField] private Barrier[] _barrierPrefabs;

    private void OnEnable()
    {
        _spawner.Spawned += OnPieceSpawned;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= OnPieceSpawned;
    }

    private void OnPieceSpawned(PieceOfRoad piece)
    {
        if (piece is PieceAfterFinish)
        {
            DecorateAfterFinish(piece as PieceAfterFinish);
        }
        else
        {
            DecorateRoad(piece);
        }
    }

    private void DecorateAfterFinish(PieceAfterFinish piece)
    {

    }

    private void DecorateRoad(PieceOfRoad piece)
    {
        BarrierPoint[] barriersPoints = piece.BarrierPoints;

        foreach (var point in barriersPoints)
        {
            Barrier barrier = GetRandomBarrier(_barrierPrefabs);

            Instantiate(barrier, point.transform);
        }
    }

    private Barrier GetRandomBarrier(Barrier[] barriers)
    {
        int length = barriers.Length;

        if (length == 0)
            return null;

        return barriers[GetRandomIndex(length)];
    }

    private int GetRandomIndex(int arrayLength)
    {
        int index = Random.Range(0, arrayLength);

        return index;
    }
}
