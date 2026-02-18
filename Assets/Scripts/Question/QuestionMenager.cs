using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class QuestionMenager : MonoBehaviour
{
    private List<Question> questions = new List<Question>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static QuestionMenager Instance;

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
    public void AddQuestion(Question question)
    {
        questions.Add(question);
    }
    public void RemoveQuestion(Question question)
    {
        questions.Remove(question);
    }
    public void ClearQuestions()
    {
        questions.Clear();
    }
    public Question SelectQuestion()
    {
        return questions[Random.Range(0, questions.Count)];
    }
}
