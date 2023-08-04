using UnityEngine;
using UnityEngine.UI;

public class ButtonNo : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private Button _button;
    private PlayerData _data;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    public void Init(PlayerData dataCloud)
    {
        _data = dataCloud;
    }

    private void OnButtonClick()
    {
        Progress.SetData(_data);
        _canvas.SetActive(false);
    }
}
