using System;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCanvas : MonoBehaviour
{

    public Button  buttonA; 
    public Button  buttonB; 
    public Button  buttonC; 
    public Button  buttonD;

    private void OnEnable()
    {
        buttonA.interactable = true;
        buttonB.interactable = true;
        buttonC.interactable = true;
        buttonD.interactable = true;
    }

    public void OnAnswerClick()
    {
        buttonA.interactable = false;
        buttonB.interactable = false;
        buttonC.interactable = false;
        buttonD.interactable = false;
    }
    
}
