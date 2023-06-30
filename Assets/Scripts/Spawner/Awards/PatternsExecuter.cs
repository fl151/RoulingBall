using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PatternsExecuter : MonoBehaviour
{
    public event UnityAction<Thing> ThingSpawned;

    public void ExecutPattern(IPattern pattern, Award template, Vector3 barrierPosition)
    {
        SpawnAward(template, barrierPosition, pattern.GetPositions());
    }

    private void SpawnAward(Award template, Vector3 barrierPosition, Vector3[] localPositionsAroundBasrrier)
    {
        StartCoroutine(SpanwAward(template, barrierPosition, localPositionsAroundBasrrier));
    }

    private IEnumerator SpanwAward(Award template, Vector3 barrierPosition, Vector3[] localPositionsAroundBasrrier)
    {
        var delay = new WaitForEndOfFrame();

        foreach (var localPosition in localPositionsAroundBasrrier)
        {
            yield return delay;

            var award = Instantiate(template, gameObject.transform);
            award.transform.position = barrierPosition + localPosition;

            if(award is Thing)
            {
                ThingSpawned?.Invoke(award as Thing);
            }
        }
    }
}
