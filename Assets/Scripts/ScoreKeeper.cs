using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int oreScore = 0;
    public string oreKey = "Ore";


    void Awake()
    {
        Singleton();
        
    }

    void Start()
    {
        oreScore = PlayerPrefs.GetInt(oreKey, 0);
        PlayerPrefs.SetInt(oreKey, oreScore);
    }

    public int GetScore()
    {
        return oreScore;
    }
    
    public void ModifyScore(int index)
    {
        oreScore += index;
        PlayerPrefs.SetInt(oreKey, oreScore);
    }

    public void ResetScore()
    {
        oreScore = 0;
        PlayerPrefs.SetInt(oreKey, oreScore);
    }

    void Singleton()
    {
        int scoreKeeperCount = FindObjectsOfType<ScoreKeeper>().Length;
        if (scoreKeeperCount > 1)
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