using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    Transform target;
    public enum Mode { SCATTER, CHASE }
    public Mode current = Mode.SCATTER;
    bool isTraveling = false;

    public float scatterTime = 7;
    public float chaseTime = 20;

    NavMeshAgent agent;
    public float radius = 10f;
    Vector3 dest;
    float TimeToEndChase;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            current = Mode.CHASE;
            isTraveling = false;
        }
        switch (current)
        {
            case Mode.SCATTER:
                if (isTraveling == false)
                {
                    isTraveling = true;
                    dest = GetRandomPos();
                    AssignTargetScatter();
                }
                ScatterMovement();

                break;
            case Mode.CHASE:

                if (isTraveling == false)
                {
                    isTraveling = true;
                    
                    TimeToEndChase = Time.time + chaseTime;
                }
                ChaseMovement();
                break;
            default:
                break;
        }
    }

    private void ChaseMovement()
    {
        agent.SetDestination(target.position);
        if (Time.time >= TimeToEndChase)
        {
            current = Mode.SCATTER;
            isTraveling = false;
        }   
    }

    private void ScatterMovement()
    {
        
        
        if (agent.remainingDistance <= .2)
        {
            isTraveling = false;
            dest = GetRandomPos();
        }
        
    }


    void AssignTargetScatter()
    {
        agent.SetDestination(dest);
    }


    Vector3 GetRandomPos()
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
        Vector3 finalPosition = hit.position;
        finalPosition.y = 0;
        
        
        return finalPosition;
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
