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
    string correctAnswer;

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
        correctAnswer = question.correctAnswer;

        questionText.text = question.question;

        int answerIndex = GetRandomNumber(questions.Count);

        answer1.text = questions[answerIndex];
        questions.RemoveAt(answerIndex);

        answer2.text = questions[answerIndex = GetRandomNumber(questions.Count)];
        questions.RemoveAt(answerIndex);

        answer3.text = questions[answerIndex = GetRandomNumber(questions.Count)];
        questions.RemoveAt(answerIndex);

        answer4.text = questions[0];

    }
    public void StartQuiz()
    {
        QuestionSelector();
    }
    public void EndQuiz()
    {
        questionText.text = "";
        answer1.text = "";
        answer2.text = "";
        answer3.text = "";
        answer4.text = "";
    }
    public void  CheckAnswer(string answer)
    {
        if (answer == correctAnswer)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        FadeInScreen.Instance.PlayFadeIn();
    }

}
