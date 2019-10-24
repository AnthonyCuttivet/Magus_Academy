using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerPlayer : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 velocity;
    public ParticleSystem body;
    public ParticleSystem trail;
    Gradient baseGradient;
    public bool onSlot;
    public CharacterSlot slot;
    public bool locked;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        body = GetComponent<ParticleSystem>();
        baseGradient = body.colorOverLifetime.color.gradient;
    }
    void OnMove(InputValue value){
        if(!locked){
            Vector2 inputValue = value.Get<Vector2>();
            velocity = inputValue * 5f;
        }
        
    }

    void OnLock(){
        if(onSlot){
            slot.SelectSlot(this);
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
            slot.ChangeColor(body,trail);
            onSlot = true;
        }

    }
    void OnTriggerExit(Collider collider){
        if(collider.CompareTag("Slot")){
            var colorOverLife = body.colorOverLifetime;
            colorOverLife.color = baseGradient;
            var psChild = trail.colorOverLifetime;
            psChild.color = baseGradient;
            
            var gradientTrail = trail.trails.colorOverLifetime;
            gradientTrail.color = baseGradient.colorKeys[0].color;
            onSlot = false;
            slot = null;
        }
    }
}
