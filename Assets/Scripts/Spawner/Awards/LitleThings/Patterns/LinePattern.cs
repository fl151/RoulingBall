using UnityEngine;

public class LinePattern : IPattern
{
    private float _rangeFromTarget;

    public LinePattern(float rangeFromTarget)
    {
        _rangeFromTarget = rangeFromTarget;
    }

    public Vector3[] GetPositions(int count, float rangeBetweenThings)
    {
        Vector3[] positions = new Vector3[count];

        float zFirst = - (count - 1) * rangeBetweenThings / 2;

        for (int i = 0; i < count; i++)
        {
            positions[i] = new Vector3(_rangeFromTarget, 0, zFirst + i * rangeBetweenThings);
        }

        return positions;
    }
}
