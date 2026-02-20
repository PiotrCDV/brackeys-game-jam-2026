using UnityEngine;
using System.Collections.Generic;

public class QuizMenager : MonoBehaviour
{
    IslandMenager islandMenager;

    void QuestionSelector()
    {
        GameObject selectedIsland = islandMenager.spawnedIslands[Random.Range(0, islandMenager.spawnedIslands.Count)];
    }
}
