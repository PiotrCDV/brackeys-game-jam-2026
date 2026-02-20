using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("TestMainScenes");
    }
}
