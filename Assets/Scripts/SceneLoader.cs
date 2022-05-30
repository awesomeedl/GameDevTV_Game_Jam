using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    static int levelIndex = 1;

    public static void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadNextLevel()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(levelIndex);
    }
    
    public static void Retry()
    {
        SceneManager.LoadScene(levelIndex);
    }

    public static void Quit()
    {
        Application.Quit();
    }
}