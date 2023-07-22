using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

[RequireComponent(typeof(Button))]
public class ButtonAddDimonds : MonoBehaviour
{
    [SerializeField] private GameObject _windowAddDimonds;
    [SerializeField] private GameObject _warringAccountProblem;
    [SerializeField] private bool _makeActive;
    

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
        if (PlayerAccount.IsAuthorized)
            _windowAddDimonds.SetActive(_makeActive);
        else
            _warringAccountProblem.SetActive(true);
    }

}
