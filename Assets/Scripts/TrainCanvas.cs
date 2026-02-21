using System;
using TMPro;
using UnityEngine;

public class TrainCanvas : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    private string levelBaseText = "LEVEL:      ";

    public void OnEnable()
    {
        var level = GameMenager.Instance.GetDifficultyLevel();
        levelText.text = levelBaseText + level;
    }
}
