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

    public override void Awake(){
        base.Awake();
        attackCollider = GetComponentInChildren<Collider>();
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
        if(isWalking){
            speed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterWalkingSpeed;
        }else if(isRunning){
            speed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterRunningSpeed;
        }else{
            speed = 0;
        }
    }

    void OnWalk(InputValue value){
        Vector2 inputValue = value.Get<Vector2>();
        if((inputValue.x < 0.1 && inputValue.x > -0.1) && (inputValue.y < 0.1 && inputValue.y > -0.1)){
            isWalking = false;
        }else{
            i_movement = value.Get<Vector2>();
            isWalking = true;
        }
        
    }

    void OnRun(InputValue value){
        float triggerValue = value.Get<float>();
        if(triggerValue >= 0.1f){
            isRunning = true;
            isWalking = false;
        }else if(speed > 0){
            isRunning = false;
        }else{
            isRunning = false;
        }
    }

    void OnAttack(InputValue value){
        Collider[] gameObjectToDestroy = targets.ToArray();
        foreach(Collider collider in gameObjectToDestroy){
            targets.Remove(collider);
            Destroy(collider.gameObject);
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
