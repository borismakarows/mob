using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelCanvas;
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] TextMeshProUGUI scoreTMP;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        DefaultMenu();
    }

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        scoreTMP.text = scoreKeeper.GetScore().ToString("000");
    }

    public void LevelsMenu()
    {
        levelCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void DefaultMenu()
    {
        mainMenuCanvas.SetActive(true);
        levelCanvas.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
