using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceOfRoad : MonoBehaviour
{
    private Transform[] _barrierPoints;

    private Transform _endPoint;

    public Transform EndPoint => _endPoint;

    private void Awake()
    {
        _endPoint = GetComponentInChildren<EndPoint>().transform;

        var barrierPoints = GetComponentsInChildren<BarrierPoint>();

        _barrierPoints = new Transform[barrierPoints.Length];

        for (int i = 0; i < barrierPoints.Length; i++)
        {
            _barrierPoints[i] = barrierPoints[i].transform;
        }
    }

    public Transform[] GetBerriersPoints()
    {
        return _barrierPoints;
    }
}
