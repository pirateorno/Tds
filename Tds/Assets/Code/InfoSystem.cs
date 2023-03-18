using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoSystem : MonoBehaviour
{
    public Text info_text;
    public Text wave_text;
    public EnemySpawn wave;


    void Start()
    {
        DisplayMessage("");
    }

    public void DisplayMessage(string message)
    {
        StartCoroutine(ShowMessage(message, 3f));
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        info_text.text = message;
        yield return new WaitForSeconds(delay);
        info_text.text = "";
    }

    void Update()
    {
        wave_text.text = "Wave: " + wave.current_wave.ToString();
        if (wave.current_wave > wave.waves_count)
        {
            info_text.text = "You won!!";
        }
    }
}
