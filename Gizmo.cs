using UnityEditor;
using UnityEngine;

public class Gizmo: MonoBehaviour
{
    [Range(0.0f, 1.0f)] [SerializeField] private float _radius;
    [SerializeField] private Color _color;
    [SerializeField] private Vector3 _nameOffset;
    private Vector3 _position;

    private void OnDrawGizmos()
    {
        _position = transform.position;
        Gizmos.color = _color;
        Gizmos.DrawSphere(_position, _radius);
        Handles.Label(_position + _nameOffset, transform.name);
    }
}