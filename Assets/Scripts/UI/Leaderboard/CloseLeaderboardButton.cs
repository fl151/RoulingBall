using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseLeaderboardButton : MonoBehaviour
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
        _defaultCanvas.SetActive(true);
        _leaderboardCanvas.SetActive(false);
    }
}
