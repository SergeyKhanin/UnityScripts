using UnityEngine;

public class ChangeAlbedoColorInMaterial : MonoBehaviour
{
    [SerializeField] private Color _albedoColor;
    [SerializeField] private Material[] _repaintedMaterials;
    [SerializeField] private string _instancePostfix = " (Instance)";

    private void Start()
    {
        ChangeAlbedoColor();
    }

    private void ChangeAlbedoColor()
    {
        var meshesRenderer = GetComponentsInChildren<MeshRenderer>();
        foreach (var meshRenderer in meshesRenderer)
        {
            var materials = meshRenderer.GetComponentInChildren<MeshRenderer>().materials;
            foreach (var material in materials)
            {
                foreach (var repaintedMaterial in _repaintedMaterials)
                {
                    var materialName = repaintedMaterial.name + _instancePostfix;
                    if (material.name == materialName)
                    {
                        material.SetColor("_BaseColor", _albedoColor);
                    }
                }
            }
        }
    }
}