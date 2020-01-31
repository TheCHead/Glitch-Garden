using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int damage = 50;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attacker = collision.GetComponent<Attacker>();
        var health = collision.GetComponent<Health>();

        if (attacker && health)
        {
            health.DealDamage(damage);
        }
        Destroy(gameObject);
    }
}
