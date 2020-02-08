using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public bool fished;
    Collider colliderDragon;
    public int pointsMultiplier = 1;

    void Awake()
    {
        colliderDragon = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update(){

    }


    public void DeleteDragon(){
        GenerationRemous.instance.fishesColliders.Remove(colliderDragon);
        Destroy(gameObject);
    }
}
