using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMusicVolume();
    }


    private void UpdateMusicVolume()
    {
        var musicPlayer = FindObjectOfType<SoundLoader>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found in scene.");
        }
    }



    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

    public float GetDefaultVolume()
    {
        return defaultVolume;
    }

    public float GetDefaultDifficulty()
    {
        return defaultDifficulty;
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }
}
