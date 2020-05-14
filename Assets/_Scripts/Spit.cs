using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    public GameObject spitPrefab;
    public Transform mouthPoint;
    public float spitDelay = 0.2f;
    float timeToSpit = 0;
    float moveSpeed = 8;
    
    

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && CanSpit())
        {
            GameObject go =  Instantiate(spitPrefab, mouthPoint.position, Quaternion.identity);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.AddForce(mouthPoint.forward * moveSpeed, ForceMode.Impulse);
            timeToSpit = Time.time + spitDelay;
        }    
    }


 
    private bool CanSpit()
    {
        var result =  Time.time > timeToSpit ? true : false;
        return result;
        
    }
}
