using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemies;
    public Transform spawn;

    [Header("Settings")]
    public int waves_count;
    public int multiplier;
    public int current_wave;
    public int wave_wait;

    [Header("Other")]
    public Button skip_button; 
    public bool skipWave;


    void Start()
    {
        StartCoroutine(SpawnWaves());
        if (skip_button)
        {
            skip_button.onClick.AddListener(OnClick);
        }
    }

    public void OnClick()
    {
        skipWave = true;
    }


    IEnumerator SpawnWaves()
    {
        for (current_wave = 0; current_wave < waves_count; current_wave++)
        {
            yield return StartCoroutine(SummonEnemy(0, 3 / 2 * current_wave));
            if (current_wave >= 0 && current_wave < 10)
            {
                yield return StartCoroutine(SummonEnemy(1, 3 / 2 * current_wave));
            }
            if (current_wave >= 10  && current_wave < 20)
            {
                yield return StartCoroutine(SummonEnemy(0, 3 / 2 * current_wave));
                yield return StartCoroutine(SummonEnemy(1, 3 / 2 * current_wave));
                yield return StartCoroutine(SummonEnemy(2, 3 / 2 * current_wave));
            }
            if (current_wave >= 20 && current_wave < 30)
            {
                yield return StartCoroutine(SummonEnemy(0, 3 / 2 * current_wave));
                yield return StartCoroutine(SummonEnemy(1, 3 / 2 * current_wave));
                yield return StartCoroutine(SummonEnemy(2, 3 / 2 * current_wave));
                yield return StartCoroutine(SummonEnemy(3, 3 / 2 * current_wave));
                yield return StartCoroutine(SummonEnemy(4, 3 / 2 * current_wave));
            }
            if (current_wave == 30)
            {
                yield return StartCoroutine(SummonEnemy(0, 5)); 
                yield return StartCoroutine(SummonEnemy(1, 5)); 
                yield return StartCoroutine(SummonEnemy(2, 5)); 
                yield return StartCoroutine(SummonEnemy(3, 5)); 
                yield return StartCoroutine(SummonEnemy(4, 5)); 
                yield return StartCoroutine(SummonEnemy(5, 1));
            }

            yield return StartCoroutine(WaitForNextWave(wave_wait));
        }
    }

    IEnumerator SummonEnemy(int id, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(enemies[id], spawn.position, spawn.rotation);
        }
    }

    IEnumerator WaitForNextWave(float delay)
    {
        float timeLeft = delay;
        if(current_wave < waves_count)
        {
            while (timeLeft > 0f)
            {
                if (skipWave)
                {
                    skipWave = false;
                    yield break;
                }

                yield return null;
                timeLeft -= Time.deltaTime;
            }
        }
    }
}
