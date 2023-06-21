using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private bool _canBeJumpetOver;

    private Position _position;

    public bool CanBeJumpedOver => _canBeJumpetOver;

    public Position Position => _position;

    public void SetPointPosition(Position position)
    {
        _position = position;
    }
}
