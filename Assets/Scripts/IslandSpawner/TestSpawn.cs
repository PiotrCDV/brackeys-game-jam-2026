using System.Threading.Tasks;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    [SerializeField]
    private IslandMenager islandMenager;
    [SerializeField]
    private QuizMenager quizMenager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        islandMenager.RoundStart();
        Quiz();
    }
    private async Task Quiz()
    {
        await Task.Delay(5000);
        quizMenager.StartQuiz();
    }


    // Update is called once per frame
    void Update()
    {

    }

}
