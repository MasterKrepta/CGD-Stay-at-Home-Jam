using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    public int LevelToLoad = 0;
    public int timeToNextLevel = 1;
    public GameObject AnimationParents;
    Animator[] animations;
    int currentAnim;
    

    private void Start()
    {
        animations = AnimationParents.GetComponentsInChildren<Animator>();
        currentAnim = ConfigAnims();

        animations[currentAnim].gameObject.SetActive(true);
        animations[currentAnim].SetTrigger("Start");
        LevelToLoad = SceneManager.GetActiveScene().buildIndex;
    }

    private int ConfigAnims()
    {
        foreach (var a in animations)
        {
            a.gameObject.SetActive(false);
        }
        return UnityEngine.Random.Range(0, animations.Length);
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        StartCoroutine("LevelTransition");
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine("LevelTransition");
        }
    }


    IEnumerator LevelTransition()

    {
        currentAnim = ConfigAnims();
        animations[currentAnim].gameObject.SetActive(true);

        animations[currentAnim].SetTrigger("End");
        yield return new WaitForSeconds(timeToNextLevel);
        LoadNextLevel();
    }
    

    void LoadNextLevel()
    {
        LevelToLoad++;
        SceneManager.LoadScene(LevelToLoad);
    }

    
}
