using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusObject : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    private Material[] basicMaterial;
    private Renderer rend;

    void Start()
    {
        TryGetComponent<Renderer>(out rend);
        basicMaterial = rend.materials;
    }
    private void OnMouseEnter()
    {
        Material[] newMatrials = new Material[basicMaterial.Length + 1];
        basicMaterial.CopyTo(newMatrials, 0);
        newMatrials[basicMaterial.Length] = outlineMaterial;
        rend.materials = newMatrials;
    }
    private void OnMouseExit()
    {
        rend.materials = basicMaterial;
    }

}
