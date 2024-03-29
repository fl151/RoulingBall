using UnityEngine;

public class ParabPattern : IPattern
{
    private float _rangeFromTarget;
    private int _count;
    private float _rangeBetweenThings;

    public ParabPattern(PatternSettings settings)
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

            float x = (z*z / 2.65f - 1) * (-_rangeFromTarget);

            positions[i] = new Vector3(x, 0, z);
        }

        return positions;
    }
}
