using UnityEngine;

public class KeyboardInput : UserInput
{
    private void Update()
    {
        if (_isFirstContactHappened == false && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            FirstContactHappend?.Invoke();
            _isFirstContactHappened = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Moving?.Invoke(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Moving?.Invoke(Vector3.right);
        }
    }
}
