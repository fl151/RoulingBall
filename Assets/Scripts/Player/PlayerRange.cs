using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    [SerializeField] private GameStatesControler _gameController;

    private float _startZ;
    private float _finishZ;

    public int CurrentRange => (int)(GetNewRange() * 10);

    private void OnEnable()
    {
        _gameController.PlayerFinish += OnPlayerFinish;
    }

    private void OnDisable()
    {
        _gameController.PlayerFinish -= OnPlayerFinish;
    }

    private void OnPlayerFinish()
    {
        _startZ = transform.position.z;
    }

    private float GetNewRange()
    {
        _finishZ = transform.position.z;

        return _finishZ - _startZ;
    }

}
