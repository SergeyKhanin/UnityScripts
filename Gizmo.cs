using UnityEditor;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    [Range(0.0f, 1.0f)] [SerializeField] private float _radius;
    [SerializeField] private Color _color;
    [SerializeField] private Vector3 _nameOffset;

    private void OnDrawGizmos()
    {
        var position = transform.position;
        Gizmos.color = _color;
        Gizmos.DrawSphere(position, _radius);
        Handles.Label(position + _nameOffset, transform.name);
    }
}