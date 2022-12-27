using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private Transform _pointer;
    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        _ray = new Ray(transform.position, transform.forward);
        // _ray = Camera.main.ScreenPointToRay((Input.mousePosition));
        
        Debug.DrawRay(_ray.origin, _ray.direction * _rayDistance, Color.red);

        var hit = Physics.Raycast(_ray, out _hit, _rayDistance);

        if (hit)
        {
            _pointer.gameObject.SetActive(true);
            _pointer.position = _hit.point;
            _pointer.rotation = Quaternion.FromToRotation(Vector3.forward, _hit.normal);

            Debug.Log(_hit.collider.gameObject.name);
        }
        else
        {
            _pointer.gameObject.SetActive(false);
        }
    }
}