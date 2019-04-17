using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadStoryScene()
    {
        SceneManager.LoadScene("Loading");
        StartCoroutine(Loading());
        LoadNextScene();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(3);
    }
}
