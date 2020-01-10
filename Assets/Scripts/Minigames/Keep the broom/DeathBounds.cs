using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBounds : MonoBehaviour
{
    Collider2D safeZone;
    void Start()
    {
        safeZone = GetComponent<Collider2D>();
    }
    public virtual void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            collider.GetComponent<KTB_Player>().dead = true;
            collider.GetComponentInChildren<KTB_DeathGamePlay>().ActivatePostMortem();
        }
        
    }


}
