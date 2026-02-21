using System.Threading.Tasks;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    [SerializeField]
    private IslandMenager islandMenager;
    [SerializeField]
    private QuizMenager quizMenager;
    [SerializeField]
    private GameMenager gameMenager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        quizMenager.StartQuiz();
        Quiz();
    }
    private async Task Quiz()
    {
        await Task.Delay(500);
        quizMenager.StartQuiz();
        Debug.Log("Quiz Started");
        await Task.Delay(500);
        Debug.Log("Answering Question");
        gameMenager.IncreaseDifficultLevel();
        gameMenager.IncreaseDifficultLevel();
        await Task.Delay(500);
        Debug.Log("Quiz Ended");
        islandMenager.RoundEnd();
        await Task.Delay(500);
        Debug.Log("Round Started");
        islandMenager.RoundStart();

    }


    // Update is called once per frame
    void Update()
    {

    }

}
