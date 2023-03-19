using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    public int money;
    public Text money_text;

    void Update()
    {
        money_text.text = "Money: " + money.ToString();
    }
}
