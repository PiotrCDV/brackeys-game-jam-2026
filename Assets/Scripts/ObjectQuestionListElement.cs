using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class ObjectQuestionListElement
{
    public string GroupName;
    
    [SerializeField] List<GameObjectWithTag> objects = new List<GameObjectWithTag>();
    [SerializeField] List<String> wrongAnswers = new List<String>();
    [SerializeField] private Question question;

    [Header("Parametry")] 
    [SerializeField] private int minimumObjToEnable;
    [SerializeField] private int maximumObjToEnable;
    
    [Header("Odpowiedzi numeryczne")]
    [SerializeField] Boolean isNumericAnswer;
    [SerializeField] int minimumAnswer;
    [SerializeField] int maximumAnswer;
    
    

    public void DisableAllObjects()
    {
        foreach (var obj in objects)
        {
            obj.gameObject.SetActive(false);
        }
    }
    
    public void EnableAllObjects()
    {
        foreach (var obj in objects)
        {
            obj.gameObject.SetActive(true);
        }
    }

    public void EnableObjectsBasedOnMinimumAndMaximum()
    {
        if (objects.Count < minimumObjToEnable) Debug.LogError("minimumObjToEnable jest mniejsze niż długość listy obiektów");
        if (objects.Count < maximumObjToEnable) Debug.LogError("maximumObjToEnable jest większe niż długość listy obiektów");
        
        var indicesToEnable = GetRandomNumbersNoRepetitions(minimumObjToEnable, maximumObjToEnable, 4);

        foreach (var index in indicesToEnable)
        {
            objects[index].gameObject.SetActive(true);
        }
        
    }

    public Question GetQuestion()
    {
        return question;
    }

    public Question FillQuestionAnswers()
    {
        if (isNumericAnswer)
        {
            List<int> answers = new List<int>();
            int count = 0;
            foreach (var obj in objects)
            {
                if (obj != null && obj.gameObject.activeInHierarchy) count++;

                question.correctAnswer = count.ToString();
            }
            
            answers.Add(count);

            answers = GetRandomNumbersNoRepetitions(minimumObjToEnable, maximumObjToEnable, 4, answers);
            
            question.answer1 = answers[1].ToString();
            question.answer2 = answers[2].ToString();   
            question.answer3 = answers[3].ToString();
            
        }
        else
        {
            // sprawdz czy wszystkie aktywne maja ten sam tag, jesli nie to error
            // jesli tak, to correct answer to tag, pozostale wylosowac z wrongAnswers
            var set = new HashSet<String>();
            foreach (var el in objects)
            {
                set.Add(el.tag);
            }
            if(set.Count > 1) Debug.LogError("Niejednoznaczny wybór poprawnej odpowiedzi, wylosowane elementy nie mogą mieć różnych tagów.");

            question.correctAnswer = set.First();
            
            var indices = GetRandomNumbersNoRepetitions(0, wrongAnswers.Count, 3);
            question.answer1 = wrongAnswers[indices[0]];
            question.answer2 = wrongAnswers[indices[1]];
            question.answer3 = wrongAnswers[indices[2]];


        }
        
        return question;
    }
    
    
    // utility
    List<int> GetRandomNumbersNoRepetitions(int min, int max, int size, List<int> baseList =  null)
    {
        if (baseList == null) baseList = new List<int>();
        int tmp =  Random.Range(min, max);

        while (baseList.Count < size)
        {
            if(!baseList.Contains(tmp)) baseList.Add(tmp);
            tmp =  Random.Range(min, max);
        }
        return baseList;
    }

}

[Serializable]
public class Question
{
    public String question;
    public String answer1;
    public String answer2;
    public String answer3;
    public String correctAnswer;
}

[Serializable]
public class GameObjectWithTag
{
    public GameObject gameObject;
    public String tag;
}
