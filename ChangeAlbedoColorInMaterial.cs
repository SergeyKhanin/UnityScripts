using System.Collections.Generic;
using UnityEngine;

public class ChangeAlbedoColorInMaterial : MonoBehaviour
{
    [SerializeField] private Material[] _repaintedMaterials;
    [SerializeField] private Color _albedoColor = Color.white;

    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
    private const string InstancePostfix = " (Instance)";
    private readonly List<Material> _materialsInstancesCash = new List<Material>();

    private void OnEnable()
    {
        AddInstancesMaterialsToCash();
    }

    private void OnDisable()
    {
        ClearInstancesMaterialsFromCash();
    }

    private void Update()
    {
        SetAlbedoColor(_albedoColor);
    }

    private void AddInstancesMaterialsToCash()
    {
        var meshesRenderer = GetComponentsInChildren<MeshRenderer>();
        foreach (var meshRenderer in meshesRenderer)
        {
            var materials = meshRenderer.GetComponent<MeshRenderer>().materials;
            foreach (var material in materials)
            {
                foreach (var repaintedMaterial in _repaintedMaterials)
                {
                    var materialName = repaintedMaterial.name + InstancePostfix;
                    if (material.name == materialName)
                    {
                        _materialsInstancesCash.Add(material);
                    }
                }
            }
        }
    }

    private void SetAlbedoColor(Color color)
    {
        foreach (var material in _materialsInstancesCash)
        {
            material.SetColor(BaseColor, color);
        }
    }

    private void ClearInstancesMaterialsFromCash()
    {
        _materialsInstancesCash.Clear();
    }
}