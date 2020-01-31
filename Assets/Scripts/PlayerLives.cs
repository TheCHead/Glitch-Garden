using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] int lives = 10;
    Text livesText;

    private void Start()
    {
        livesText = GetComponent<Text>();
        UpdateLivesDisplay();
    }

    private void UpdateLivesDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void DecreaseLives(int pointsPerEnemy = 1)
    {
        lives -= pointsPerEnemy;
        UpdateLivesDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().YouLose();
        }
    }    
}
