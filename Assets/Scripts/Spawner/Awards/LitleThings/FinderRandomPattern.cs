using UnityEngine;

[RequireComponent(typeof(PatternsExecuter))]
public class FinderRandomPattern : MonoBehaviour
{
    [SerializeField] private PatternSettings _settingsThingsRight;
    [SerializeField] private PatternSettings _settingsThingsLeft;
    [SerializeField] private PatternSettings _settingsDiamonds;

    private IPattern[] _centerPatternsThings;
    private IPattern[] _leftPatternsThings;
    private IPattern[] _rightPatternsThings;

    private IPattern[] _diamondsPatterns;

    private void Awake()
    {
        _centerPatternsThings = new IPattern[] { new LinePattern(_settingsThingsRight), new LinePattern(_settingsThingsLeft),
                                                 new CosPattern(_settingsThingsRight), new CosPattern(_settingsThingsLeft) };
        _leftPatternsThings = new IPattern[] { new LinePattern(_settingsThingsLeft), new CosPattern(_settingsThingsLeft) };
        _rightPatternsThings = new IPattern[] { new LinePattern(_settingsThingsRight), new CosPattern(_settingsThingsRight) };
    }

    public IPattern GetRandomThingsPattern(Barrier barrier)
    {
        IPattern pattern = default;

        switch (barrier.Position)
        {
            case Position.Center:
                pattern = GetRandomPattern(_centerPatternsThings);
                break;

            case Position.Left:
                pattern = GetRandomPattern(_leftPatternsThings);
                break;

            case Position.Right:
                pattern = GetRandomPattern(_rightPatternsThings);
                break;

            default:
                Debug.LogError("У барьера не выбрана позиция");
                break;
        }

        return pattern;
    }

    public IPattern GetPandomDimondsPattern()
    {
        return GetRandomPattern(_diamondsPatterns);
    }

    private IPattern GetRandomPattern(IPattern[] patterns)
    {
        return patterns[Random.Range(0, patterns.Length)];
    }
}
