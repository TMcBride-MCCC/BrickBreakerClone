using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public TMP_Text guiScoreText;
    public TMP_Text guiLivesText;
    public int score = 0;
    public int lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
    }

    void Start()
    {

    }

    public void NewGame()
    {
        score = 0;
        lives = 3;

        int randomLevelNum = Random.Range(1, 3);
        LoadLevel(randomLevelNum);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void LoadLevel(int levelToLoad)
    {
        SceneManager.LoadScene("Level0" + levelToLoad);
        onSceneLoaded();
        Debug.Log("Level Loaded: " + levelToLoad);
    }

    private void onSceneLoaded()
    {
        findGuiScore();
        findGuiLives();
        updateGuiScore();
        updateGuiLives();
    }

    private void findGuiScore()
    {
        GameObject scoreText = GameObject.FindWithTag("ScoreText");

        if (scoreText != null)
        {
            guiScoreText = scoreText.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.Log("ERROR: Cannot find score text");
        }
    }

    private void findGuiLives()
    {
        GameObject livesText = GameObject.FindWithTag("LivesText");

        if (livesText != null)
        {
            guiLivesText = livesText.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.Log("ERROR: cannot find lives text");
        }
    }

    public void addToScore(int p)
    {
        //Debug.Log(p + " added to score!");
        score += p;
        //Debug.Log("Score is now: " + score);
        updateGuiScore();
    }

    public void updateGuiScore()
    {
        guiScoreText.text = "Score: " + score.ToString();
    }

    public void subtractFromLives(int l)
    {
        Debug.Log("You had " + lives + " lives left.");
        lives -= l;
        Debug.Log("You now have " + lives + " left");
        updateGuiLives();

        if (lives == 0)
        {
            gameOver();
        }
    }

    public void updateGuiLives()
    {
        guiLivesText.text = "Lives: " + lives.ToString();
    }

    private void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
