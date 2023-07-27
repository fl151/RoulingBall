using UnityEngine;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    [SerializeField] private HUDChanger _hudChanger;
    [SerializeField] private UserInputControler _inputController;

    public static StartCanvas Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            _hudChanger.enabled = true;
            _inputController.enabled = true;

            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnButtonPlay);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnButtonPlay);
    }

    private void OnButtonPlay()
    {
        _hudChanger.enabled = true;
        _inputController.enabled = true;

        gameObject.SetActive(false);
    }
}
