using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PNJControls : Controls
{
    NavMeshAgent agent;
    public float distance;
    float dissolveValue = -1;
    private Animator animator;
    public List<Material> materials = new List<Material>();


    public override void  Awake(){
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        foreach(Renderer renderer in GetComponentsInChildren<Renderer>()){
            //renderer.material = new Material ( renderer.material);
            materials.Add(renderer.material);
        } 
        
    }

    IEnumerator Start(){
        while(!gameStarted){
            yield return new WaitForSeconds(.01f);
        }
        animator.SetBool("isWalking", true);
        InvokeRepeating("CalculateVelocity", 0, Random.Range(2f,5f));
        agent.speed = PlayersSettings.instance.pnjWalkingSpeed;
        agent.autoBraking = true;
        agent.angularSpeed = 360f;
        distance = PlayersSettings.instance.pnjDistanceToWalk;
    }

    public override void Update(){
        base.Update();
        if(agent.destination == transform.position){
            animator.SetBool("isWalking", false);
        }else{
            animator.SetBool("isWalking", true);
        }
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

    public override void Kill(int killer){
        StartCoroutine(Dissolve());
        
    }

    public IEnumerator Dissolve(){
        agent.isStopped = true;
        GetComponent<Collider>().isTrigger = true;
        while(dissolveValue <= 1){
            dissolveValue += Time.deltaTime;  
            foreach(Material material in materials){
                material.SetFloat("_Vector1_Time",dissolveValue);
            }                   
            yield return null;
        }
        CharactersSpawner.instance.pooledEntities.Remove(gameObject);
        CharactersSpawner.instance.PNJList.Remove(gameObject);
        Destroy(gameObject);
    }
}
