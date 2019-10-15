using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJControls : Controls
{
    void Start(){
        InvokeRepeating("CalculateVelocity", 0, Random.Range(2,5));
    }

    void CalculateVelocity(){
        Vector2 newVelocity = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
        velocity = Vector2.Lerp(velocity,newVelocity,Random.Range(0f,1f));
        
    }
}
