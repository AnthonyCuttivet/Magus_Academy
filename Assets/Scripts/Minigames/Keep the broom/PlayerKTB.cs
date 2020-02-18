using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKTB : KTB_Player
{
    [HideInInspector]
    public float broomHoldingTime;
    MeleeAttackKTB meleeKTB;
    public bool holdingBroom;

    void Start(){
        meleeKTB = GetComponentInChildren<MeleeAttackKTB>();
    }

     public override void OnAttackInput(){
         if(attackInput && !holdingBroom){
             animator.SetTrigger("isPunching");
             //meleeKTB.AttackKTB(meleeKTB.playersInRangeKTB);
             attackInput = false;
         }
    }
    public override void OnAttackHit(){
        meleeKTB.AttackKTB(meleeKTB.playersInRangeKTB);
    }
    public override void SetAnimation(){
        if(Mathf.Abs(velocity.x) > .05f && collisions.onGround) {
            animator.SetBool("isRunning",true);
        }
        else{
            animator.SetBool("isRunning",false);
        }
        if(!collisions.onGround && !collisions.onWall || collisions.passingTroughPlatform){
            animator.SetBool("isJumping",true);
        }
        else{
            animator.SetBool("isJumping",false);
        }
        if(collisions.onGround && !collisions.passingTroughPlatform){
            animator.SetBool("onGround",true);
        }
        else{
            animator.SetBool("onGround",false);
        }
        /* if(collisions.onGround || !collisions.onWall){
            animator.SetBool("isWallSliding",false);
        }
        else if((collisions.onLeftWall ^ collisions.onRightWall) && !collisions.passingTroughPlatform){
            animator.SetBool("isWallSliding",true);
        } */
        if(knockBacked){
            animator.SetBool("Knockbacked",true);
        }
        else{
            animator.SetBool("Knockbacked",false);
        }
        if(holdingBroom){
            animator.SetBool("holdingBroom",true);
        }
        else{
            animator.SetBool("holdingBroom",false);
        }
        ParticleSystem.EmissionModule PSsmoke = feetSmoke.GetComponent<ParticleSystem>().emission;
        if(collisions.onGround && !collisions.passingTroughPlatform){
            
            if(!PSsmoke.enabled){
                PSsmoke.enabled = true;
            }
        }
        else{
            PSsmoke.enabled = false;
        }
    }
    public void SetBroomOrientation(){
        KeepTheBroom.instance.SetBroomOrientation();
    }



}
