using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private bool _canBeJumpetOver;

    public bool CanBeJumpedOver => _canBeJumpetOver;
}
