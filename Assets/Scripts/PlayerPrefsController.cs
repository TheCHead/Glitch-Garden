using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0.3f;
    const float MAX_DIFFICULTY = 1f;

    public static void SetMasterVolume(float volume)
    {
        if (volume <= MAX_VOLUME && volume >= MIN_VOLUME)
        {
            Debug.Log("Master volume is set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

   public static float GetMasterVolume()
    {
        if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY))
        {
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        }
        else
        {
            return FindObjectOfType<OptionsController>().GetDefaultVolume();
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty <= MAX_DIFFICULTY && difficulty >= MIN_DIFFICULTY)
        {
            Debug.Log("Difficulty is set to " + difficulty);
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty is out of range");
        }
    }

    public static float GetDifficulty()
    {
        if (PlayerPrefs.HasKey(DIFFICULTY_KEY))
        {
            return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
        }
        else
        {
            return FindObjectOfType<OptionsController>().GetDefaultDifficulty();
        }
    }
}
