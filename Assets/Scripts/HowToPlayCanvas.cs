using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayCanvas : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public TextMeshProUGUI buttonText;
    
    private int currentState = 0;

    private void OnEnable()
    {
        currentState = 0;
        DisplayText();
    }

    public void NextOnClick()
    {
        Debug.Log("NEXT");
        NextState();
        DisplayText();
    }

    private void NextState()
    {
        currentState++;
        if (currentState >= 4)
        {
            currentState = 0;
        }
    }

    private void DisplayText()
    {
        switch (currentState)
        {
            case 0:
            {
                text1.SetActive(true);
                text2.SetActive(false);
                text3.SetActive(false);
                buttonText.SetText("NEXT");
                break;
            }
            case 1:
            {
                text1.SetActive(false);
                text2.SetActive(true);
                text3.SetActive(false);
                buttonText.SetText("NEXT");
                break;
            }
            case 2:
            {
                text1.SetActive(false);
                text2.SetActive(false);
                text3.SetActive(true);
                buttonText.SetText("PLAY");
                break;
            }
            case 3:
            {
                DisableCanvas();
                break;
            }
            default:
            {
                Debug.Log("Wrong howtoplay display state");
                break;
            }
                
        }
    }

    private void DisableCanvas()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("TestMainScenes");
        
    }


}
