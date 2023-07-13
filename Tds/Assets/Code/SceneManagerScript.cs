using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public void ChangeSceneById(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void NextScene()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
