using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Right,
    Left
}

public class UserInput : MonoBehaviour
{
    public event UnityAction<Direction> Moving;

    void Start()
    {
        
    }

    void Update()
    {
        if (Application.isMobilePlatform)
        {
            UseMobileInput();
        }
        else
        {
            UseDecktopInput();
        }
    }
    
    private void UseMobileInput()
    {

    }

    private void UseDecktopInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Moving.Invoke(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Moving.Invoke(Direction.Right);
        }
    }
}
