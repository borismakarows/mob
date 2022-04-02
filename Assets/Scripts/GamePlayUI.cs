using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject inGameCanvas;

    [SerializeField] TextMeshProUGUI[] scoreTMP;

    ScoreKeeper scoreKeeper;
    GameManager gameManager;
    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }


    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        DefaultCanvas();
    }

    void Update()
    {
        foreach (TextMeshProUGUI tmp in scoreTMP)
        {
            tmp.text = scoreKeeper.GetScore().ToString("000");
        }
    }

    public void PlayMainMenuMusic()
    {
        audioManager.PlayMenuMusic();
    }

    public void Won()
    {
        Time.timeScale = 0;
        winCanvas.SetActive(true);
        inGameCanvas.SetActive(false);
    }

    public void Lose()
    {
        scoreKeeper.ResetScore();
        loseCanvas.SetActive(true);
        inGameCanvas.SetActive(false);
        Time.timeScale = 0;
    }

    void DefaultCanvas()
    {
        inGameCanvas.SetActive(true);
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        gameManager.LoadSceneIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        gameManager.LoadSceneIndex(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int index)
    {
        Time.timeScale = 1;
        gameManager.LoadSceneIndex(index);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
