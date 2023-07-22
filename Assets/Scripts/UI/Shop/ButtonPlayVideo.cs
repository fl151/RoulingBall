using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonPlayVideo : MonoBehaviour
{
    [SerializeField] private GameObject _windowAddDimonds;
    [SerializeField] private Shop _shop;
    [SerializeField] private TMP_Text _textAddDimondsCount;

    [SerializeField] private int _countDimonds;

    private Button _button;

    private void Awake()
    {
        _textAddDimondsCount.text = "+" + _countDimonds.ToString();
    }

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
        VideoAd.Show(null, OnRewardedCallback);

        _windowAddDimonds.SetActive(false);    
    }

    private void OnRewardedCallback()
    {
        _shop.AddDimonds(_countDimonds);
    }
}