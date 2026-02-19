
using System.Collections.Generic;
using Unity.Collections;

[System.Serializable]
public class Question
{
    public string questionText;
    public List<string> possibleAnswers =new List<string>();
    public string correctAnswer;
    public int difficultyLevel;
}
