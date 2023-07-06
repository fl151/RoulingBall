using UnityEngine;
using UnityEngine.Events;

public class BarriersSpawner : MonoBehaviour
{
    [SerializeField] private RoadSpawner _spawner;
    [SerializeField] private Barrier[] _barrierPrefabs;
    [SerializeField] private Color[] _colorsAfterFinish;

    private int _indexCurrentPieceAfterFinish;

    public UnityAction<Barrier> BarrierSpawned;

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
        Color color = _colorsAfterFinish[_indexCurrentPieceAfterFinish % _colorsAfterFinish.Length];
        piece.GetComponent<ColorChanger>().SetColor(color);

        _indexCurrentPieceAfterFinish++;
    }

    private void DecorateRoad(PieceOfRoad piece)
    {
        BarrierPoint[] barriersPoints = piece.BarrierPoints;

        foreach (var point in barriersPoints)
        {
            Barrier barrierPrefab = GetRandomBarrier(_barrierPrefabs);

            Barrier barrier = Instantiate(barrierPrefab, point.transform);
            barrier.SetPointPosition(point.Position);

            BarrierSpawned?.Invoke(barrier);
        }
    }

    private Barrier GetRandomBarrier(Barrier[] barriers)
    {
        int length = barriers.Length;

        if (length == 0)
            return null;

        return barriers[Random.Range(0, length)];
    }
}
