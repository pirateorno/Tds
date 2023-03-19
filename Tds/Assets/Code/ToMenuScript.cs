using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMenuScript : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.onClick.AddListener(menu);
    } 
    void menu()
    {
        SceneManager.LoadScene(0);
    }
}
