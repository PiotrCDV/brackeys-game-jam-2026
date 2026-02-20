using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;

public class IslandMenager : MonoBehaviour
{
    [SerializeField]
    private IslandSpawner islandSpawner;
    [SerializeField]
    private IslandDestroyer islandDestroyer;
    [SerializeField]
    private List<GameObject> islandList;
    public List<GameObject> spawnedIslands;
    [SerializeField]
    private List<Transform> spawnPoits;

    private void Awake()
    {
        spawnedIslands = new List<GameObject>();
    }
    public void RoundStart()
    {
        List<GameObject> islandToSpawn = islandList;
        foreach (Transform spawnPoint in spawnPoits)
        {
            int islandIndex = Random.Range(0, islandToSpawn.Count);
            spawnedIslands.Add(islandSpawner.SpawnIsland(spawnPoint, islandToSpawn[islandIndex]));
            islandToSpawn.RemoveAt(islandIndex);
        }
    }
    public void RoundEnd()
    {
        islandDestroyer.DestroyIsland(spawnedIslands);
        spawnedIslands.Clear();
    }
}
