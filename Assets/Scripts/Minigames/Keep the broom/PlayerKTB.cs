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
         if(attackInput){
             meleeKTB.AttackKTB(meleeKTB.playersInRangeKTB);
             attackInput = false;
         }
    }



}
