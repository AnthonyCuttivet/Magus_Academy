using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTB_MeleeAttack : MonoBehaviour
{
    [HideInInspector]
    public List<KTB_Player> playersInRange;
    [HideInInspector]
    public KTB_Player player;
    public Vector2 knockBackForce = new Vector2(22,18);
    public float knockBackDuration = .5f;

    public virtual void Start(){
        player = GetComponentInParent<KTB_Player>();
        playersInRange = new List<KTB_Player>();
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("PlayerHitbox") && collider != player.collid){
            playersInRange.Add(collider.GetComponent<KTB_Player>());
        }
        
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("PlayerHitbox")){
            playersInRange.Remove(collider.GetComponent<KTB_Player>());
        }
    }

    public virtual void Attack(List<KTB_Player> playersToAttack){
        if(!player.knockBacked){
            foreach(KTB_Player target in playersToAttack){
                KnockBack(target); 
            }
            if(playersToAttack.Count > 0){
                SoundManager.instance.PlaySound("Deceived_PunchHit");
            }
        }
    }

    void KnockBack(KTB_Player target){
        Vector2 direction = target.transform.position - player.transform.position;
        direction = direction / direction.magnitude;
        target.velocity = new Vector2(knockBackForce.x * direction.x, knockBackForce.y); 
        target.knockBacked = true;
        target.inputIncoming = true;
        target.knockBackTime = knockBackDuration;
    }    
}
