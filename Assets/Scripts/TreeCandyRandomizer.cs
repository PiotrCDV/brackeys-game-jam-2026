using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class GameObjectGroup
{
    public List<GameObject> objects = new List<GameObject>();
}

public class TreeCandyRandomizer : MonoBehaviour
{

    [SerializeField] public List<GameObjectGroup> objGroups;

    private void OnEnable()
    {
        foreach (var group in objGroups)
        {
            if (group.objects == null || group.objects.Count == 0) 
                continue;
            
            group.objects.ForEach(obj => 
            {
                if (obj != null) obj.SetActive(false); 
            });
            
            var rand = Random.Range(0, group.objects.Count);
            
            if (group.objects[rand] != null)
            {
                group.objects[rand].SetActive(true);
            }
        }
    }
}