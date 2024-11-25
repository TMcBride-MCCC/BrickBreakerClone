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
    public int score = 0;
    public int lives = 3;
    private bool gameOver;

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
        updateGuiScore();
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

    public void addToScore(int p)
    {
        Debug.Log(p + " added to score!");
        score += p;
        Debug.Log("Score is now: " + score);
        updateGuiScore();
    }

    public void updateGuiScore()
    {
        guiScoreText.text = "Score: " + score.ToString();
    }
}
