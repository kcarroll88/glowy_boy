using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int numPlayerLives = 3;
    [SerializeField] Text liveText;
    [SerializeField] Text rubyText;
    [SerializeField] int numRubyExtraLife = 100;

    int score = 0;

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
        liveText.text = numPlayerLives.ToString();
        rubyText.text = score.ToString();
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
        liveText.text = numPlayerLives.ToString();
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

    public void AddRuby()
    {
        score++;
        rubyText.text = score.ToString();
        if (score == numRubyExtraLife)
        {
            GainLife();
        }
    }

    private void GainLife()
    {
        numPlayerLives++;
        liveText.text = numPlayerLives.ToString();
    }
}
