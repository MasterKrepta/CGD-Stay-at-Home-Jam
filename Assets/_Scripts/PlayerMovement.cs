using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    float h, v;
    Vector3 movement;
    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        movement = new Vector3(h, 0, v);

        rb.velocity = movement * MoveSpeed;
        transform.LookAt(transform.position +  movement);

        //transform.position = new Vector3(transform.position.x, .5f, transform.position.z); //TODO hacky clamp

        if (movement == Vector3.zero)
        {
            anim.SetBool("Moving", false);
        }
        else
        {
            anim.SetBool("Moving", true);
        }

        //if (movement != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.LookRotation(movement);
        //}


    }

    
}
