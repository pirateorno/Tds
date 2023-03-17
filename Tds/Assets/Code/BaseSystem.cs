using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSystem : MonoBehaviour
{
    public int health;
    public Text health_text;
    public InfoSystem info;

    void Start()
    {
        
    }

    void Update()
    {
        health_text.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            info.DisplayMessage("Game Over!");
        }
    }
}
