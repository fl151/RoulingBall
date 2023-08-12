using UnityEngine;
using UnityEngine.UI;

public class LoginAsk : MonoBehaviour
{
    [SerializeField] private Button _buttonNo;
    [SerializeField] private Button _buttonYes;

    private void OnEnable()
    {
        _buttonNo.onClick.AddListener(OnButtonNoClick);
        _buttonYes.onClick.AddListener(OnButtonYesClick);
    }

    private void OnDisable()
    {
        _buttonNo.onClick.RemoveListener(OnButtonNoClick);
        _buttonYes.onClick.RemoveListener(OnButtonYesClick);
    }

    private void OnButtonNoClick()
    {
        gameObject.SetActive(false);
    }

    private void OnButtonYesClick()
    {
        Web.AuthAccount();
        gameObject.SetActive(false);
    }

}
