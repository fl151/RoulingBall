using UnityEngine;

public class HUDChanger : MonoBehaviour
{
    [SerializeField] private GameObject _mobileHUD;
    [SerializeField] private GameObject _decktopHUD;

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            _mobileHUD.SetActive(true);
        }
        else
        {
            _decktopHUD.SetActive(true);
        }
    }
}
