using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SpecialSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> specialObjects;
    private GameObject currentObject;
    public void SpawnObjects()
    {
        currentObject = specialObjects[Random.Range(0, specialObjects.Count)];
        currentObject.SetActive(true);
    }
    public void DespawnObjects()
    {
        if (currentObject != null)
        {
            currentObject.SetActive(false);
        }
    }
}
