using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefaultGameResultCanvas : MonoBehaviour
{
    private const int _mainSceneIndex = 1;

    [SerializeField] private TMP_Text _diamondsCount;
    [SerializeField] private TMP_Text _range;
    [SerializeField] private PlayerRange _playerRange;
    [SerializeField] private Button _playAgainButton;

    private void OnEnable()
    {
        _playAgainButton.onClick.AddListener(OnButtonClicked);
    }

    private void Start()
    {
        _diamondsCount = GetComponentInChildren<DiamondsCount>().GetComponent<TMP_Text>();

        _diamondsCount.text = Progress.Instance.PlayerData.Diamonds.ToString();

        _range.text = _playerRange.CurrentRange.ToString();
    }

    private void OnDisable()
    {
        _playAgainButton.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        SceneManager.LoadScene(_mainSceneIndex);
    }
}
