using UnityEngine;

public class RightLeftBallMover : PlayerMover
{
    [SerializeField] private float _speed;

    private float _validDeviation = 1.6f;

    public void Instance(UserInput input)
    {
        input.Moving += TryMove;
    }

    private void TryMove(Vector3 direction)
    {
        direction *= _speed * Time.deltaTime;

        if(IsValidMoving(direction))
        {
            transform.position += direction;

            Moved?.Invoke(direction);
        }
    }

    private bool IsValidMoving(Vector3 direction)
    {
        return (transform.position + direction).x <= _validDeviation && 
               (transform.position + direction).x >= -_validDeviation;
    } 
}
