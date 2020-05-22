using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    [Space(15)]
    [SerializeField] float detectRadius = 7;
    EnemyMovement em;
    
    void Start()
    {
        em = GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {

        print($"{this.name} hits {other.name}");
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            em.ToggleIsTraveling();
            em.current = EnemyMovement.Mode.CHASE;
        }

    }


    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.blue;
    }
}
