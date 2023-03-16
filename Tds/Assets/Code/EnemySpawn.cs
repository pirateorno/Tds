using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemies;
    public Transform spawn;

    IEnumerator SummonEnemy(int id, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(enemies[id], spawn.position, spawn.rotation);
        }
    }

    void Start()
    {
        StartCoroutine(SummonEnemy(0, 1));
        //StartCoroutine(SummonEnemy(1, 2));
        //StartCoroutine(SummonEnemy(2, 1));
    }
}
