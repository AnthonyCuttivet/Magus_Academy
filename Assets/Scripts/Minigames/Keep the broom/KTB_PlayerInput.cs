﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class KTB_PlayerInput : MonoBehaviour
{
    KTB_Player player;
    public KTB_DeathGamePlay deathGamePlay;
    public KTB_PlayerControls inputActions;
    void Awake()
    {
        player = GetComponent<KTB_Player>();
        deathGamePlay = GetComponentInChildren<KTB_DeathGamePlay>();
    }

    void OnAttack(){
        player.attackInput = true;
    }
    void OnJump(){
        player.jumpInputDown = true;
        player.jumpInputUP = false;
    }
    void OnMove(InputValue value){
        player.SetDirectionalInput(value.Get<Vector2>());
    }
    void OnDeathGamePlayAttack(){
        Debug.Log("OnDeathGamePlayAttack");
        deathGamePlay.attackInput = true;
    }
    void OnDeathMove(InputValue value){
        deathGamePlay.directionnalInput = value.Get<Vector2>();
    }


}
