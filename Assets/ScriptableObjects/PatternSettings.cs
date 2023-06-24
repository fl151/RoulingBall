using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PatternSettings", fileName = "PatternSettings", order = 52)]
public class PatternSettings : ScriptableObject
{
    [SerializeField] private float _targetRange;
    [SerializeField] private int _count;
    [SerializeField] private float _rangeBetween;

    public float TargetRange => _targetRange;
    public int Count => _count;
    public float RangeBetween => _rangeBetween;
}
