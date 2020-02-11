using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoundsKTB : DeathBounds
{
    KeepTheBroom gameManager;

    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KeepTheBroom>();
    }
    public override void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("Broom")){
            gameManager.BroomRespawn();
        }
        base.OnTriggerExit2D(collider);
    }
}
