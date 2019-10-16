﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSettings : MonoBehaviour
{
    public static PlayersSettings instance;

    public float characterWalkingSpeed = 5f;
    public float characterRunningSpeed = 10f;
    public float pnjWalkingSpeed = 5;
    public float pnjDistanceToWalk = 15;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }
}
