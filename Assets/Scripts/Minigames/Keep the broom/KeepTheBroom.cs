using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepTheBroom : MonoBehaviour
{
    public PlayerKTB[] players;
    public Transform broom;
    Collider2D broomCollider;
    public PlayerKTB broomHolder;
    public float pickUpDistance;
    bool broomIsHold;
    public Vector2 broomHoldingPosition;
    public Vector2 broomSpawnPosition;
    public BarFiller scoreP1, scoreP2;
    void Start()
    {
        
        broomCollider = broom.GetComponent<Collider2D>();
        IgnoreCollisionsPlayers();
    }

    void Update(){
        if(broomIsHold){
            IncreaseHoldingTime(); 
            UpdateScoreText();
        }
        else{
            PickUpBroomFromGround();
        }
    }

    void PickUpBroomFromGround(){
        foreach(PlayerKTB player in players){
            if(Vector2.Distance(player.transform.position,broom.position) < pickUpDistance && !broomIsHold && !player.knockBacked){
                broomIsHold = true;
                broomHolder = player;  
                broomHolder.holdingBroom = true; 
                broomHolder.airJumpCount += 1;
                broomHolder.maxAirJumpCount +=1;
                broom.parent = player.transform;
                broom.localPosition = broomHoldingPosition;
                broom.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }  
    }
     public void DropBroom(PlayerKTB target){
        target.airJumpCount -= 1;
        target.maxAirJumpCount -=1;
        target.holdingBroom = false;
        //broomHolder = (PlayerKTB)broomHolder.knockBacker;
        //broomHolder.airJumpCount += 1;
        //broomHolder.maxAirJumpCount +=1;
        //broomHolder.holdingBroom = true;
        //broom.localPosition = broomHoldingPosition;
        broom.parent = null;
        broom.GetComponent<Rigidbody2D>().isKinematic = false;
        broomHolder = null;
        broomIsHold = false;
    }

    public void StealBroom(PlayerKTB stealer, PlayerKTB target){
        target.airJumpCount -= 1;
        target.maxAirJumpCount -=1;
        target.holdingBroom = false;
        broomHolder = stealer;
        broomHolder.airJumpCount += 1;
        broomHolder.maxAirJumpCount +=1;
        broomHolder.holdingBroom = true;
        broom.parent = broomHolder.transform;
        broom.localPosition = broomHoldingPosition;
    }
    public void BroomRespawn(){
        if(broomIsHold){
            DropBroom(broomHolder);
        }
        broom.transform.position = broomSpawnPosition;
    }
    void IncreaseHoldingTime(){
        if(broomIsHold){
            broomHolder.broomHoldingTime += Time.deltaTime;
        }      
    }

    void IgnoreCollisionsPlayers(){
        foreach(PlayerKTB player in players){
            foreach(PlayerKTB player2 in players){
                if(player.collid != player2.collid){
                    Physics2D.IgnoreCollision(player.collid, player2.collid);
                }
            }
            Physics2D.IgnoreCollision(player.collid, broomCollider); 
        }
    }

    void UpdateScoreText(){
        scoreP1.ChangeFillAmount(players[0].broomHoldingTime);
        scoreP2.ChangeFillAmount(players[1].broomHoldingTime);
    }
}


 
