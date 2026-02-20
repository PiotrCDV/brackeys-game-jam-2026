using UnityEngine;
using System.Collections.Generic;
using IslandQuestions;

public class QuizMenager : MonoBehaviour
{
    IslandMenager islandMenager;

    void QuestionSelector()
    {
        GameObject selectedIsland = islandMenager.spawnedIslands[Random.Range(0, islandMenager.spawnedIslands.Count)];
        IslandQuestionGenerator islandQuestionGenerator = selectedIsland.GetComponent<IslandQuestionGenerator>();
        IslandQuestions.Question question = islandQuestionGenerator.GetQuestion();
    }
}
