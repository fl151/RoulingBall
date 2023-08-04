using UnityEngine;

public class ProgressAsk : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private ButtonNo _button;

    private void OnEnable()
    {
        Progress.Instance.NeedAsk += Ask;
    }

    private void OnDisable()
    {
        Progress.Instance.NeedAsk -= Ask;
    }

    private void Ask(PlayerData dataCloud)
    {
        _canvas.SetActive(true);
        _button.Init(dataCloud);
    }
}
