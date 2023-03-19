using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSystem : MonoBehaviour
{
    public float health; // health
    public Text health_text; // helth text
    public InfoSystem info; // Info module

    void Update()
    {
        health_text.text = "Health: " + health.ToString(); // Updating health text
        if (health <= 0)
        {
            info.DisplayMessage("Game Over!"); //Displaying game over!
        }
    }
}
