using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        
        if(collider.transform.parent.CompareTag("Player")){
            Debug.Log("broom pick up");
            KeepTheBroom.instance.PickUpBroomFromGround(collider.GetComponentInParent<PlayerKTB>());
        }
        
    }
}
