using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;
    [SerializeField] Attacker[] attackerPrefabs;
    bool isSpawning = true;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAttackers());
    }

    IEnumerator SpawnAttackers()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }

    }

    private void SpawnAttacker()
    {
        Attacker attacker = attackerPrefabs[Random.Range(0, attackerPrefabs.Length)];
        Spawn(attacker);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
