using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    public int LevelToLoad = 0;
    public int timeToNextLevel = 3;
    

    private void Start()
    {
        LevelToLoad = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine("LevelTransition");
        }
    }


    IEnumerator LevelTransition()

    {
        //tODO set up level change transitions;
        print("Waiting for 3 seconds");
        yield return new WaitForSeconds(timeToNextLevel);
        LoadNextLevel();
    }
    

    void LoadNextLevel()
    {
        LevelToLoad++;
        SceneManager.LoadScene(LevelToLoad);
    }
}
