using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeRandomizer : MonoBehaviour
{
public List<GameObject> objects;
public int how_many;

private void OnEnable()
{
    List<int> randomNumbers = new List<int>();
    while (randomNumbers.Count < how_many)
    { 
        var rand = Random.Range(0, objects.Count);
        if(!randomNumbers.Contains(rand))
            randomNumbers.Add(Random.Range(0, objects.Count));
    }

    objects.ForEach(o => o.SetActive(false));
    
    foreach (var i in randomNumbers)
        objects[i].SetActive(true);
}
}
