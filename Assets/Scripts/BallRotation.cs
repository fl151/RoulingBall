using UnityEngine;

public class BallRotation : MonoBehaviour
{
    [SerializeField] private PlayerMover[] _movers;

    private void Start()
    {
        foreach (var mover in _movers)
        {
            mover.Moved += OnBallMoved;
        }
    }

    private void OnBallMoved(Vector3 moveDirection)
    {
        Vector3 scale = transform.localScale;

        transform.Rotate(GetAngleInDegrees(moveDirection.z, scale.z),
                         0,
                         GetAngleInDegrees(-moveDirection.x, scale.z), Space.World);
    }

    private float GetAngleInDegrees(float movement, float scale)
    {
        return movement * (1/scale) / Mathf.PI * 180;
    }
}
