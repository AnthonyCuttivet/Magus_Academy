using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PNJControls : Controls
{
    NavMeshAgent agent;
    public float distance;
    public override void  Awake(){
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }
    void Start(){
        InvokeRepeating("CalculateVelocity", 0, Random.Range(2f,5f));
    }

    void CalculateVelocity(){
        Vector2 newVelocity = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
        //velocity = Vector2.Lerp(velocity,newVelocity,Random.Range(0f,1f));
        Vector3 newPos = RandomDestination();
        agent.SetDestination(newPos);
    }
    Vector3 RandomDestination(){
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += transform.position;
        NavMeshHit navMeshHit;
        NavMesh.SamplePosition(randomDirection,out navMeshHit,distance,1);
        return navMeshHit.position;
    }
}
