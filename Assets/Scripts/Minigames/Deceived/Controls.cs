using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    protected Rigidbody rb;
    protected Vector2 velocity;
    public float speed;
    

    public virtual void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        Move(velocity);
    }

    void Move(Vector2 _velocity){
        rb.velocity = new Vector3(_velocity.x,0,_velocity.y) * speed;
    }

    public virtual void Kill(){

    }
}
