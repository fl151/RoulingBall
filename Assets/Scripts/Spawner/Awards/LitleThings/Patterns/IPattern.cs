using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPattern
{
    public Vector3[] GetPositions(int count, float rangeFromTarget, float rangeBetweenThings);
}
