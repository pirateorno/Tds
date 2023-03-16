using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSystem : MonoBehaviour
{
    public int health;
    public Text health_text;
    public Text info_text;

    void Start()
    {
        info_text.gameObject.SetActive(false);
    }

    void Update()
    {
        health_text.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            info_text.gameObject.SetActive(true);
        }
    }
}
