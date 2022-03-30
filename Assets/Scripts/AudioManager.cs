using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    void Awake()
    {
        ManageSingleton();
    }


    void Update()
    {
        
    }

    void ManageSingleton()
    {
        int audioManagerLength = FindObjectsOfType<AudioManager>().Length;
        if (audioManagerLength > 1)
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
