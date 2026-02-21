using UnityEngine;

public class GameMenager : MonoBehaviour
{
    [SerializeField] 
    private IslandMenager IslandMenager;
    private int difficultyLevel;
    
    public static GameMenager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        IslandMenager.RoundStart(); 
        difficultyLevel = 1;
    }
    public int GetDifficultyLevel()
    {
        return difficultyLevel;
    }
    public void IncreaseDifficultLevel()
    {
        difficultyLevel++;
    }
    public void RestartDifficultyLevel()
    {
        difficultyLevel = 1;
    }
    //private void AddNewSpawnPoint()
}
