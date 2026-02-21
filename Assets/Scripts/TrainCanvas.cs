using System;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class TrainCanvas : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    private string levelBaseText = "LEVEL:      ";

    public void OnEnable()
    {
        try
        {
            var level = GameMenager.Instance.GetDifficultyLevel();
            levelText.text = levelBaseText + level;
        }
        catch (NullReferenceException e)
        {
            var level = 1;
            levelText.text = levelBaseText + level;
        }
    }
}
