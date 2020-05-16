﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVisibiity : MonoBehaviour
{
    public GameObject hiddenObejct;
    public bool isExposed = false;
    public LayerMask levelLayer;
    public float range = 0.5f;
    
    public Transform[] sides;


    private void Start()
    {
        
        //hiddenObejct =   GameObject.Find($"{this.name}/Hidden");
    }
    // Update is called once per frame
    void Update()
    {

        foreach (var side in sides)
        {
            RaycastHit hit;


            if (Physics.Raycast(side.position, side.forward, out hit, range, levelLayer))
            {
                isExposed = false;
                hiddenObejct.SetActive(true);
                //print($"{this.name} is hidden by {side.name}");
            }
            else
            {
                // executes if it doesnt hit any collider
                isExposed = true;
                hiddenObejct.SetActive(false);
                //print($"{this.name} is Exposed by {side.name}");
                break;
            }
        }
    }


    private void OnDrawGizmos()
    {

        foreach (var side in sides)
        {
            Vector3 fwd = transform.TransformDirection(side.forward);
            Debug.DrawRay(side.position, fwd * range, Color.yellow);
        }

    }
}
