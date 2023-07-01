using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    [SerializeField] private GameStatesControler _gameController;

    private float _startZ;
    private float _finishZ;

    private float _newPlayerRange;

    public float NewRange => _newPlayerRange;

    private void OnEnable()
    {
        _gameController.PlayerFinish += OnPlayerFinish;
        _gameController.GameFinished += OnGameFinished;
    }

    private void OnDisable()
    {
        _gameController.PlayerFinish -= OnPlayerFinish;
        _gameController.GameFinished -= OnGameFinished;
    }

    private void OnPlayerFinish()
    {
        _startZ = transform.position.z;
    }

    private void OnGameFinished()
    {
        _finishZ = transform.position.z;
        _newPlayerRange = _finishZ - _startZ;
    }

}
