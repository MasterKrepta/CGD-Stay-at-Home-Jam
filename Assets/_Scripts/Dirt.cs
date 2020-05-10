using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    public int BitesNeeded = 3;
    private int currentBites = 0;
    FlashOnHit flash;

    private void OnEnable()
    {
        flash = GetComponent<FlashOnHit>();
    }


    public void BiteDirt()
    {
        flash.FlashColors();
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
}
