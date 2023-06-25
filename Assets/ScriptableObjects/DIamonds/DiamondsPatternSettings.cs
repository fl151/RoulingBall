using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PatternSettings/Diamonds", fileName = "PatternSettings", order = 52)]
public class DiamondsPatternSettings : PatternSettings
{
    [SerializeField] private float _rangeBetweenLines;
    [SerializeField] private float _inclineCofficient;

    public float RangeBetweenLines => _rangeBetweenLines;
    public float InclineCofficient => _inclineCofficient;
}
