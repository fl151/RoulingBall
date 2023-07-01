using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Results : MonoBehaviour
{
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
        SetToLeaderboardDiamonds(Progress.Instance.PlayerData.Diamonds);

        float range = _playerRange.NewRange;

        if (range >= Progress.Instance.WorldRecordRange)
        {
            _worldRecordCanvas.SetActive(true);

            SaveResults(range);
        }
        else if (Progress.Instance.PlayerData.MaxRange < range)
        {
            _newRecordCanvas.SetActive(true);

            SaveResults(range);
        }
        else
        {
            _defaultCanvas.SetActive(true);
        }   
    }

    private void SaveResults(float range)
    {
        Progress.Instance.PlayerData.MaxRange = range;
        SetToLeaderboardRange(range);
    }

    [DllImport("__Internal")]
    private static extern void SetToLeaderboardRange(float value);

    [DllImport("__Internal")]
    private static extern void SetToLeaderboardDiamonds(int value);
}
