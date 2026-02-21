using System;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    [Header("Audio")]
    [SerializeField] private AudioClip winSound;


    public void PlayWinSound()
    {
        AudioManager.Instance.PlaySFX(winSound);
        AudioManager.Instance.StopMusic();
    }
    
    
    

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("TestMainScenes");
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
