using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GrandpaController : MonoBehaviour
{
    public float lookRadius = 10f;
    public NavMeshAgent agent;
    public Transform target;
    public float walkSpeed;
    public float runSpeed, chaseRange;
    public Transform[] wayPoints;
    public int currentIndex = 0;
    Vector3 currentDestination;
    void Start()
    {
        agent.SetDestination(wayPoints[currentIndex].position);
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= agent.stoppingDistance)
        {
            Debug.Log("atack");
        }
        else if (distance <= chaseRange)
        {
            Debug.Log("chase");
            agent.speed = runSpeed;
            agent.SetDestination(target.position);
        }
        else if (Vector3.Distance(transform.position,currentDestination) < agent.stoppingDistance + 0.1f)
        {
            Debug.Log("patrolling");
            ChangeWaypointIndex();
            UpdateDestination();
        }
        else {    UpdateDestination(); }
    }
    void UpdateDestination()
    {
        currentDestination = wayPoints[currentIndex].position;
        agent.SetDestination(currentDestination);
    }
    void ChangeWaypointIndex()
    {
        currentIndex++;
        if (currentIndex == wayPoints.Length)
        {
            currentIndex = 0;
        }
    }

}

