using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ButtonShop : MonoBehaviour
{
    [SerializeField] private GameObject _shopCanvas;
    [SerializeField] private GameObject _defaultCanvas;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        if (PlayerAccount.IsAuthorized == false)
        {
            _button.enabled = false;
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _shopCanvas.SetActive(true);
        _defaultCanvas.SetActive(false);
    }
}
