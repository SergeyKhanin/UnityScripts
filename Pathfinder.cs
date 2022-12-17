using UnityEngine;
using UnityEngine.Serialization;

public class Pathfinder : MonoBehaviour
{
    [Space(10.0f)] 
    [SerializeField] private Transform _waypoints;
    [SerializeField] private Transform _target;
    [SerializeField] private bool _randomWayHasActive;
    [SerializeField] private bool _randomSpeedHasActive;
    [Space(10.0f)] 
    [SerializeField] private float _speed;
    [Space(10.0f)] 
    [SerializeField] private float _findDistance;
    [SerializeField] private float _loseDistance;

    private bool _isPatrolActive;
    private int _index;
    private float _speedTemp;

    private void Awake()
    {
        _speedTemp = _speed;
        _isPatrolActive = true;
        _index = Random.Range(0, _waypoints.childCount);
    }

    private void Start()
    {
        if (_randomWayHasActive)
            RandomWay();
    }

    private void Update()
    {
        switch (_isPatrolActive)
        {
            case true:
                SetPatrol();
                FindTarget();
                break;

            case false:
                SetTarget();
                LoseTarget();
                break;
        }
    }

    private float CheckDisatnce()
    {
        var result = Vector3.Distance(transform.position, _target.position);
        return result;
    }

    private void SetPatrol()
    {
        _speed = SpeedChooser();

        switch (_randomWayHasActive)
        {
            case true:
                if (transform.position == _waypoints.GetChild(_index).position)
                    RandomWay();
                break;
            case false:
                if (transform.position == _waypoints.GetChild(_index).position)
                    _index++;
                if (_index == _waypoints.childCount)
                    _index = 0;
                break;
        }

        MoveTowards(transform.position, _waypoints.GetChild(_index).position);
    }

    private void SetTarget()
    {
        _speed = SpeedChooser() * 2.0f;

        MoveTowards(transform.position, _target.position);

        if (transform.position == _target.position)
            _isPatrolActive = true;
    }

    private void MoveTowards(Vector3 current, Vector3 target)
    {
        var targetPosition = Vector3.MoveTowards(current, target, _speed * Time.deltaTime);
        transform.position = targetPosition;
    }

    private void FindTarget()
    {
        if (CheckDisatnce() <= _findDistance)
            _isPatrolActive = false;
    }

    private void LoseTarget()
    {
        if (CheckDisatnce() >= _loseDistance)
            _isPatrolActive = true;
    }

    private void RandomWay()
    {
        _index = Random.Range(0, _waypoints.childCount);
    }

    private float SpeedChooser()
    {
        var speed = 0.0f;

        switch (_randomSpeedHasActive)
        {
            case true:
                speed = Random.Range(_speedTemp / 2.0f, _speedTemp);
                break;
            case false:
                speed = _speedTemp;
                break;
        }

        return speed;
    }
}