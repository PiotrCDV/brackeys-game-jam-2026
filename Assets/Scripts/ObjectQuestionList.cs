using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class ObjectQuestionList
{ 
    [SerializeField] List<GameObject> objects = new List<GameObject>();
    [SerializeField] List<String> possibleAnswers = new List<String>();
    [SerializeField] private Question question;

    [Header("odpowiedzi numeryczne")]
    [SerializeField] Boolean isNumericAnswer;
    [SerializeField] int minimumAnswer;
    [SerializeField] int maximumAnswer;
    
    
    // randomize parameters bool

    public void DisableAllObjects()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }
    
    public void EnableAllObjects()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }

    public Question GetQuestion()
    {
        return question;
    }

    public Question GetPossibleAnswers()
    {
        if (isNumericAnswer)
        {
            List<int> answers = new List<int>();
            int count = 0;
            foreach (var obj in objects)
            {
                if (obj != null && obj.activeInHierarchy) count++;

                question.correctAnswer = count.ToString();
            }
            
            answers.Add(count);

            int tmp;
            while (answers.Count < 4)
            {
                tmp = Random.Range(minimumAnswer, maximumAnswer);
                if (!answers.Contains(tmp)) answers.Add(tmp);
            }
            question.answer1 = answers[1].ToString();
            question.answer2 = answers[2].ToString();   
            question.answer3 = answers[3].ToString();
            
        }
        else
        {
            
            // todo
        }
        
        return question;
    }
    

}

[System.Serializable]
public class Question
{
    [HideInInspector] String question;
    [HideInInspector] public String answer1;
    [HideInInspector] public String answer2;
    [HideInInspector] public String answer3;
    [HideInInspector] public String correctAnswer;
}

