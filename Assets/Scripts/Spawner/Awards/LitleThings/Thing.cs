using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Thing : Award
{
    private SphereCollider _collider;

    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
    }

    public void Connect()
    {
        _collider.enabled = false;
    }
}
