using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundManager Instance;

    AudioSource audioS;
    private void OnEnable()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        audioS = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }


    
}
