using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PatternSettings/Things", fileName = "PatternSettings", order = 52)]
public class PatternSettings : ScriptableObject
{
    [SerializeField] protected float _targetRange;
    [SerializeField] protected int _count;
    [SerializeField] protected float _rangeBetween;

    public float TargetRange => _targetRange;
    public int Count => _count;
    public float RangeBetween => _rangeBetween;
}
