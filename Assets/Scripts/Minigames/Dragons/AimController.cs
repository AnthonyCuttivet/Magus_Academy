using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody rb;
    public float speed;
    public DragonQTE_PlayerControls playerController;
    public bool fishable = false;
    Quaternion rotation;
    List<GameObject> dragonsToFish = new List<GameObject>();

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    void LateUpdate(){
    }

    void FixedUpdate(){
        rb.velocity = new Vector3(direction.x,0,direction.y) * speed;
    }
    public void Fish(){
        if(dragonsToFish.Count != 0){
            direction = Vector2.zero;
            playerController.GenerateSequence(transform);
        }

    }
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Dragon")){
            dragonsToFish.Add(collider.gameObject);
        }
    }
    void OnTriggerExit(Collider collider){
        if(collider.CompareTag("Dragon")){
            dragonsToFish.Remove(collider.gameObject);
        }
    }
}
