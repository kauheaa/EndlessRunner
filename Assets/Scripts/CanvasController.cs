using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Transform startMenu;
    [SerializeField] private Transform gameOver;
    public Button playButton;
    public Button replayButton;
    public Text scoreDisplay;
    public GameObject spawner;
    public GameObject player;
    public int score;
    public float ultimateSpeed = 0f;

    public void StartGame()
    {
        spawner.gameObject.SetActive(true);
        startMenu.gameObject.SetActive(false);
        ultimateSpeed = 1f;
    }
    public void GameOver()
    {
        ResetScene();
        //spawner.gameObject.SetActive(false);
        //gameOver.gameObject.SetActive(true);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void scoreUpdate()
    {
        score += 1;
        scoreDisplay.text = score.ToString();
    }
    private void Start()
    {
        //spawner.gameObject.SetActive(false);
        //startMenu.gameObject.SetActive(true);
        //gameOver.gameObject.SetActive(false);
        //ultimateSpeed = 0f;
        score = 0;
        scoreDisplay.text = score.ToString();
        playButton.interactable = true;
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    StartGame();
        //}
    }
}
