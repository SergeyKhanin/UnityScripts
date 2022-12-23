using UnityEngine;

public class RotationBySpeed : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(_direction * (Time.deltaTime * _speed));
    }
}