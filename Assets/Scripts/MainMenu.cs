using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelCanvas;
    [SerializeField] GameObject mainMenuCanvas;

    void Start()
    {
        DefaultMenu();
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
