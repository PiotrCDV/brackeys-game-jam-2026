using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class IslandDestroyer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyIsland(List<GameObject> island)
    {
        foreach (GameObject islandToDestroy in island)
        {
            Destroy(islandToDestroy);
        }
    }
}
