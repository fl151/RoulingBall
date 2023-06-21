using System.Collections;
using UnityEngine;

public class ThingsSpawner : MonoBehaviour
{
    [SerializeField] private Thing _prefab;

    public void ExecutPattern(Vector3 barrierPosition, IPattern pattern)
    {
        SpawnThings(barrierPosition, pattern.GetPositions(30, 0.1f));
    }

    private void SpawnThings(Vector3 barrierPosition, Vector3[] localPositionsAroundBasrrier)
    {
        StartCoroutine(SpanwThings(barrierPosition, localPositionsAroundBasrrier));
    }

    private IEnumerator SpanwThings(Vector3 barrierPosition, Vector3[] localPositionsAroundBasrrier)
    {
        var delay = new WaitForEndOfFrame();

        foreach (var localPosition in localPositionsAroundBasrrier)
        {
            yield return delay;

            var thing = Instantiate(_prefab, gameObject.transform);

            thing.transform.position = barrierPosition + localPosition;
        }
    }
}
