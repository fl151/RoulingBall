using UnityEngine;
using UnityEngine.Events;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private PieceOfRoad _startPieceRoad;
    [SerializeField] private PieceOfRoad[] _prefabsPoad;
    [SerializeField] private PieceOfRoad _endPieceRoad;
    [SerializeField] private PieceOfRoad _afterEndPiece;

    [SerializeField] private Color[] _validColorsRoad;

    private const int _countPiecesRoad = 4;
    private const int _spreadCountPiecesRoads = 3;
    private const int _countPiecesRoadAfterFinish = 10;

    private PieceOfRoad _lastPiece;
    private Color _color;

    public event UnityAction<PieceOfRoad> Spawned;
    public event UnityAction<PieceOfRoad> SpawnedAfterFinish;

    private void Start()
    {
        _color = GetRandomColor(_validColorsRoad);

        var currentPiece = SpawnPiece(_startPieceRoad);
        SetColor(currentPiece, _color);

        int countRoads = Random.Range(_countPiecesRoad, _countPiecesRoad + _spreadCountPiecesRoads);

        for (int i = 0; i < countRoads; i++)
        {
            currentPiece = SpawnPiece(GetRandomPiece(_prefabsPoad));
            SetColor(currentPiece, _color);
        }

        SpawnPiece(_endPieceRoad);

        for (int i = 0; i < _countPiecesRoadAfterFinish; i++)
        {
            SpawnPiece(_afterEndPiece);
        }
    }

    private PieceOfRoad GetRandomPiece(PieceOfRoad[] prefabs)
    {
        if (prefabs.Length == 0) return null;

        int index = Random.Range(0, prefabs.Length);

        return prefabs[index];
    }

    private PieceOfRoad SpawnPiece(PieceOfRoad prefab)
    {
        var currentPiece = Instantiate(prefab, transform);

        if (_lastPiece != null)    
            currentPiece.transform.position = _lastPiece.EndPoint.position;

        _lastPiece = currentPiece;  

        Spawned?.Invoke(currentPiece);

        if(currentPiece is PieceAfterFinish)
        {
            SpawnedAfterFinish?.Invoke(currentPiece);
        }

        return currentPiece;
    }

    private Color GetRandomColor(Color[] colors)
    {
        if (colors.Length == 0) return Color.black;

        int index = Random.Range(0, colors.Length);

        return colors[index];
    }

    private void SetColor(PieceOfRoad piece, Color color)
    {
        piece.GetComponent<ColorChanger>().SetColor(color);
    }
}
