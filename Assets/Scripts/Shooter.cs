using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    AttackerSpawner myLaneSpawner;
    Animator myAnimator;
    
    private void Start()
    {
        SetLaneSpawner();
        myAnimator = GetComponent<Animator>();
    }
    
    
    private void Update()
    {
        if (IsAttackerInLane())
        {
            myAnimator.SetBool("IsAttacking", true);
        }

        else
        {
            myAnimator.SetBool("IsAttacking", false);
        }
        
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }
    

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
  

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, transform.Find("Gun").position, transform.rotation) as GameObject;
        newProjectile.transform.parent = gameObject.transform;
    }
}
