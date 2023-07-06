using UnityEngine;
using UnityEngine.UI;

public class NewRecordCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _defaultCanvas;

    private Button _button;

    private void OnEnable()
    {
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _defaultCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

}
