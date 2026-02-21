using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    [SerializeField] 
    private IslandMenager IslandMenager;
    private int difficultyLevel;
    [SerializeField]
    private List<GameObject> spawnPoint;
    private int spawnDifficultyLevel;
    [SerializeField]
    private QuizMenager quizMenager;
    [SerializeField]
    private List<GameObject> mapThemes;
    private int currentMapThemeIndex;
    private GameObject currentTheme;

    public static GameMenager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        difficultyLevel = 1;

    }
    private void OnEnable()
    {
        SelectThemes();
        SpawnNewPoint();
        IslandMenager.RoundStart(); 
        difficultyLevel = 1;
        spawnDifficultyLevel = 0;
    }
    public int GetDifficultyLevel()
    {
        return difficultyLevel;
    }
    public void IncreaseDifficultLevel()
    {
        difficultyLevel++;
        if (difficultyLevel%2 != 0 )
        {
            spawnDifficultyLevel++;
            SpawnNewPoint();
        }
    }
    public void RestartDifficultyLevel()
    {
        difficultyLevel = 1;
    }
    private void SpawnNewPoint()
    {
        IslandMenager.spawnPoits.Add(spawnPoint[spawnDifficultyLevel].transform);
    }
    public void RestartGame()
    {
        Debug.Log("Restarting Game...");
    }
    private void SelectThemes()
    {
        currentMapThemeIndex = Random.Range(0, mapThemes.Count);
        currentTheme = Instantiate(mapThemes[currentMapThemeIndex]);
        foreach (GameObject map in currentTheme.GetComponent<ThemMap>().themeMaps)
        {
            IslandMenager.islandList.Add(map);
        }
    }
}
