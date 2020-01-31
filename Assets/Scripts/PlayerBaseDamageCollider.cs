using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseDamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<PlayerLives>().DecreaseLives();
        Destroy(collision.gameObject);
    }
}
