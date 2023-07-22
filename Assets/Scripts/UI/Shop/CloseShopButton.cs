using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseShopButton : MonoBehaviour
{
    [SerializeField] private GameObject _shopCanvas;
    [SerializeField] private GameObject _defaultCanvas;

    private Button _button;

    private void OnEnable()
    {
        if (_button == null)
            _button = GetComponent<Button>();

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _defaultCanvas.SetActive(true);
        _shopCanvas.SetActive(false);
    }
}
