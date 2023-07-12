using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefaultGameResultCanvas : MonoBehaviour
{
    private const int _mainSceneIndex = 1;

    [SerializeField] private TMP_Text _diamondsCount;
    [SerializeField] private TMP_Text _range;
    [SerializeField] private Button _button;
    [SerializeField] private PlayerRange _playerRange;

    private void OnEnable()
    {
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void Start()
    {
        _diamondsCount = GetComponentInChildren<DiamondsCount>().GetComponent<TMP_Text>();

        _diamondsCount.text = Progress.Instance.PlayerData.Diamonds.ToString();

        _range.text = _playerRange.CurrentRange.ToString();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(_mainSceneIndex);
    }
}
