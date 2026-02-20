using UnityEditor;
using UnityEngine;

public class IslandSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject SpawnIsland(Transform transform, GameObject island)
    {
        GameObject createIsland = Instantiate(island, transform.position, transform.rotation);
        return createIsland;
    }
}
