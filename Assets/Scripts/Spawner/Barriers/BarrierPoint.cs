using UnityEngine;

public enum Position
{
    Left,
    Center,
    Right
}

public class BarrierPoint : MonoBehaviour
{
    [SerializeField] private Position _position;

    public Position Position => _position;
}
