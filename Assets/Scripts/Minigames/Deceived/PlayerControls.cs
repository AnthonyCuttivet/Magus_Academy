using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : Controls
{
    private Vector2 i_movement;
    Collider attackCollider;
    public Vector3 attackArea;
    List<Collider> targets = new List<Collider>();
    public bool isWalking = false;
    public bool isRunning = false;
    public PlayerActions pa;
    float walkingSpeed,runningSpeed;

    public override void Awake(){
        base.Awake();
        attackCollider = GetComponentInChildren<Collider>();
        walkingSpeed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterWalkingSpeed;
        runningSpeed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterRunningSpeed;
        pa = new PlayerActions();

/*         pa.Deceived.Walk.performed += ctx => isWalking = true;
        pa.Deceived.Run.performed += ctx => isRunning = true;

        pa.Deceived.Walk.canceled += ctx => isWalking = false;
        pa.Deceived.Run.canceled += ctx => isRunning = false; */
    }

    // Update is called once per frame
    void Update(){
        GetSpeed();
        velocity = new Vector3(i_movement.x, i_movement.y);
    }

    public void GetSpeed(){
        if(isRunning){
            speed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterRunningSpeed;
        }else {
            speed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterWalkingSpeed;
        }
    }

    void OnWalk(InputValue value){
        i_movement = value.Get<Vector2>();        
    }

    void OnRun(InputValue value){
        if(isRunning){
            isRunning = false;
        }
        else{
            isRunning = true;
        }
    }

    void OnAttack(InputValue value){
        Collider[] gameObjectToDestroy = targets.ToArray();
        foreach(Collider collider in gameObjectToDestroy){
            targets.Remove(collider);
            Destroy(collider.gameObject);
            CharactersSpawner.instance.PNJList.RemoveAll(x=>x.name==collider.gameObject.name);
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Character"){
            targets.Add(collider);
        }
    }
    void OnTriggerExit(Collider collider){
        if(collider.tag == "Character"){
            targets.Remove(collider);
        }
    }
}
