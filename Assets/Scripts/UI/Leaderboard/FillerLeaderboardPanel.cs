using Agava.YandexGames;
using UnityEngine;

public class FillerLeaderboardPanel : MonoBehaviour
{
    private const string _maxRangeLeaderbordTitle = "LongestRange";

    [SerializeField] private GameObject _prefabPlayerInfo;
    [SerializeField] private Transform _panelParent;
    [SerializeField] private FillerEntryInfo _playerEntry;

    [SerializeField] private Color[] _colorsFill;

    private void OnEnable()
    {
        Web.Instance.PlayerAuth += OnPlayerAuth;
    }

    private void OnDisable()
    {
        Web.Instance.PlayerAuth -= OnPlayerAuth;
    }

    private void OnPlayerAuth()
    {
        if (_panelParent.childCount == 0)
            LoadEntries();

        Leaderboard.GetPlayerEntry(_maxRangeLeaderbordTitle, (response) =>
        {
            if (response != null)
                _playerEntry.Fill("You", response.score, response.player.profilePicture);
            else
                _playerEntry.gameObject.SetActive(false);
        });
    }

    private void LoadEntries()
    {
        Leaderboard.GetEntries(_maxRangeLeaderbordTitle, (response) =>
        {
            Progress.SetWorldRecord(response.entries[0].score);

            SetEntryes(response);
        });
    }

    private void SetEntryes(LeaderboardGetEntriesResponse response)
    {
        for (int i = 0; i < response.entries.Length; i++)
        {
            LeaderboardEntryResponse entry = response.entries[i];

            var entryInfo = Instantiate(_prefabPlayerInfo, _panelParent).GetComponent<FillerEntryInfo>();

            entryInfo.Fill(entry.player.publicName, entry.score, entry.player.profilePicture);

            if (i < _colorsFill.Length)
                entryInfo.SetFillColor(_colorsFill[i]);
            else
                entryInfo.SetFillColor(_colorsFill[^1]);
        }
    }
}
