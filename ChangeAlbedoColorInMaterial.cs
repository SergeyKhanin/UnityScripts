using System.Collections.Generic;
using UnityEngine;

public class ChangeAlbedoColorInMaterial : MonoBehaviour
{
    [SerializeField] private Color _albedoColor = Color.white;
    [SerializeField] private Material[] _repaintedMaterials;

    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
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
                    if (material.name.StartsWith(repaintedMaterial.name))
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