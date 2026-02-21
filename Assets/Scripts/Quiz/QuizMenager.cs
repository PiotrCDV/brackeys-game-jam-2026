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
    
    public GameObject questionCanvas;
    public CameraRotationController camera;
    public GameMenager gameMenager;


    [Header("Audio Sounds")]
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip failSound;

    public static QuizMenager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }
    void QuestionSelector()
    {
        questionCanvas.SetActive(true);
        camera.LockCamera();
        
        
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
        correctAnswer = question.correctAnswer.ToUpper();

        questionText.text = question.question;
        int answerIndex = GetRandomNumber(questions.Count);
        if (correctAnswer == "YES")
        {
            List<string> yesNoQuestions = new List<string>() { "YES", "NO", "YES", "NO" };
            answer1.text = yesNoQuestions[answerIndex];
            questions.RemoveAt(answerIndex);
            answer2.text = yesNoQuestions[answerIndex = GetRandomNumber(questions.Count)];
            questions.RemoveAt(answerIndex);
            answer3.text = yesNoQuestions[answerIndex = GetRandomNumber(questions.Count)];
            questions.RemoveAt(answerIndex);
            answer4.text = yesNoQuestions[0];
            return;
        }
        if (correctAnswer == "NO")
        {
            List<string> yesNoQuestions = new List<string>() { "YES", "NO", "YES", "NO" };
            answer1.text = yesNoQuestions[answerIndex];
            questions.RemoveAt(answerIndex);
            answer2.text = yesNoQuestions[answerIndex = GetRandomNumber(questions.Count)];
            questions.RemoveAt(answerIndex);
            answer3.text = yesNoQuestions[answerIndex = GetRandomNumber(questions.Count)];
            questions.RemoveAt(answerIndex);
            answer4.text = yesNoQuestions[0];
            return;
        }

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
        questionCanvas.SetActive(false);
        camera.UnlockCamera();
    }
    public void  CheckAnswer(string answer)
    {
        if (answer.ToUpper() == correctAnswer.ToUpper())
        {
            gameMenager.IncreaseDifficultLevel();
            AudioManager.Instance.PlaySFX(winSound);
        }
        else
        {
            gameMenager.EndGame();
            AudioManager.Instance.PlaySFX(failSound);
        }

        FadeInScreen.Instance.PlayFadeIn();
    }


    public string GetCorrectAnswer()
    {
        return correctAnswer;
    }
    
}
