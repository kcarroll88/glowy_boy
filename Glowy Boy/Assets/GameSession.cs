﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int numPlayerLives = 3; 

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ProcessPlayerDeath()
    {
        if (numPlayerLives > 1)
        {
            TakeLife();
        }
        else
        {
            StartCoroutine(TimePlayerWakesUp());
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        numPlayerLives--;
        StartCoroutine(TimePlayerWakesUp());
    }

    IEnumerator TimePlayerWakesUp()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(currentScene);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene("Game Over");
        Destroy(gameObject);
    }
}
