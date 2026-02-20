    using System.Collections.Generic;
    using IslandQuestions;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class IslandQuestionGenerator : MonoBehaviour, IQuestionSelector
    {
        public bool debug = false;
        public List<ObjectQuestionListElement> objectQuestionList;

        private InputSystem_Actions inputActions;
        
        private IslandQuestions.Question currentQuestion;

        private void Awake()
        {
            inputActions = new InputSystem_Actions();
            
            inputActions.Player.Debug.performed += ctx =>
            {
                OnDebug();
            };

        }
        
        
        
        private void OnEnable() => inputActions.Enable();
        private void OnDisable() => inputActions.Disable();
       
        
        private void Start()
        {
            PrepareLevel();
        }

        private void PrepareLevel()
        {
            int questionIndex = Random.Range(0, objectQuestionList.Count);
            IslandQuestions.Question question = null;
            
            foreach (ObjectQuestionListElement obj in objectQuestionList)
            {
                if (!obj.skipRandomizing)
                {
                    obj.DisableAllObjects();
                    obj.EnableObjectsBasedOnMinimumAndMaximum();
                }

                if (obj == objectQuestionList[questionIndex])
                {
                    obj.FillQuestionAnswers();
                    question = obj.GetQuestion();
                }
                
            }

            if (question == null)
            {
                Debug.LogError("Nie udało się wylosować pytania.");
            }

            currentQuestion = question;

        }

        public IslandQuestions.Question GetQuestion()
        {
            return currentQuestion;
        }

        

        private void OnDebug()
        {
            if (debug)
            {
                PrepareLevel();
                Debug.Log("Question: " + currentQuestion.question + " Correct: " + currentQuestion.correctAnswer +", wrong: A." + currentQuestion.answer1 + " B." + currentQuestion.answer2 + " C." + currentQuestion.answer3);
            }

        }
        
    }

