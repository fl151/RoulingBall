using System.Collections;
using UnityEngine;

public class PatternsExecuter : MonoBehaviour
{
    public void ExecutPattern(IPattern pattern, Award template, Vector3 barrierPosition)
    {
        SpawnThings(template, barrierPosition, pattern.GetPositions());
    }

    private void SpawnThings(Award template, Vector3 barrierPosition, Vector3[] localPositionsAroundBasrrier)
    {
        StartCoroutine(SpanwThings(template, barrierPosition, localPositionsAroundBasrrier));
    }

    private IEnumerator SpanwThings(Award template, Vector3 barrierPosition, Vector3[] localPositionsAroundBasrrier)
    {
        var delay = new WaitForEndOfFrame();

        foreach (var localPosition in localPositionsAroundBasrrier)
        {
            yield return delay;

            var thing = Instantiate(template, gameObject.transform);
            thing.transform.position = barrierPosition + localPosition;
        }
    }
}
