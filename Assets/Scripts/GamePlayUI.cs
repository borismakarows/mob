using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayUI : MonoBehaviour
{
    TextMeshProUGUI scoreTMP;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        Singleton();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
        scoreTMP = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    }

    void Update()
    {
        scoreTMP.text = scoreKeeper.GetScore().ToString("000");
    }

    void Singleton()
    {
        int gamePlayUICount = FindObjectsOfType<GamePlayUI>().Length;
        if (gamePlayUICount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
