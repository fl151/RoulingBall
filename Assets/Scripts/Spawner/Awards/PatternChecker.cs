using UnityEngine;

[ExecuteAlways]
public class PatternChecker : MonoBehaviour
{
    [SerializeField] private bool _ternOn;
    [SerializeField] private PatternsExecuter _spawner;
    [SerializeField] private PatternSettings _settings;
    [SerializeField] private Award _template;

    private bool _currentTern;

    private void Update()
    {
        if(Application.isPlaying == false)
        {
            if(_ternOn != _currentTern)
            {
                _currentTern = _ternOn;

                _spawner.ExecutPattern(new ParabPattern(_settings), _template, transform.position);
            }
        }
    }
}
