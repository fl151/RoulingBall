using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonCloseAddDimonds : MonoBehaviour
{
    [SerializeField] private GameObject _windowAddDimonds;

    private Button _button;

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
        _windowAddDimonds.SetActive(false);
    }
}
