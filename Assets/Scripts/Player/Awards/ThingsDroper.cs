using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ThingsDroper : MonoBehaviour
{
    [SerializeField] private GameStatesControler _gameControler;

    private const float _delayBetweenDropSeconds = 0.01f;

    private ThindsCollector _collector;

    public event UnityAction ThingsFinished;

    private void OnEnable()
    {
        _gameControler.SpeedFinded += OnPlayerStartMoveAfterFinish;
    }

    private void Start()
    {
        _collector = GetComponent<ThindsCollector>();
    }

    private void OnDisable()
    {
        _gameControler.SpeedFinded -= OnPlayerStartMoveAfterFinish;
    }

    private void OnPlayerStartMoveAfterFinish()
    {
        StartCoroutine(DropeThings());
    }

    private IEnumerator DropeThings()
    {
        var delay = new WaitForSeconds(_delayBetweenDropSeconds);

        while (_collector.TryGetThing(out Thing thing))
        { 
            DropeThing(thing);

            yield return delay;
        }

        ThingsFinished?.Invoke();
    }

    private void DropeThing(Thing thing)
    {
        float rangeRay = 5f;

        RaycastHit hit;

        thing.transform.parent = null;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, rangeRay))
        {
            thing.transform.SetPositionAndRotation(hit.point, new Quaternion(0, 0, 0, 0));
        }
    }
}
