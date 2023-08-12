using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

[RequireComponent(typeof(Button))]
public class LeaderboardButton : MonoBehaviour
{
    [SerializeField] private GameObject _defaultCanvas;
    [SerializeField] private GameObject _leaderboardCanvas;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
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
        if (PlayerAccount.IsAuthorized)
        {
            _leaderboardCanvas.SetActive(true);
            _leaderboardCanvas.GetComponentInChildren<CloseLeaderboardButton>().SetDefaultCanvas(_defaultCanvas);
            _defaultCanvas.SetActive(false);
        }
        else
        {
            Web.AuthAccount();
        }
    }
}
