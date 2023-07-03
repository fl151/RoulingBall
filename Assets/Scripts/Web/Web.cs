using System.Collections;
using Agava.WebUtility;
using Agava.YandexGames;
using UnityEngine;

public class Web : MonoBehaviour
{
    private const string _maxRangeLeaderbordTitle = "MaxRange";

    public static Web Instance;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;

            StartCoroutine(InitializeYandex());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0f : 1f;
    }

    private IEnumerator InitializeYandex()
    {
        yield return YandexGamesSdk.Initialize();

        OnYandexInitialized();
    }

    private void OnYandexInitialized()
    {
        AuthAccount();

        Leaderboard.GetEntries(_maxRangeLeaderbordTitle, SetTopRange, null, 1);
    }

    private void AuthAccount()
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize(OnPlayerAuth);
        }
    }

    private void SetTopRange(LeaderboardGetEntriesResponse leaderboardGetEntriesResponse)
    {
        if (leaderboardGetEntriesResponse.entries.Length != 0)
            Progress.SetWorldRecord(leaderboardGetEntriesResponse.entries[0].score);
    }

    private void SetData(string json)
    {
        Progress.SetData(json);
    }

    private void OnPlayerAuth()
    {
        PlayerAccount.GetCloudSaveData(SetData);
    }
}
