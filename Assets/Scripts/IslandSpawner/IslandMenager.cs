using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class IslandMenager : MonoBehaviour
{
    [SerializeField]
    private IslandSpawner islandSpawner;
    [SerializeField]
    private IslandDestroyer islandDestroyer;
    [SerializeField]
    public List<GameObject> islandList;
    public List<GameObject> spawnedIslands;
    [SerializeField]
    public List<Transform> spawnPoits;
    [SerializeField]
    private TrainPositonRestert trainPositonRestert;

    public static IslandMenager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
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
        trainPositonRestert.TrainReset();
        islandDestroyer.DestroyIsland(spawnedIslands);
        spawnedIslands.Clear();
        islandList.Clear();
    }
    public void GameEnd()
    {
        spawnPoits.Clear();
    }
}
