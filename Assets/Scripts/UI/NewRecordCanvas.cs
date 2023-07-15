using UnityEngine;

[RequireComponent(typeof(UserInputSkip))]
public class NewRecordCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _defaultCanvas;

    private UserInputSkip _input;

    private void OnEnable()
    {
        _input = GetComponent<UserInputSkip>();
        _input.PlayerInteract += OnPlayerInteracted;
    }

    private void OnDisable()
    {
        _input.PlayerInteract -= OnPlayerInteracted;
    }

    private void OnPlayerInteracted()
    {
        _defaultCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
