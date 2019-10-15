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
    public override void  Awake(){
        base.Awake();
        attackCollider = GetComponentInChildren<Collider>();
    }

    // Update is called once per frame
    void Update(){
        velocity = new Vector3(i_movement.x, i_movement.y);
    }

    void OnWalk(InputValue value){
        i_movement = -value.Get<Vector2>();
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
