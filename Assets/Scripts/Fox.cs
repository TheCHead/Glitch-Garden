using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            if (otherObject.GetComponent<Gravestone>())
            {
                GetComponent<Animator>().SetTrigger("JumpTrigger");
            }
            else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }
        }
    }
}
