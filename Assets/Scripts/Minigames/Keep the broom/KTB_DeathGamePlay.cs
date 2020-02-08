using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTB_DeathGamePlay : MonoBehaviour
{
    public List<PlayerKTB> playersInRange = new List<PlayerKTB>();
    KTB_Player player;
    Collider2D area;
    KeepTheBroom gameManager;
    public int useCount;
    public Vector2 explosionForce;
    public float knockBackDuration = .8f;
    KTB_PlayerInput inputs;
    public bool attackInput;
    SpriteRenderer crosshair;
    bool postMortemActive;
    Rigidbody2D rb;
    public Vector2 directionnalInput;

    void Start()
    {
        player = GetComponentInParent<KTB_Player>();
        inputs = GetComponentInParent<KTB_PlayerInput>();
        area = GetComponent<CircleCollider2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KeepTheBroom>();
        crosshair = GetComponent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if(postMortemActive){
            rb.velocity = directionnalInput * player.speed;
            if(attackInput && useCount > 0){
                foreach(PlayerKTB target in playersInRange){
                    Vector2 direction = target.transform.position - area.transform.position;
                    direction = direction / direction.magnitude;
                    target.velocity = new Vector2(explosionForce.x * direction.x, explosionForce.y * direction.y); 
                    target.knockBacked = true;
                    target.knockBackTime = knockBackDuration;
                    target.inputIncoming = true;
                    if(target.holdingBroom){
                        gameManager.DropBroom(target);
                    }
                }
                useCount -= 1;
                attackInput = false;
            }  
        }
        if(useCount == 0){
            DeactivatePostMortem();
        }
            
    }
    
    public void ActivatePostMortem(){
            crosshair.enabled = true;
            postMortemActive = true;
            player.playerInput.currentActionMap.Disable();
            player.playerInput.SwitchCurrentActionMap("Dead");

    }
    void DeactivatePostMortem(){
        crosshair.enabled = false;
        postMortemActive = false;
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("PlayerHitbox") && collider != player.collid){
            playersInRange.Add(collider.GetComponentInParent<PlayerKTB>());
        }
        
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("PlayerHitbox")){
            playersInRange.Remove(collider.GetComponentInParent<PlayerKTB>());
        }
    }
}
