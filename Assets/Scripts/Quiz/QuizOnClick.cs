using System.Runtime.CompilerServices;
using UnityEngine;

public class QuizOnClick : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI answer;
    [SerializeField]
    QuizMenager quizMenager;

    public AnswerCanvas answerCanvas;
    

    public void OnAnswerClick()
    {
        quizMenager.CheckAnswer(answer.text);
        answerCanvas.OnAnswerClick();
    }
}
