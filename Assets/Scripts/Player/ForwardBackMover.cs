using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBackMover : PlayerMover
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
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

    public void UpSpeed(float increaseTimes)
    {
        float times = GetCorrectTimes(increaseTimes);

        _speed *= times;
    }

    public void DownSpeed(float decreaseTimes)
    {
        float times = GetCorrectTimes(decreaseTimes);

        _speed /= times;
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

    private float GetCorrectTimes(float inputTimes)
    {
        if (inputTimes == 0) return 1;

        inputTimes = Mathf.Clamp(inputTimes, 0, 10);

        return inputTimes;
    }
}
