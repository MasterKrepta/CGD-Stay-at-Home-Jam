﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    float h, v;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        movement = new Vector3(h, 0, v);

        transform.Translate(MoveSpeed * movement * Time.deltaTime, Space.World);
        
        if (movement == Vector3.zero) return;
        
        transform.rotation = Quaternion.LookRotation(movement);

    }

    
}
