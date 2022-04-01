using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance;
    

    void Awake()
    {
        Singleton();
    }
   
    
    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }


    void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
