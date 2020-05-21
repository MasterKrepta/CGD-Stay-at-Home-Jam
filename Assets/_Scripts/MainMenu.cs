using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadTutorial()
    {
        print("Display Tutorials screen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
