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
            InterstitialAd.Show(OnOpenCallback, OnCloseCallback, OnErrorCallback, OnOfflineCallback);
        else
            SceneManager.LoadScene(_mainSceneIndex);
    }

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
    }

    private void OnCloseCallback(bool flag)
    {
        ContinueGame();
    }

    private void OnErrorCallback(string error)
    {
        ContinueGame();
    }

    private void OnOfflineCallback()
    {
        ContinueGame();
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(_mainSceneIndex);
    }
}
