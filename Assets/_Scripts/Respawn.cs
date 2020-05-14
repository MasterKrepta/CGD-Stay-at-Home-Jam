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
        EnableScripts();
    }

    private void EnableScripts()
    {
        Scripts = GetComponents<MonoBehaviour>();
        foreach (var s in Scripts)
        {
            s.enabled = true;
        }
        print(Scripts.Length + " scripts enabled");
    }

    private void OnDisable()
    {
        foreach (var s in Scripts)
        {
            s.enabled = false;
        }
        print(Scripts.Length + " scripts Disabled");
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
