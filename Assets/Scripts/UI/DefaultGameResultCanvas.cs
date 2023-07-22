using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Agava.YandexGames;

public class DefaultGameResultCanvas : MonoBehaviour
{
    private const int _mainSceneIndex = 1;
    private const float _adChance = 0.2f;

    [SerializeField] private TMP_Text _diamondsCount;
    [SerializeField] private TMP_Text _range;
    [SerializeField] private PlayerRange _playerRange;
    [SerializeField] private Button _playAgainButton;

    private void OnEnable()
    {
        _playAgainButton.onClick.AddListener(OnButtonPlayAgainClicked);
    }

    private void Start()
    {
        _diamondsCount.text = Progress.Instance.PlayerData.Diamonds.ToString();

        _range.text = _playerRange.CurrentRange.ToString();      
    }

    private void OnDisable()
    {
        _playAgainButton.onClick.RemoveListener(OnButtonPlayAgainClicked);
    }

    private void OnButtonPlayAgainClicked()
    {
        if (Random.Range(0, 1) <= _adChance)
            InterstitialAd.Show();

        SceneManager.LoadScene(_mainSceneIndex);
    }
}
