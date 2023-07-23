using Agava.YandexGames;
using UnityEngine;

public class FillerLeaderboardPanel : MonoBehaviour
{
    private const string _maxRangeLeaderbordTitle = "LongestRange";

    private const string _ruLang = "ru";
    private const string _trLang = "tr";
    private const string _enLang = "en";

    private const string _ruText = "Вы";
    private const string _enText = "You";
    private const string _trText = "Siz";

    [SerializeField] private GameObject _prefabPlayerInfo;
    [SerializeField] private Transform _panelParent;
    [SerializeField] private FillerEntryInfo _playerEntry;

    [SerializeField] private Color[] _colorsFill;

    [SerializeField] private Web _web;

    private void OnEnable()
    {
        _web.PlayerAuth += OnPlayerAuth;
    }

    private void OnDisable()
    {
        _web.PlayerAuth -= OnPlayerAuth;
    }

    private void OnPlayerAuth()
    {
        if (_panelParent.childCount == 0)
            LoadEntries();

        Leaderboard.GetPlayerEntry(_maxRangeLeaderbordTitle, (response) =>
        {
            if (response != null)
                _playerEntry.Fill(GetTextCurrentLanguage(), response.score, response.player.profilePicture);
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

    private string GetTextCurrentLanguage()
    {
        string nameText = "";

        switch (YandexGamesSdk.Environment.browser.lang)
        {
            case _ruLang:
                nameText = _ruText;
                break;

            case _enLang:
                nameText = _enText;
                break;

            case _trLang:
                nameText = _trText;
                break;
        }

        return nameText;
    }
}
