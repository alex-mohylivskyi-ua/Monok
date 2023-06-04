using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    public int playerScore = 0;
    [SerializeField] TextMeshProUGUI liveText;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] AudioClip backgroundMusic;
    void Awake()
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

    public void AddToScore(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        scoreText.text = playerScore.ToString();
    }

    void Start()
    {
        liveText.text = playerLives.ToString();
        scoreText.text = playerScore.ToString();
        AudioSource.PlayClipAtPoint(backgroundMusic, new Vector3(0, 0, 0));
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        else{
            ResetGameSession();
        }
    }

    void TakeLife()
    {
        playerLives--;
        liveText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
