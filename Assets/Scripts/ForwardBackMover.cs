using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBackMover : PlayerMover
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow))
        {
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Move(false);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Move(true);
        }
    }

    private void Move(bool isForwardMovement)
    {
        float zComponent = _speed * Time.deltaTime;
        Vector3 direction;

        if (isForwardMovement == false)
        {
            zComponent = -zComponent;
        }

        direction = new Vector3(0, 0, zComponent);
        transform.position += direction;

        Moved?.Invoke(direction);
    }

}
