using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackKTB : KTB_MeleeAttack
{
    public List<PlayerKTB> playersInRangeKTB = new List<PlayerKTB>();
    public PlayerKTB playerKTB;
    public KeepTheBroom gameManager;

    public override void Start(){
        base.Start();
        playerKTB = (PlayerKTB)player;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KeepTheBroom>();
    }

    public void AttackKTB(List<PlayerKTB> playersToAttackKTB){
        if(!playerKTB.holdingBroom){                            //Si le joueur a le balai il ne peut pas attaquer         
            List<KTB_Player> playersToAttack = playersInRangeKTB.ConvertAll(x => (KTB_Player)x);                              
            base.Attack(playersToAttack);
            foreach(PlayerKTB target in playersToAttackKTB){
                if(target.holdingBroom){
                    gameManager.StealBroom(playerKTB,target);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("PlayerHitbox") && collider != player.collid){
            playersInRangeKTB.Add(collider.GetComponentInParent<PlayerKTB>());
        }  
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("PlayerHitbox")){
            playersInRangeKTB.Remove(collider.GetComponentInParent<PlayerKTB>());
        }
    }
}
