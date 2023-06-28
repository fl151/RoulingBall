using System.Collections;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private GameStatesControler _gameControler;

    private const float _closeEnoughRange = 0.8f;
    private const float _timesRangeForBallAfterFinish = 1.2f;

    private float _range;

    private void OnEnable()
    {
        _gameControler.PlayerFinish += OnPlayerFinished;
    }

    private void Start()
    {
        _range = transform.position.z - _ball.position.z;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0, _ball.position.z - transform.position.z + _range);
    }

    private void OnDisable()
    {
        _gameControler.PlayerFinish += OnPlayerFinished;
    }

    private void OnPlayerFinished()
    {
        StartCoroutine(MoveBack());
    }

    private IEnumerator MoveBack()
    {
        var delay = new WaitForFixedUpdate();

        Vector3 targetPosition = (transform.position - _ball.position) * _timesRangeForBallAfterFinish;
        targetPosition += _ball.position;
        targetPosition.x = transform.position.x;

        while(IsPositionFarAway(targetPosition))
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);

            yield return delay;
        } 
    }

    private bool IsPositionFarAway(Vector3 targetPosition)
    {
        return (targetPosition - transform.position).magnitude > _closeEnoughRange;
    }
}
