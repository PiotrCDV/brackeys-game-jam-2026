using System;
using TMPro;
using UnityEngine;

public class TrainCanvas : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    private string levelBaseText = "LEVEL:      ";

    public void OnEnable()
    {
        var level = 1; // TODO fetch from gamemanager
        levelText.text = levelBaseText + level;
        
        
        
    }
}
