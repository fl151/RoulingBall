using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

[RequireComponent(typeof(Button))]
public class ButtonAddDimonds : MonoBehaviour
{
    [SerializeField] private GameObject _windowAddDimonds;

    private Button _button;

    private void OnEnable()
    {
        if (_button == null)
            _button = GetComponent<Button>();

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (PlayerAccount.IsAuthorized)
            _windowAddDimonds.SetActive(true);
        else
            Web.AuthAccount();
    }
}
