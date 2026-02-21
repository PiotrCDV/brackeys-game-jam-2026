using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RandomMaterial : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    private void Start()
    {
        RandomizeMaterial();
    }

    public void RandomizeMaterial()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        int randomIndex = Random.Range(0, materials.Length);
        meshRenderer.sharedMaterial = materials[randomIndex];
    }
}