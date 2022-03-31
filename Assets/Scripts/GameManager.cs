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

    [SerializeField] GameObject loadingCanvas;
    [SerializeField] Slider loadingSlider;
    [SerializeField] Color loadingTextColor;
    [SerializeField] TextMeshProUGUI loadingText;

    void Awake()
    {
        Singleton();
    }
    void Update()
    {
        loadingText.color = loadingTextColor;
    }
    
    public void LoadSceneIndex(int index)
    {
        LoadScene(index);
    }




    async void LoadScene(int index)
    {
        var scene = SceneManager.LoadSceneAsync(index);
        scene.allowSceneActivation = false;

        loadingCanvas.SetActive(true);

        do
        {
            loadingSlider.value = scene.progress;
            loadingTextColor.a = scene.progress;  
        
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
        loadingCanvas.SetActive(false);

    }

    private void Singleton()
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
