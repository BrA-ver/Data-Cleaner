using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelScene;

    public void Play()
    {
        SceneManager.LoadScene(levelScene);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
