using System.Collections.Generic;
using UnityEngine;

public class TestBehaviour : MonoBehaviour, IQuestionSelector
{

    public List<ObjectQuestionList> objectQuestionList;


    public Question GetRandomQuestion()
    {
        throw new System.NotImplementedException();
    }
}
