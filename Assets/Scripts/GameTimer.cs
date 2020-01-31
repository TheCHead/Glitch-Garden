using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in seconds.")]
    [SerializeField] float levelTime = 10f;
    Slider levelTimerSlider;
    bool timerFinished = false;
    bool stopUpdate = false;

    private void Start()
    {
        levelTimerSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopUpdate)
        {
            return;
        }

        levelTimerSlider.value = Time.timeSinceLevelLoad / levelTime;

        timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            stopUpdate = true; 
        }
    }
}
