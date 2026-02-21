using TMPro;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    void Update()
    {
        var txt = QuizMenager.Instance.GetCorrectAnswer();
        if (txt != null)
            text.text = txt;
    }
}
