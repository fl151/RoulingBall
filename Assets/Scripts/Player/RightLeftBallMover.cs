using UnityEngine;

public class RightLeftBallMover : PlayerMover
{
    [SerializeField] private float _speed;

    private void Update()
    {
        
    }

    private void Move(bool isRightMovement)
    {
        float xComponent = _speed * Time.deltaTime;
        Vector3 direction;

        if (isRightMovement == false)
        {
            xComponent = -xComponent;
        }

        direction = new Vector3(xComponent, 0, 0);
        transform.position += direction;

        Moved?.Invoke(direction);
    }

}
