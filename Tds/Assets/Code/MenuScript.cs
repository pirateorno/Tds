using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Button play;
    public Button authors;
    public Button settings;
    public Button exitb;

    void Start()
    {
        play.onClick.AddListener(() => ChangeScene(3));
        settings.onClick.AddListener(() => ChangeScene(1));
        authors.onClick.AddListener(() => ChangeScene(2));
        exitb.onClick.AddListener(exit);
    }

    void ChangeScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    void exit()
    {
        Application.Quit();
    }
}
