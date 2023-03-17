using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoSystem : MonoBehaviour
{
    public Text info_text;
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
        if (wave.current_wave >= 30)
        {
            DisplayMessage("You won!!");
        }
    }
}
