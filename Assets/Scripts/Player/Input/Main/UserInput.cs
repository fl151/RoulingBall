using UnityEngine;
using UnityEngine.Events;

public class UserInput : MonoBehaviour
{
    protected bool _isFirstContactHappened = false;

    public UnityAction<Vector3> Moving;
    public UnityAction FirstContactHappend;
}
