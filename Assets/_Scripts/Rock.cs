using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, IHideable
{

    public Material mat;

    public void HideMat(Material hideMat)
    {
        this.GetComponentInChildren<Renderer>().material = hideMat;
    }

    public void ToggleMat()
    {
        this.GetComponentInChildren<Renderer>().material = mat;
    }


}
