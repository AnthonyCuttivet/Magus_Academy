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
    gameObject.GetComponent<Animator>().SetBool("isWalking", true);
        InvokeRepeating("CalculateVelocity", 0, Random.Range(2f,5f));
        agent.speed = PlayersSettings.instance.pnjWalkingSpeed;
        agent.autoBraking = false;
        distance = PlayersSettings.instance.pnjDistanceToWalk;
    }

    void CalculateVelocity(){
        if(agent.isActiveAndEnabled){
            Vector2 newVelocity = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
            Vector3 newPos = RandomDestination();
            agent.SetDestination(newPos);
        }
    }
    Vector3 RandomDestination(){
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += transform.position;
        NavMeshHit navMeshHit;
        NavMesh.SamplePosition(randomDirection,out navMeshHit,distance,1);
        return navMeshHit.position;
    }

    public override void Kill(){
        CharactersSpawner.instance.pooledEntities.Remove(gameObject);
        CharactersSpawner.instance.PNJList.Remove(gameObject);
        Destroy(gameObject);
    }
}
