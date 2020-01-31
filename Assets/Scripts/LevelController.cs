using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float winWaitInSeconds = 3f;

    int AttackersCounter = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume();
    }

    public void PlusAttacker()
    {
        AttackersCounter += 1;
    }

    public void MinusAttacker()
    {
        AttackersCounter -= 1;
    }

    private void Update()
    {
        if (levelTimerFinished && AttackersCounter == 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {

        StopSpawners();
        levelTimerFinished = true;
        
    }

    IEnumerator HandleWinCondition()
    {
        GetComponent<AudioSource>().Play();
        winLabel.SetActive(true);
        yield return new WaitForSeconds(winWaitInSeconds);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            spawner.StopSpawning();
        }
    }

    public void YouLose()
    {
        GetComponent<AudioSource>().Play();
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
}
