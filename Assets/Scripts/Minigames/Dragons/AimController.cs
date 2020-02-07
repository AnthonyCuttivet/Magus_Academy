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
    public Dragon isFishing;
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
        if(dragonToFish != null && dragonToFish.fished == false){
            direction = Vector2.zero;
            isFishing = dragonToFish;
            playerController.StartQTE();
            dragonToFish.fished = true;
        }
    }
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Dragon")){
            dragonToFish = collider.GetComponent<Dragon>();
        }
    }

    void OnTriggerExit(Collider collider){
        dragonToFish = null;
    }

    public void EndFishing(){
        generationRemous.fishesColliders = new List<Collider>();
        isFishing.DeleteDragon();
    }
}
