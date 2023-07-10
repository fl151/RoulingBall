using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefaultGameResultCanvas : MonoBehaviour
{
    private const int _mainSceneIndex = 1;

    private TMP_Text _text;
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void Start()
    {
        _text = GetComponentInChildren<DiamondsCount>().GetComponent<TMP_Text>();

        _text.text = Progress.Instance.PlayerData.Diamonds.ToString();
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
