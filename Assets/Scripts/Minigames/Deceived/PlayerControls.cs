using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : Controls
{
    private Vector2 i_movement;

    void Awake(){
        
    }

    // Update is called once per frame
    void Update(){
        velocity = new Vector3(i_movement.x, i_movement.y);
    }

    void OnWalk(InputValue value){
        i_movement = -value.Get<Vector2>();
    }
}
