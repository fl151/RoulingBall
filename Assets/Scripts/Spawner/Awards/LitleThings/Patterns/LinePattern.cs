using UnityEngine;

public class LinePattern : IPattern
{
    private float _rangeFromTarget;
    private int _count;
    float _rangeBetweenThings;

    public LinePattern(PatternSettings settings)
    {
        _rangeFromTarget = settings.TargetRange;
        _count = settings.Count;
        _rangeBetweenThings = settings.RangeBetween;
    }

    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[_count];

        float zFirst = - (_count - 1) * _rangeBetweenThings / 2;

        for (int i = 0; i < _count; i++)
        {
            positions[i] = new Vector3(_rangeFromTarget, 0, zFirst + i * _rangeBetweenThings);
        }

        return positions;
    }
}
