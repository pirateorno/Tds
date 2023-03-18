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

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (current_wave = 0; current_wave < waves_count; current_wave++)
        {
            int amount = (current_wave + 1) * multiplier;
            int enemy_id = Random.Range(0, enemies.Count);
            yield return StartCoroutine(SummonEnemy(enemy_id, amount));
            yield return StartCoroutine(WaitForNextWave(20f));
        }
    }

    IEnumerator SummonEnemy(int id, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(enemies[id], spawn.position, spawn.rotation);
        }
    }

    IEnumerator WaitForNextWave(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
