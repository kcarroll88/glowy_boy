﻿using System.Collections;
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
        SceneManager.LoadScene("Level 1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadLoadingScreen()
    {
        SceneManager.LoadScene("Loading");
        StartCoroutine(Loading());
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(3);
        LoadLevelOne();
    }
}
