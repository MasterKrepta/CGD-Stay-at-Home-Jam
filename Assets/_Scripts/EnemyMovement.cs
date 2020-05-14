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
    NavMeshAgent agent;
    Vector3 dest;
    bool isTraveling = false;

    [Header("Movement settings")]
    public Mode current = Mode.SCATTER;
    public float scatterTime = 7;
    public float chaseTime = 20;

    [Header("Detection settings")]
    public float radius = 10f;
    public float TimeToEndChase;

    PatrolPath patrolPaths;
    public bool goingBackward = false;
    public int currentIndex = -1;
    public int children;
    float waitDuration = .25f;
    float waitTimer;

    public bool IsStunned = false;
    public float stunDelay = 1.5f;
    public float timeToUnstun = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        patrolPaths = GameObject.FindObjectOfType<PatrolPath>();
        
    }

    private void UpdateChildCount()
    {
        children = patrolPaths.Nodes.Count;
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            current = Mode.CHASE;
            isTraveling = false;
        }

        if (IsStunned == false)
        {
            switch (current)
            {

                case Mode.SCATTER:
                    if (isTraveling == false)
                    {
                        isTraveling = true;
                        //dest = GetClosestWaypoint();
                        dest = GetToNextWaypoint();
                        //dest = GetRandomPos();

                    }

                    if (isTraveling)
                    {
                        AssignTargetScatter();
                        ScatterMovement();
                    }


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
        else
        {
            if (CanUnstun())
            {
                IsStunned = false;
            }
        }
        
    }

    private void ChaseMovement()
    {
        agent.SetDestination(target.position);
        if (Time.time >= TimeToEndChase || target.gameObject.activeInHierarchy == false)
        {
            //print("End chase");
            current = Mode.SCATTER;
            isTraveling = false;
        }   
    }

    private void ScatterMovement()
    {
        //print("CHILDREN: " + patrolPaths.Nodes.Count);
        
        if (agent.remainingDistance <= .2)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > waitDuration)
            {
                waitTimer = 0;
                isTraveling = false;
            }
            
            //dest = GetRandomPos();
            //dest = GetToNextWaypoint();
        }
        
    }


    void AssignTargetScatter()
    {
        agent.SetDestination(dest);
    }

    Vector3 GetClosestWaypoint()
    {

        //Vector3 result = patrolPaths.Nodes[0].transform.position;
        Vector3 result = Vector3.zero;
        float closestdist = Vector3.Distance(patrolPaths.Nodes[0].transform.position, transform.position);

        for (int i = 0; i < patrolPaths.Nodes.Count - 1; i++)
        {

            float temp = Vector3.Distance(patrolPaths.Nodes[i].transform.position, transform.position);
            if (temp < closestdist)
            {
                closestdist = temp;
                result = patrolPaths.Nodes[i].transform.position;
            }
        }

        return result;
    }

    Vector3 GetToNextWaypoint()
    {
        UpdateChildCount();

        if (goingBackward)
        {
            currentIndex--;
        }
        else
        {
            currentIndex++;
        }

        if (currentIndex > children || currentIndex < 0)
        {
            goingBackward = !goingBackward;
            if (goingBackward == false)
            {
                print("zero out index");
                currentIndex = -1;
                currentIndex++;
            }
            else
            {
                print("max out index");
                currentIndex = children;
                currentIndex--;
            }

        }
        //print(patrolPaths.Nodes.Count + " is the node count value");
        return patrolPaths.Nodes[currentIndex].transform.position;


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

    public void ToggleIsTraveling()
    {
        isTraveling = !isTraveling;
    }

    public void StunEnemy()
    {
        IsStunned = true;
        
        timeToUnstun = Time.time + timeToUnstun;
    }
    private bool CanUnstun()
    {
        var result = Time.time > timeToUnstun ? true : false;
        return result;

    }
}
