using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _ball;

    private float _range;

    private void Start()
    {
        _range = transform.position.z - _ball.position.z;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, _ball.position.z - transform.position.z + _range);
    }
}
