using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    
    [SerializeField] AudioClip battleMusic;
    [SerializeField] AudioClip mainMenuMusic;

    void Awake()
    {
        ManageSingleton();
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayBattleMusic()
    {
        ChangeMusic(battleMusic);
    }

    public void PlayMenuMusic()
    {
        ChangeMusic(mainMenuMusic);
    }

    public void ChangeMusic(AudioClip music)
    {
        audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
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
