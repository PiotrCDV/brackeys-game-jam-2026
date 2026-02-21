using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    [SerializeField] 
    private IslandMenager islandMenager;
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
    [SerializeField]
    private List<Transform> tunnelSpawnPoint;
    private Transform currentTunnelSpawnPoint;
    [SerializeField]
    private GameObject endTunnel;

    public static GameMenager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        difficultyLevel = 1;

    }
    private void OnEnable()
    {
        SelectThemes();
        SpawnNewPoint();
        islandMenager.RoundStart(); 
        difficultyLevel = 1;
        spawnDifficultyLevel = 0;
        
    }
    public int GetDifficultyLevel()
    {
        return difficultyLevel;
    }
    private void GameStart()
    {
        SelectThemes();
        islandMenager.RoundStart();
    }
    public void IncreaseDifficultLevel()
    {
        difficultyLevel++;
        if (difficultyLevel % 2 != 0)
        {
            spawnDifficultyLevel++;
            Invoke("SpawnNewPoint",3f);
        }
    }
    public void CheckDiffcultyLevel()
    {

    }
    public void RestartDifficultyLevel()
    {   
        difficultyLevel = 1;
        spawnDifficultyLevel = 0;
    }
    private void SpawnNewPoint()
    {
        if (spawnDifficultyLevel >= spawnPoint.Count)
        {
            Debug.LogWarning("Max");
            return;
        }
        islandMenager.spawnPoits.Add(spawnPoint[spawnDifficultyLevel].transform);
        currentTunnelSpawnPoint = tunnelSpawnPoint[spawnDifficultyLevel];
        SpawnTunnel();
    }
    public void RestartGame()
    {
        islandMenager.RoundEnd();
        GameStart();
        quizMenager.EndQuiz();
    }
    public void EndGame()
    {
        RestartDifficultyLevel();
        islandMenager.GameEnd();
        Invoke("SpawnNewPoint",3f);
    }
    private void SelectThemes()
    {
        if (currentTheme != null)
        {
            Destroy(currentTheme);
        }
        currentMapThemeIndex = Random.Range(0, mapThemes.Count);
        currentTheme = Instantiate(mapThemes[currentMapThemeIndex]);
        foreach (GameObject map in currentTheme.GetComponent<ThemMap>().themeMaps)
        {
            islandMenager.islandList.Add(map);
        }
    }
    private void SpawnTunnel()
    {
        endTunnel.transform.position = currentTunnelSpawnPoint.position;
    }
}
