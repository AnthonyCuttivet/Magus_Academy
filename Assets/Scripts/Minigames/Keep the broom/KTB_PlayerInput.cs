using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTB_PlayerInput : MonoBehaviour
{
    KTB_Player player;
    public KTB_DeathGamePlay deathGamePlay;
    void Start()
    {
        player = GetComponent<KTB_Player>();
        deathGamePlay = GetComponentInChildren<KTB_DeathGamePlay>();
    }
    void Update(){
        InputHandler();
    }


    public void InputHandler(){
        if(!player.dead){
            Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Player" + player.playerNumber +" Horizontal"),Input.GetAxisRaw("Player" + player.playerNumber + " Vertical"));
        player.SetDirectionalInput(directionalInput);
        if(Input.GetButtonDown("Player" + player.playerNumber +" Jump")){
            player.jumpInputDown = true;
            player.jumpInputUP = false;
        }
        else if(Input.GetButtonUp("Player" + player.playerNumber +" Jump")){
            player.jumpInputUP = true;
        }
        if(Input.GetButtonDown("Player" + player.playerNumber + " Fire")){
            player.attackInput = true;
        }
        }
        else{
            if(Input.GetButtonDown("Player" + player.playerNumber + " Fire")){
                deathGamePlay.attackInput = true;
        }
        }
        
    }
}
