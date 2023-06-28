using UnityEngine;

public class ForwardMover : PlayerMover
{
    [SerializeField] private float _speed;
    [SerializeField] private GameStatesControler _gameControler;

    private bool _isGamePlaying = false;

    private void OnEnable()
    {
        _gameControler.GameStarted += OnGameStarted;
        _gameControler.PlayerDied += OnPlayerStopped;
        _gameControler.PlayerFinish += OnPlayerStopped;
        _gameControler.SpeedFinded += OnPlayerMoveAgain;
        _gameControler.GameFinished += OnPlayerStopped;
    }

    private void FixedUpdate()
    {
        if (_isGamePlaying)
        {
            Move();
        }
    }

    private void OnDisable()
    {
        _gameControler.GameStarted -= OnGameStarted;
        _gameControler.PlayerDied -= OnPlayerStopped;
        _gameControler.PlayerFinish -= OnPlayerStopped;
        _gameControler.SpeedFinded -= OnPlayerMoveAgain;
        _gameControler.GameFinished -= OnPlayerStopped;
    }

    public void UpSpeed(float increaseTimes)
    {
        float times = GetCorrectTimes(increaseTimes);
        _speed *= times;
    }

    public void DownSpeed(float decreaseTimes)
    {
        float times = GetCorrectTimes(decreaseTimes);
        _speed /= times;
    }

    private void OnGameStarted()
    {
        _isGamePlaying = true;
    }

    private void OnPlayerStopped()
    {
        _isGamePlaying = false;
    }

    private void OnPlayerMoveAgain()
    {
        _isGamePlaying = true;
    }

    private void Move()
    {
        float zComponent = _speed * Time.deltaTime;

        Vector3 direction;
        direction = new Vector3(0, 0, zComponent);
        transform.position += direction;

        Moved?.Invoke(direction);
    }

    private float GetCorrectTimes(float inputTimes)
    {
        if (inputTimes <= 0) return 1;

        inputTimes = Mathf.Clamp(inputTimes, 0, 10);

        return inputTimes;
    }
}
