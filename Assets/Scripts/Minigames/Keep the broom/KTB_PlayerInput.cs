using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class KTB_PlayerInput : MonoBehaviour
{
    KTB_Player player;
    public KTB_DeathGamePlay deathGamePlay;
    public KTB_PlayerControls inputActions;
    Animator animator;
    void Awake(){
        animator = GetComponent<Animator>();
        player = GetComponent<KTB_Player>();
        deathGamePlay = GetComponentInChildren<KTB_DeathGamePlay>();
    }

    void OnAttack(){
        player.attackInput = true;
    }
    void OnJump(InputValue value){
        if(value.Get<float>() <= .5f){
            player.jumpInputDown = false;
            player.jumpInputUP = true;
        }
        else {
            player.jumpInputDown = true;
            player.jumpInputUP = false;
        }

    }
    void OnMove(InputValue value){
        player.SetDirectionalInput(value.Get<Vector2>());
    }
    void OnDeathGamePlayAttack(){
        deathGamePlay.attackInput = true;
    }
    void OnDeathMove(InputValue value){
        deathGamePlay.directionnalInput = value.Get<Vector2>();
    }

    public void OnSelect(){
        KeepTheBroom.instance.announcer = !KeepTheBroom.instance.announcer;
    }


}
