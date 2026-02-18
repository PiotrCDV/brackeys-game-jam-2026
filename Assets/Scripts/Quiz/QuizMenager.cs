using UnityEngine;
using System.Collections.Generic;

public class QuizMenager : MonoBehaviour
{
    public static QuizMenager Instance;
    [SerializeField]
    private QuestionMenager questionMenager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartQuiz()
    {
       Question question = questionMenager.SelectQuestion();
        if (question != null)
        {
            Debug.Log("Question: " + question.questionText);
            Debug.Log("Possible Answers: " + string.Join(", ", question.possibleAnswers));
        }
        else
        {
            Debug.Log("No questions available.");
        }
    }
}
