using UnityEditor;
using UnityEngine;

public class Handle : MonoBehaviour
{
    [SerializeField] private float _radius1;
    [SerializeField] private Color _color1;

    [SerializeField] private float _radius2;
    [SerializeField] private Color _color2;

    private void OnDrawGizmos()
    {
        Draw(transform.position, _color1, _radius1);
        Draw(transform.position, _color2, _radius2);
    }


    private void Draw(Vector3 position, Color color, float radius)
    {
        Handles.color = color;
        Handles.Disc(Quaternion.identity, position, Vector3.up, radius, false, 1.0f);
    }
}