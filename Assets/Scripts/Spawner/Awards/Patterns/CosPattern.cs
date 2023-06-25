using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosPattern : IPattern
{
    private float _rangeFromTarget;
    private int _count;
    private float _rangeBetweenThings;

    public CosPattern(PatternSettings settings)
    {
        _rangeFromTarget = settings.TargetRange;
        _count = settings.Count;
        _rangeBetweenThings = settings.RangeBetween;
    }

    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[_count];

        float zFirst = -(_count - 1) * _rangeBetweenThings / 2;

        for (int i = 0; i < _count; i++)
        {
            float z = zFirst + i * _rangeBetweenThings;

            float x = Mathf.Cos(z) * _rangeFromTarget;

            positions[i] = new Vector3(x, 0, z);
        }

        return positions;
    }
}
