using Agava.WebUtility;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;

public class Web : MonoBehaviour
{
    public static Web Instance;

    public event UnityAction PlayerAuth;

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
        PlayerAuth?.Invoke();

        PlayerAccount.RequestPersonalProfileDataPermission();

        PlayerAccount.GetCloudSaveData((data) => Progress.SetDataFromJSON(data));
    } 
}
