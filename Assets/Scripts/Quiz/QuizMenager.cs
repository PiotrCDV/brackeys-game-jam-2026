using System.Collections.Generic;
using IslandQuestions;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class QuizMenager : MonoBehaviour
{
    [SerializeField]
    IslandMenager islandMenager;
    [SerializeField]
    TMPro.TextMeshProUGUI questionText;
    [SerializeField]
    TMPro.TextMeshProUGUI answer1;
    [SerializeField]
    TMPro.TextMeshProUGUI answer2;
    [SerializeField]
    TMPro.TextMeshProUGUI answer3;
    [SerializeField]
    TMPro.TextMeshProUGUI answer4;

    void QuestionSelector()
    {
        GameObject selectedIsland = islandMenager.spawnedIslands[Random.Range(0, islandMenager.spawnedIslands.Count)];
        IslandQuestionGenerator islandQuestionGenerator = selectedIsland.GetComponent<IslandQuestionGenerator>();
        Question question = islandQuestionGenerator.GetQuestion();
        DisplayQuestion(question);
    }
    int GetRandomNumber(int max)
    {
        return Random.Range(0, max);
    }
    void DisplayQuestion(Question question)
    {
        List<string> questions = new List<string>() { question.correctAnswer, question.answer1, question.answer2, question.answer3 };
        questionText.text = question.question;
        int correctAnswerIndex = GetRandomNumber(questions.Count);

        answer1.text = questions[correctAnswerIndex];
        questions.RemoveAt(correctAnswerIndex);

        answer2.text = questions[correctAnswerIndex = GetRandomNumber(questions.Count)];
        questions.RemoveAt(correctAnswerIndex);

        answer3.text = questions[correctAnswerIndex = GetRandomNumber(questions.Count)];
        questions.RemoveAt(correctAnswerIndex);

        answer4.text = questions[0];

    }
    public void StartQuiz()
    {
        QuestionSelector();
    }

}
