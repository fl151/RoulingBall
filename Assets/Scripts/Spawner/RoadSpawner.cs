using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private PieceOfRoad _startPieceRoad;
    [SerializeField] private PieceOfRoad[] _prefabsPoad;
    [SerializeField] private PieceOfRoad _endPieceRoad;

    private int countPiecesRoad = 5;

    private PieceOfRoad _lastPiece;
    private PieceOfRoad _currentPiece;

    private void Start()
    {
        SpawnPiece(_startPieceRoad);

        for (int i = 0; i < countPiecesRoad; i++)
        {
            SpawnPiece(GetRandomPiece(_prefabsPoad));
        }

        SpawnPiece(_endPieceRoad);
    }

    private PieceOfRoad GetRandomPiece(PieceOfRoad[] prefabs)
    {
        if (prefabs.Length == 0)
            return null;

        int index = Random.Range(0, prefabs.Length - 1);

        return prefabs[index];
    }

    private void SpawnPiece(PieceOfRoad prefab)
    {
        _currentPiece = Instantiate(prefab, transform);

        if (_lastPiece != null)    
            _currentPiece.transform.position = _lastPiece.EndPoint.position;

        _lastPiece = _currentPiece;
    }


}
