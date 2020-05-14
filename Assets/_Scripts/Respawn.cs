using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform StartPoint;
    public float RespawnDelay = 2f;
    MonoBehaviour[] Scripts;


    private void OnEnable()
    {
        StartPoint = GameObject.Find("START_POINT").transform;
        transform.position = StartPoint.position;
        EnableScripts();
    }

    private void EnableScripts()
    {
        Scripts = GetComponents<MonoBehaviour>();
        foreach (var s in Scripts)
        {
            s.enabled = true;
        }
        
    }

    private void OnDisable()
    {
        foreach (var s in Scripts)
        {
            s.enabled = false;
        }
        
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }



    public void DisablePlayer()
    {
        this.gameObject.SetActive(false);
        Invoke("RespawnPlayer", RespawnDelay);

    }

    void RespawnPlayer()
    {
        this.gameObject.SetActive(true);
        this.transform.position = StartPoint.position;
        EnableScripts();
      
    }

}
