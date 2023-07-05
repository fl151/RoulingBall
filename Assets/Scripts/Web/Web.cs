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

    private static void UpdateWorldRecord()
    {
        Leaderboard.GetEntries(_maxRangeLeaderbordTitle, SetTopRange);
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

        UpdateWorldRecord();
    }

    private void AuthAccount()
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize(OnPlayerAuth);
        }
        else
        {
            OnPlayerAuth();
        }
    }

    private static void SetTopRange(LeaderboardGetEntriesResponse leaderboardGetEntriesResponse)
    {
        Progress.SetWorldRecord(leaderboardGetEntriesResponse.entries[0].score);
    }

    private void OnPlayerAuth()
    {
        PlayerAccount.GetCloudSaveData(Progress.SetDataFromJSON);

        if (PlayerAccount.HasPersonalProfileDataPermission == false && Progress.Instance.PlayerData.IsAskedAboutPersonalData == false)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();

            Progress.Instance.PlayerData.IsAskedAboutPersonalData = true;

            Progress.SaveDataCloud();

            PlayerAccount.GetCloudSaveData(Progress.SetDataFromJSON);
        } 
    }
}
