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
        if(piece is PieceAfterFinish)
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

        BarrierPoint barrierPoint = GetRandomPoint(barriersPoints);

        if (barrierPoint != null)
        {
            Barrier barrier = GetRandomBarrier(_barrierPrefabs);

            Instantiate(barrier, barrierPoint.transform);
        }
    }

    private BarrierPoint GetRandomPoint(BarrierPoint[] points)
    {
        if (points == null)
            return null;

        int length = points.Length;

        if (length == 0)
            return null;

        return points[GetRandomIndex(length)];
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
