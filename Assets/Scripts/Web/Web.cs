using Agava.WebUtility;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;

public class Web : MonoBehaviour
{
    public event UnityAction PlayerAuth;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void Start()
    {
        AuthAccount();
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
        PlayerAccount.RequestPersonalProfileDataPermission();

        PlayerAccount.GetCloudSaveData((data) => 
        { 
            Progress.SetDataFromJSON(data);
            PlayerAuth?.Invoke();
        });
    } 
}
