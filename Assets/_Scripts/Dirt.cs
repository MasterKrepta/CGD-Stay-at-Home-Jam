using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour, IHideable
{
    public Material mat;
    public GameObject effect;
    public int BitesNeeded = 3;
    private int currentBites = 0;
    FlashOnHit flash;
    AudioSource soundClip;
    Vector3 spawnPoint;

    private void OnEnable()
    {
        flash = GetComponent<FlashOnHit>();
        soundClip = GetComponent<AudioSource>();
        spawnPoint = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
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
        Instantiate(effect, spawnPoint, Quaternion.identity);
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
