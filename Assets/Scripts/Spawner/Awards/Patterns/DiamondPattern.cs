using UnityEngine;

public class DiamondPattern : IPattern
{
    private const float _yPosition = 0.5f;

    private float _rangeBetweenLines;
    private float _coficient;

    private float _rangeFromTarget;
    private int _count;
    float _rangeBetweenDiamonds;

    public DiamondPattern(DiamondsPatternSettings settings)
    {
        _rangeFromTarget = settings.TargetRange;
        _count = settings.Count;
        _rangeBetweenDiamonds = settings.RangeBetween;
        _rangeBetweenLines = settings.RangeBetweenLines;
        _coficient = settings.InclineCofficient;
    }

    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[_count];

        float zFirst = -(_count - 1) * _rangeBetweenDiamonds / 2;

        for (int i = 0; i < _count; i++)
        {
            float z = zFirst + i * _rangeBetweenDiamonds;
            float x = _rangeFromTarget + Mathf.Clamp(z * _coficient, -_rangeBetweenLines, _rangeBetweenLines);

            positions[i] = new Vector3(x, _yPosition, z);
        }

        return positions;
    }
}
