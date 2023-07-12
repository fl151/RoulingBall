using Agava.WebUtility;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;

public class Web : MonoBehaviour
{
    private static LeaderboardGetEntriesResponse _response;

    public static Web Instance;

    public static event UnityAction<LeaderboardGetEntriesResponse> EntriesLoaded;

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

    private void Start()
    {
        if(_response != null)
            EntriesLoaded?.Invoke(_response);
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
}
