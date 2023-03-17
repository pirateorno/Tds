using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemies;
    public Transform spawn;

    [Header("Settings")]
    public int waves_count;
    public int multiplier;
    public int current_wave;


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
        for (current_wave = 0; current_wave < waves_count; current_wave++)
        {



        }
    }

    //StartCoroutine(SummonEnemy(0, 10));
}
