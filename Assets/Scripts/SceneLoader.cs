using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int loadingTimeInSeconds = 3;
    int currentSceneIndex;
    // Start is called before the first frame update


    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (FindObjectOfType<SoundLoader>())
        {
            FindObjectOfType<SoundLoader>().ResetMusic();
        }
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadYouLoseScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(loadingTimeInSeconds);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        if (FindObjectOfType<SoundLoader>())
        {
            FindObjectOfType<SoundLoader>().ResetMusic();
        }
        SceneManager.LoadScene("Start Screen");
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
