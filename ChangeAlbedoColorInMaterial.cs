using UnityEngine;

public class ChangeAlbedoColorInMaterial : MonoBehaviour
{
    [SerializeField] private Color _albedoColor;
    [SerializeField] private Material[] _repaintedMaterials;

    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
    private const string InstancePostfix = " (Instance)";

    private void Start()
    {
        SetAlbedoColor(_albedoColor);
    }

    private void SetAlbedoColor(Color color)
    {
        var meshesRenderer = GetComponentsInChildren<MeshRenderer>();
        foreach (var meshRenderer in meshesRenderer)
        {
            var materials = meshRenderer.GetComponentInChildren<MeshRenderer>().materials;
            foreach (var material in materials)
            {
                foreach (var repaintedMaterial in _repaintedMaterials)
                {
                    var materialName = repaintedMaterial.name + InstancePostfix;
                    if (material.name == materialName)
                    {
                        material.SetColor(BaseColor, color);
                    }
                }
            }
        }
    }
}