using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public int score = 0;
    public int lives = 3;

    private bool gameOver;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        NewGame();
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
        Debug.Log("Level Loaded: " + levelToLoad);
    }
}
