using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public GameObject spawner;
    public GameObject player;

    public Text scoreDisplay;
    public Text finalScoreDisplay;
    public Text highscoreDisplay;

    public int gems;
    public int score;
    public int highscore;
    public float ultimateSpeed = 0f; 

    public GameObject gameOverScreen;

    public void StartGame()
    {
        spawner.gameObject.SetActive(true);
        ultimateSpeed = 1f;
        score = 0;
        scoreDisplay.text = score.ToString();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        spawner.SetActive(false);
        gameOverScreen.SetActive(true);
        finalScoreDisplay.text = score.ToString();
        highscoreDisplay.text = highscore.ToString();
        //ResetScene();

        //gameOver.gameObject.SetActive(true);
    }

    public void scoreUpdate()
    {
        score += 1;
        scoreDisplay.text = score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        highscore = PlayerPrefs.GetInt("highscore", 0);

    }

    // Start is called before the first frame update
    private void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreDisplay.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
