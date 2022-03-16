using UnityEngine;

public class SwitchBetweenMaterial : MonoBehaviour
{
    [SerializeField] private Material _materialOne;
    [SerializeField] private Material _materialTwo;
    private Renderer _renderer;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.enabled = true;
    }
    public void ChangeMaterialOne()
    {
        _renderer.sharedMaterial = _materialOne;
    }
    
    public void ChangeMaterialTwo()
    {
        _renderer.sharedMaterial = _materialTwo;
    }
}
