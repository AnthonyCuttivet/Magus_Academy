using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJControls : Controls
{
    public override void Start(){
        base.Start();
        InvokeRepeating("CalculateVelocity", 0, Random.Range(2,5));
    }

    void CalculateVelocity(){
        velocity = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
    }
}
