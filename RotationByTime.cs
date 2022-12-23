using UnityEngine;

public class RotationByTime : MonoBehaviour
{
    [SerializeField] private Quaternion _rotateToAngle;
    [SerializeField] private float _time;

    private float _timeCount = 0.0f;

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _rotateToAngle, _time * _timeCount);
        _timeCount = _timeCount + Time.deltaTime;
    }
}