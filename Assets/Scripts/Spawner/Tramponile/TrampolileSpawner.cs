using UnityEngine;

public class TrampolileSpawner : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float _chanceTrampolineSpawned;
    [SerializeField] private BarriersSpawner _barrierSpawner;
    [SerializeField] private Trampolne _prefab;

    private void OnEnable()
    {
        _barrierSpawner.BarrierSpawned += OnShortBarrierSpawned;
    }

    private void OnDisable()
    {
        _barrierSpawner.BarrierSpawned -= OnShortBarrierSpawned;
    }

    private void OnShortBarrierSpawned(Barrier barrier)
    {
        if (_chanceTrampolineSpawned != 0 && barrier.CanBeJumpedOver)
        {
            if((int)Random.Range(0, 1/_chanceTrampolineSpawned) == 0)
            {
                Trampolne trampoline = Instantiate(_prefab);
                trampoline.transform.position = barrier.transform.position;
            }
        }
    }
}
