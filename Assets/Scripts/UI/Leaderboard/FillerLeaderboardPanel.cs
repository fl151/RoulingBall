using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

public class FillerLeaderboardPanel : MonoBehaviour
{
    [SerializeField] private GameObject _prefabPlayerInfo;
    [SerializeField] private Transform _panelParent;

    [SerializeField] private Color[] _colorsFill;

    private void Awake()
    {
        Web.EntriesLoaded += SetEntryes;
    }

    private void OnDisable()
    {
        Web.EntriesLoaded -= SetEntryes;
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
