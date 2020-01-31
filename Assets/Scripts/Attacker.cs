using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;


    private void Awake()
    {
        FindObjectOfType<LevelController>().PlusAttacker();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.MinusAttacker();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * PlayerPrefsController.GetDifficulty() * Time.deltaTime);
    }

    public void SetMovementSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
            if (health.GetHealth() <= 0)
            {
                GetComponent<Animator>().SetBool("IsAttacking", false);
            }
        }
    }
}
