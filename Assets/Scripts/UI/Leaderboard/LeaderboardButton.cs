using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

[RequireComponent(typeof(Button))]
public class LeaderboardButton : MonoBehaviour
{
    [SerializeField] private GameObject _defaultCanvas;
    [SerializeField] private GameObject _leaderboardCanvas;

    [SerializeField] private Color _notActiveColor;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        if (PlayerAccount.IsAuthorized == false)
        {
            _button.enabled = false;
            _button.GetComponent<Image>().color = _notActiveColor;
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
        _leaderboardCanvas.SetActive(true);
        _defaultCanvas.SetActive(false);
    }
}
