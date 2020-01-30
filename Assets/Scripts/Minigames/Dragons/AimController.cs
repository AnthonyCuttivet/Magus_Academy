using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody rb;
    public float speed;
    public QTE playerController;
    public bool fishable = false;
    Quaternion rotation;
    public Dragon dragonToFish;
    public GenerationRemous generationRemous; 

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    void Start(){
         generationRemous = GenerationRemous.instance;
    }
    void LateUpdate(){
    }

    void FixedUpdate(){
        rb.velocity = new Vector3(direction.x,0,direction.y) * speed;
    }

    public void Fish(){
        if(dragonToFish != null /* && dragonToFish != true */){
            direction = Vector2.zero;
            playerController.StartQTE();
            dragonToFish.fished = true;
        }
    }
    void OnTriggerStay(Collider collider){
        if(collider.CompareTag("Dragon")){
            dragonToFish = collider.GetComponent<Dragon>();
        }
    }
    public void EndFishing(){
        
        dragonToFish = null;
        generationRemous.fishesColliders = new List<Collider>();
        dragonToFish.DeleteDragon();
    }
}
