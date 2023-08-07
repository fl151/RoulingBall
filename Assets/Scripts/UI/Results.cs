using UnityEngine;
using Agava.YandexGames;

public class Results : MonoBehaviour
{
    private const string _maxRangeLeaderbordTitle = "LongestRange";

    [SerializeField] private GameObject _defaultCanvas;
    [SerializeField] private GameObject _newRecordCanvas;
    [SerializeField] private GameObject _worldRecordCanvas;

    [SerializeField] private GameStatesControler _gameControler;
    [SerializeField] private PlayerRange _playerRange;
    [SerializeField] private DiamondsCollector _dimondsCollector;

    private void OnEnable()
    {
        _gameControler.GameFinished += OnGameFinished;
    }

    private void OnDisable()
    {
        _gameControler.GameFinished -= OnGameFinished;
    }

    private void OnGameFinished()
    {
        Progress.Instance.PlayerData.Diamonds += _dimondsCollector.Count;

        int range = _playerRange.CurrentRange;


        if (PlayerAccount.IsAuthorized && range > Progress.Instance.WorldRecordRange)
        {
            _worldRecordCanvas.SetActive(true);
            SetNewRangeRecord(range);
        }
        else if (Progress.Instance.PlayerData.MaxRange < range)
        {
            _newRecordCanvas.SetActive(true);
            SetNewRangeRecord(range);
        }
        else
        {
            _defaultCanvas.SetActive(true);
        }

        Progress.SaveDataCloud();
    }

    private void SetNewRangeRecord(int value)
    {
        Progress.Instance.PlayerData.MaxRange = value;

        if (Progress.Instance.WorldRecordRange < value)
            Progress.SetWorldRecord(value);

        if (PlayerAccount.IsAuthorized)
            Leaderboard.SetScore(_maxRangeLeaderbordTitle, value);
    }
}
