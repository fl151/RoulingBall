using UnityEngine;
using UnityEngine.UI;

public class ButtonYes : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        var data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("data"));

        Progress.SetData(data);
        _canvas.SetActive(false);
    }
}
