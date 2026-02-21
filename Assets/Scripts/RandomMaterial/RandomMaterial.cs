using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RandomMaterial : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private List<GameObject> tunnels;

    private void Start()
    {
        RandomizeMaterial();
    }

    public void RandomizeMaterial()
    {
        foreach (GameObject tunnel in tunnels)
        {
            MeshRenderer meshRenderer = tunnel.GetComponent<MeshRenderer>();
            int randomIndex = Random.Range(0, materials.Length);
            meshRenderer.sharedMaterial = materials[randomIndex];
        }
    }
}