using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int oreScore = 0;
    
    void Awake()
    {
        Singleton();
    }


    public int GetScore()
    {
        return oreScore;
    }
    
    public void ModifyScore(int index)
    {
        oreScore += index;
    }

    public void ResetScore()
    {
        oreScore = 0;
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