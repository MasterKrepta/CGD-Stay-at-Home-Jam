using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour, IHideable
{
    public Material mat;
    public int BitesNeeded = 3;
    private int currentBites = 0;
    FlashOnHit flash;
    AudioSource soundClip;

    private void OnEnable()
    {
        flash = GetComponent<FlashOnHit>();
        soundClip = GetComponent<AudioSource>();
    }


    public void BiteDirt()
    {
        flash.FlashColors();
        soundClip.Play();
        currentBites++;
        if (currentBites >= BitesNeeded)
        {
            Consume();
        }
    }

    private void Consume()
    {
        Destroy(this.gameObject);
    }

    public void ToggleMat()
    {
        this.GetComponentInChildren<Renderer>().material = mat;
    }

    public void HideMat(Material hideMat)
    {
        this.GetComponentInChildren<Renderer>().material = hideMat;

    }
}
