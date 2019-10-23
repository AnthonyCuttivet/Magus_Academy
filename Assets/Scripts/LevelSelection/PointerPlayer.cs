using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerPlayer : MonoBehaviour
{
    Rigidbody rb;
    Vector3 velocity;
    ParticleSystem ps;
    Gradient baseGradient;
    public bool onSlot;
    public CharacterSlot slot;
    public bool locked;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
        baseGradient = ps.colorOverLifetime.color.gradient;
    }
    void OnMove(InputValue value){
        if(!locked){
            Vector2 inputValue = value.Get<Vector2>();
            velocity = inputValue * 5f;
        }
        
    }

    void OnLock(){
        if(onSlot){

            locked = true;
            slot.SelectSlot(gameObject.name);
        }
    }
    void OnCancelLock(){
        if(locked){
            locked = false;
            slot.DeselectSlot();
        }
        
    }
    void Update(){
        rb.velocity = velocity;
    }

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Slot")){
            slot = collider.GetComponent<CharacterSlot>();
            slot.ChangeColor(ps);
            onSlot = true;
        }

    }
    void OnTriggerExit(Collider collider){
        var colorOverLife = ps.colorOverLifetime;
        colorOverLife.color = baseGradient;
        onSlot = false;
        slot = null;
    }
}
