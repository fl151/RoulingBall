using UnityEngine;

public class RoadDecorationSpawner : MonoBehaviour
{
    [SerializeField] private RoadSpawner _spawner;
    [SerializeField] private Barrier[] _barrierPrefabs;
    [SerializeField] private Color[] _colorsAfterFinish;

    private int _indexCurrentPieceAfterFinish;

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

        int text = (_indexCurrentPieceAfterFinish + 1) * 10;

        piece.GetComponent<TextChanger>().SetText(text + "");

        _indexCurrentPieceAfterFinish++;
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

        return barriers[Random.Range(0, length)];
    }
}
