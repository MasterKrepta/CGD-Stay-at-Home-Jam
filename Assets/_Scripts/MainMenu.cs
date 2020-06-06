using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    public void LoadTutorial()
    {
        print("Display Tutorials screen");
    }

    public void MuteAudio()
    {
        AudioListener.volume = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
