using UnityEngine;

public enum Position
{
    Null,
    Left,
    Center,
    Right
}

public class BarrierPoint : MonoBehaviour
{
    [SerializeField] private Position _position;

    public Position Position => _position;
}
