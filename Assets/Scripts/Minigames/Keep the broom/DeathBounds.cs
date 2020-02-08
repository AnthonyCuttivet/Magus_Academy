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
        if(collider.CompareTag("PlayerHitbox")){
            collider.GetComponentInParent<KTB_Player>().Death();
            collider.transform.parent.Find("DeathGamePlay").GetComponent<KTB_DeathGamePlay>().ActivatePostMortem();
        }
        
    }


}
