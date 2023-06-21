using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosPattern : IPattern
{
    private float _rangeFromTarget;

    public CosPattern(float rangeFromTarget)
    {
        _rangeFromTarget = rangeFromTarget;
    }

    public Vector3[] GetPositions(int count, float rangeBetweenThings)
    {
        Vector3[] positions = new Vector3[count];

        float zFirst = -(count - 1) * rangeBetweenThings / 2;

        for (int i = 0; i < count; i++)
        {
            float z = zFirst + i * rangeBetweenThings;

            float x = Mathf.Cos(z) * _rangeFromTarget;

            positions[i] = new Vector3(x, 0, z);
        }

        return positions;
    }
}
