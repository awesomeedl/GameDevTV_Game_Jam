using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    static int currentLevel = 1;
    public static SceneLoader instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        currentLevel = nextScene;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Gameover");
    }

    public void Retry()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}