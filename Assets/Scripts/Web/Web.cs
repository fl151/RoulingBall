using Agava.WebUtility;
using UnityEngine;
using Agava.YandexGames;

public class Web : MonoBehaviour
{
    private const string _maxRangeLeaderbordTitle = "LongestRange";

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
            OnYandexInitialized();
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

    private static void UpdateWorldRecord()
    {
        Leaderboard.GetEntries(_maxRangeLeaderbordTitle,  (response) =>
        {
            Progress.SetWorldRecord(response.entries[0].score);
        });
    }
}
