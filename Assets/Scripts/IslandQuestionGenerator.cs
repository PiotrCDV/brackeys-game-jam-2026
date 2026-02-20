    using System.Collections.Generic;
    using IslandQuestions;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class IslandQuestionGenerator : MonoBehaviour, IQuestionSelector
    {
        public bool debug = false;
        public List<ObjectQuestionListElement> objectQuestionList;

        private InputSystem_Actions inputActions;

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
        // private void Start()
        // {
        //     inputActions.Player.Debug.performed += OnDebug;
        // }
        //
        // private void OnDisable()
        // {
        //     inputActions.Player.Debug.performed -= OnDebug;
        //
        // }

        private IslandQuestions.Question PrepareLevel()
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

            return question;
            
        }

        public IslandQuestions.Question GetRandomQuestion()
        {
            return PrepareLevel();
        }


        // // only for debug
        // private void Update()
        // {
        //     if (debug && )
        //     {
        //         var question = GetRandomQuestion();
        //         Debug.Log("Question: " + question.question + " Correct: " + question.correctAnswer +", wrong: A." + question.answer1 + " B." + question.answer2 + " C." + question.answer3);
        //         
        //     }
        // }

        private void OnDebug()
        {
            if (debug)
            {
                var question = GetRandomQuestion();
                Debug.Log("Question: " + question.question + " Correct: " + question.correctAnswer +", wrong: A." + question.answer1 + " B." + question.answer2 + " C." + question.answer3);
            }

        }
        
    }

