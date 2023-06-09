using UnityEngine;

public class PieceOfRoad : MonoBehaviour
{
    private BarrierPoint[] _barrierPoints;
    private Transform _endPoint;

    public Transform EndPoint => _endPoint;
    public BarrierPoint[] BarrierPoints => _barrierPoints;

    private void Awake()
    {
        _endPoint = GetComponentInChildren<EndPoint>().transform;

        _barrierPoints = GetComponentsInChildren<BarrierPoint>();
    }
}
