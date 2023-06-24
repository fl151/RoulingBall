using UnityEngine;

public class Thing : Award
{
    private bool _isOnceConnected = false;

    public bool IsOnceConnected => _isOnceConnected;

    public void Connected()
    {
        _isOnceConnected = true;
    }
}
