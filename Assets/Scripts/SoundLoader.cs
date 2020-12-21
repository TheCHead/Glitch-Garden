using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoader : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();      
        audioSource.volume = PlayerPrefsController.GetMasterVolume();

    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void ResetMusic()
    {
        Destroy(gameObject);
    }

}
