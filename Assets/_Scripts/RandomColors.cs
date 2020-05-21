using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColors : MonoBehaviour
{
    Light light;
    Material mat;
    public Color[] Colors;
    int clr;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        light = GetComponent<Light>();
        clr  = Random.Range(0, Colors.Length);
        light.color = Colors[clr];
        mat.color = Colors[clr];
        
    }

 
}
