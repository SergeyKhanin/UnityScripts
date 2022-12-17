using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [Space(10.0f)] 
    [SerializeField] private Transform _paths;
    [SerializeField] private Transform _target;
    [Space(10.0f)] 
    [SerializeField] private bool _isPatrolActive;
    [Space(10.0f)] 
    [SerializeField] private float _speed;

    private int _index;
    private float _speedTemp;

    private void Awake()
    {
        _speedTemp = _speed;
    }

    private void Update()
    {
        if (!_isPatrolActive)
            SetTarget();
        else
            SetPatrol();
    }

    private void SetPatrol()
    {
        _speed = _speedTemp;

        if (transform.position == _paths.GetChild(_index).position)
            _index++;
        if (_index == _paths.childCount)
            _index = 0;

        MoveTowards(transform.position, _paths.GetChild(_index).position);
    }

    private void SetTarget()
    {
        _speed = _speedTemp * 2.0f;

        MoveTowards(transform.position, _target.position);

        if (transform.position == _target.position)
            _isPatrolActive = true;
    }

    private void MoveTowards(Vector3 current, Vector3 target)
    {
        var targetPosition = Vector3.MoveTowards(current, target, _speed * Time.deltaTime);
        transform.position = targetPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isPatrolActive = false;
    }
}