using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IslandQuestions
{
    [System.Serializable]
    public class ObjectQuestionListElement
    {
        public string GroupName;
        
        [SerializeField] List<GameObjectWithTag> objects = new List<GameObjectWithTag>();
        [SerializeField] List<String> wrongAnswers = new List<String>();
        [SerializeField] private IslandQuestions.Question question;

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
                if(obj != null && obj.gameObject != null)
                    obj.gameObject.SetActive(false);
            }
        }
        public void EnableAllObjects()
        {
            foreach (var obj in objects)
            {
                if(obj != null && obj.gameObject != null)
                    obj.gameObject.SetActive(true);
            }
        }

        public void EnableObjectsBasedOnMinimumAndMaximum()
        {
            if (objects.Count < minimumObjToEnable) Debug.LogError("minimumObjToEnable jest mniejsze niż długość listy obiektów");
            if (objects.Count < maximumObjToEnable) Debug.LogError("maximumObjToEnable jest większe niż długość listy obiektów");
            
            int amountToEnable = Random.Range(minimumObjToEnable, maximumObjToEnable + 1);
            
            amountToEnable = Mathf.Clamp(amountToEnable, 0, objects.Count);
            
            var indicesToEnable = GetRandomNumbersNoRepetitions(0, objects.Count, amountToEnable);

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
                }
                
                question.correctAnswer = count.ToString();
                answers.Add(count);
                
                answers = GetRandomNumbersNoRepetitions(minimumAnswer, maximumAnswer + 1, 4, answers);
                
                question.answer1 = answers[1].ToString();
                question.answer2 = answers[2].ToString();   
                question.answer3 = answers[3].ToString();
            }
            else
            {
                var set = new HashSet<String>();
                foreach (var el in objects)
                {
                    if (el.gameObject.activeInHierarchy) // Bierzemy pod uwagę tylko włączone obiekty! pierdol się w dupę, niech to będzie ostatni raz kiedy o tym zapominam
                    {
                        set.Add(el.tag);
                    }
                }
                if(set.Count > 1) Debug.LogError("Niejednoznaczny wybór poprawnej odpowiedzi, aktywne elementy nie mogą mieć różnych tagów.");

                question.correctAnswer = set.First();
                
                int answersNeeded = Mathf.Min(3, wrongAnswers.Count);
                var indices = GetRandomNumbersNoRepetitions(0, wrongAnswers.Count, answersNeeded);
                
                question.answer1 = wrongAnswers.Count > 0 ? wrongAnswers[indices[0]] : "Brak błędnej odpowiedzi";
                question.answer2 = wrongAnswers.Count > 1 ? wrongAnswers[indices[1]] : "Brak błędnej odpowiedzi";
                question.answer3 = wrongAnswers.Count > 2 ? wrongAnswers[indices[2]] : "Brak błędnej odpowiedzi";
            }
            
            return question;
        }
        

        List<int> GetRandomNumbersNoRepetitions(int min, int max, int size, List<int> baseList = null)
        {
            if (baseList == null) baseList = new List<int>();
            

            int availableNumbers = max - min;
            int neededNumbers = size - baseList.Count;

            if (availableNumbers < neededNumbers)
            {
                size = baseList.Count + availableNumbers; 
            }

            while (baseList.Count < size)
            {
                int tmp = Random.Range(min, max);
                if (!baseList.Contains(tmp))
                {
                    baseList.Add(tmp);
                }
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
}
