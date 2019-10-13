using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private Vector2 i_movement;

    void Start(){
        Debug.Log(Gamepad.current);
    }

    // Update is called once per frame
    void Update(){
        Vector3 movement = new Vector3(i_movement.x, 0, i_movement.y) * 5f * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnWalk(InputValue value){
        i_movement = -value.Get<Vector2>();
    }
}
