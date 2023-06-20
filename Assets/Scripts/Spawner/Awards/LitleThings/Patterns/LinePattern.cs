using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePattern : IPattern
{
    public Vector3[] GetPositions(int count, float rangeFromTarget, float rangeBetweenThings)
    {
        Vector3[] positions = new Vector3[count];

        float zFirst = - (count - 1) * rangeBetweenThings / 2;

        for (int i = 0; i < count; i++)
        {
            positions[i] = new Vector3(rangeFromTarget, 0, zFirst + i * rangeBetweenThings);
        }

        return positions;
    }
}
