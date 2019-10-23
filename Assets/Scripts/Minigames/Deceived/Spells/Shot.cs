﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Rigidbody rb;
    Vector3 shotOrigin;
    public float distanceBeforeDestroy;
    public float timeBeforeDestroy;
    float aliveTimer;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * 50;
        shotOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        aliveTimer += Time.deltaTime;
        DestroyProjectile();
    }

    void DestroyProjectile(){
        if((Vector3.Distance(shotOrigin,transform.position)  > distanceBeforeDestroy) || (aliveTimer > timeBeforeDestroy)){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Character"){
            collider.GetComponent<Controls>().Kill();
        }

       
    }
}