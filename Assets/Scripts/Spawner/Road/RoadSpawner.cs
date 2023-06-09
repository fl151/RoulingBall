using UnityEngine;
using UnityEngine.Events;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private PieceOfRoad _startPieceRoad;
    [SerializeField] private PieceOfRoad[] _prefabsPoad;
    [SerializeField] private PieceOfRoad _endPieceRoad;
    [SerializeField] private PieceOfRoad _afterEndPiece;

    public event UnityAction<PieceOfRoad> Spawned; 

    private const int _countPiecesRoad = 5;
    private const int _countPiecesRoadAfterFinish = 10;

    private PieceOfRoad _lastPiece;

    private void Start()
    {
        SpawnPiece(_startPieceRoad);

        for (int i = 0; i < _countPiecesRoad; i++)
        {
            SpawnPiece(GetRandomPiece(_prefabsPoad));
        }

        SpawnPiece(_endPieceRoad);

        for (int i = 0; i < _countPiecesRoadAfterFinish; i++)
        {
            SpawnPiece(_afterEndPiece);
        }
    }

    private PieceOfRoad GetRandomPiece(PieceOfRoad[] prefabs)
    {
        if (prefabs.Length == 0)
            return null;

        int index = Random.Range(0, prefabs.Length);

        return prefabs[index];
    }

    private void SpawnPiece(PieceOfRoad prefab)
    {
        var currentPiece = Instantiate(prefab, transform);

        if (_lastPiece != null)    
            currentPiece.transform.position = _lastPiece.EndPoint.position;

        _lastPiece = currentPiece;  

        Spawned?.Invoke(currentPiece);
    }
}
