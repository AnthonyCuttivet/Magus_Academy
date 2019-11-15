using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody rb;
    public float speed;
    public DragonQTE_PlayerControls playerController;
    Quaternion rotation;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    void LateUpdate(){
    }

    void FixedUpdate(){
        rb.velocity = new Vector3(direction.x,0,direction.y) * speed;
    }
    public void Fish(){
        playerController.GenerateSequence(transform);
    }
}
