using UnityEngine;

[RequireComponent(typeof(ThingsSpawner))]
public class FinderRandomPattern : MonoBehaviour
{
    [SerializeField] private BarriersSpawner _barrierSpawner;

    private ThingsSpawner _thingsSpawner;

    private const float _standartTargetRange = 1.6f;

    private IPattern[] _centerPatterns = { new LinePattern(_standartTargetRange), new LinePattern(-_standartTargetRange), 
                                           new CosPattern(_standartTargetRange), new CosPattern(-_standartTargetRange) };
    private IPattern[] _leftPatterns = { new LinePattern(_standartTargetRange), new CosPattern(_standartTargetRange), };
    private IPattern[] _rightPatterns = { new LinePattern(-_standartTargetRange), new CosPattern(-_standartTargetRange) };

    private void Awake()
    {
        _thingsSpawner = GetComponent<ThingsSpawner>();
    }

    private void OnEnable()
    {
        _barrierSpawner.BarrierSpawned += OnBarrierSpawned;
    }

    private void OnDisable()
    {
        _barrierSpawner.BarrierSpawned -= OnBarrierSpawned;
    }

    private void OnBarrierSpawned(Barrier barrier)
    {
        switch (barrier.Position)
        {
            case Position.Center:
                UsePattern(GetRandomPattern(_centerPatterns), barrier);
                break;

            case Position.Left:
                UsePattern(GetRandomPattern(_leftPatterns), barrier);
                break;

            case Position.Right:
                UsePattern(GetRandomPattern(_rightPatterns), barrier);
                break;

            default:
                Debug.LogError("У барьера не выбрана позиция");
                break;
        }
    }

    private void UsePattern(IPattern pattern, Barrier barrier)
    {
        _thingsSpawner.ExecutPattern(barrier.transform.position, pattern);
    }

    private IPattern GetRandomPattern(IPattern[] patterns)
    {
        return patterns[Random.Range(0, patterns.Length)];
    }
}
