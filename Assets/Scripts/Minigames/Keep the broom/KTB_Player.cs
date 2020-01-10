using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTB_Player : MonoBehaviour
{
    Rigidbody2D rb;
    [HideInInspector]
    public CollisionCheck collisions;
    [HideInInspector]
    public Collider2D collid;
    [HideInInspector]
    public KTB_MeleeAttack melee;
    [HideInInspector]
    public Vector2 directionalInput;
    [HideInInspector]
    public Vector2 velocity;
    KTB_PlayerInput inputs;

    [Space]
    [Header("Stats")]
    public int playerNumber;
    public float speed;
    public float jumpForce;
    //[HideInInspector]
    public float airJumpCount;
    public float maxAirJumpCount;
    public Vector2 wallJumpForce;
    public float wallslideSpeed;
    public Vector2 gravity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float wallStickMaxTime;
    float wallStickCurrentTime;
    public float wallJumpedMinimumTime;
    float wallJumpedMinimumCurrentTime;
    public float knockBackTime;


    //Bool
    [HideInInspector]
    public bool jumpInputDown;
    [HideInInspector]
    public bool jumpInputUP;
    public bool attackInput;
    [HideInInspector]
    public bool inputIncoming;     //to avoid rewriting velocity between 2 update before applying it in fixedUpdate, for jump and knockBack
    [HideInInspector]
    public bool wallJumped;
    [HideInInspector]
    public bool knockBacked;
    [HideInInspector]
    public bool dead;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputs = GetComponent<KTB_PlayerInput>();
        collid = GetComponent<Collider2D>();
        collisions = GetComponent<CollisionCheck>();
        melee = GetComponentInChildren<KTB_MeleeAttack>();
        Physics2D.gravity = gravity;
        airJumpCount = maxAirJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead){
            collisions.CheckCollisions();
            WallJumpedUpdate();
            KnockBackedUpdate();
            CalculVelocity();
            Jump();
            ResetWallStickTime();
            AirJumpCountReset();
            PassingtroughPlatform();
            FlipDirection();
            OnAttackInput();
        }
    }
    void FixedUpdate(){
        Move();
        BetterJump();
    }

    public void SetDirectionalInput(Vector2 input){
        directionalInput = input;
    }
    void CalculVelocity(){
        if(!inputIncoming ){
            velocity = rb.velocity;
            velocity.x = directionalInput.x * speed;
            velocity.y = rb.velocity.y;
            if(knockBacked){                                     //air control after a wall jump
                velocity = Vector2.Lerp(rb.velocity, (new Vector2(directionalInput.x * speed, rb.velocity.y)), 5 * Time.deltaTime);
            }
            else if(wallJumped){                                     //air control after a wall jump
                velocity = Vector2.Lerp(rb.velocity, (new Vector2(directionalInput.x * speed, rb.velocity.y)), 10 * Time.deltaTime);
            }

            else if(collisions.onGround){                                            //on ground movement
                velocity.x = directionalInput.x * speed;
                velocity.y = rb.velocity.y;
            }
            else if(collisions.onWall){      //wallSlide
                wallSlide();
                wallStick();
            }
             
            else{                                                               //air control
                velocity.x = directionalInput.x * speed;
                velocity.y = rb.velocity.y;
            } 
        }   
    }

    void Move(){
        rb.velocity = velocity; 
        inputIncoming = false;      
    }
    void wallStick(){
        if(!collisions.passingTroughPlatform){
            float wallDir = (collisions.onLeftWall) ? -1 : 1;
            if(directionalInput.x + wallDir ==0 && wallStickCurrentTime < wallStickMaxTime && !wallJumped){
                wallStickCurrentTime += Time.deltaTime;
                velocity.x = 0;
            }
            else{
                velocity.x = directionalInput.x * speed;
            }
        }
    }

    void ResetWallStickTime(){
        if(!collisions.onWall){
            wallStickCurrentTime = 0;
        }
    }
    void wallSlide(){
        if(!collisions.passingTroughPlatform){
            if(rb.velocity.y < -wallslideSpeed){
                velocity.y = -wallslideSpeed;
            }
        }
    }

    public void Jump(){
        if(!knockBacked){
            if(jumpInputDown){
                if(!collisions.passingTroughPlatform){
                        if(collisions.onGround){
                            velocity = new Vector2(velocity.x, 0);
                            velocity += Vector2.up * jumpForce;  
                            inputIncoming = true;
                        }
                        else if(collisions.onWall){
                            WallJump();
                            inputIncoming = true;
                        }  
                        else if(airJumpCount > 0){
                            airJumpCount -= 1;
                            velocity = new Vector2(velocity.x, 0);
                            velocity += Vector2.up * jumpForce;  
                            inputIncoming = true;
                        }
                }
                else if(airJumpCount > 0){
                    airJumpCount -= 1;
                    velocity = new Vector2(velocity.x, 0);
                    velocity += Vector2.up * jumpForce;  
                    inputIncoming = true;
                }
            }
            
        }
        
        jumpInputDown = false;
    }
    void WallJump(){
        velocity = wallJumpForce;
        velocity.x *= (collisions.onLeftWall) ? 1 : -1;
        wallJumped = true;
    }
    void BetterJump(){
        if(rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && jumpInputUP){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    void AirJumpCountReset(){
        if(collisions.onGround || collisions.onWall && !collisions.passingTroughPlatform){
            airJumpCount = maxAirJumpCount;
        }
    }
    void WallJumpedUpdate(){
        if(collisions.onGround || collisions.onWall && wallJumpedMinimumCurrentTime > wallJumpedMinimumTime ){
            wallJumped = false;
            wallJumpedMinimumCurrentTime = 0;
        }
        else if(wallJumped){
            wallJumpedMinimumCurrentTime += Time.deltaTime;
        }
    }
    void KnockBackedUpdate(){
        if(knockBackTime <= 0){
            knockBacked = false;
        }
        else if(knockBacked){
            knockBackTime -= Time.deltaTime;
        }
    }

    void PassingtroughPlatform(){
        if(collisions.underRoof && (rb.velocity.y > 0 || inputIncoming) && !knockBacked){
            JumpingTroughPlatform();
        }
        if(collisions.onGround && directionalInput.y == -1){
            DropTroughPlatform();
        }
        List<Collider2D> tempIgnoredList = new List<Collider2D>(collisions.ignoredColliders);
        foreach(Collider2D ignoredCollider in collisions.ignoredColliders){
            if(!collisions.bodyColliders.Contains(ignoredCollider) && !collisions.groundColliders.Contains(ignoredCollider) && !collisions.roofColliders.Contains(ignoredCollider)){
                Physics2D.IgnoreCollision(collid,ignoredCollider,false);
                tempIgnoredList.Remove(ignoredCollider);
            }
        }
        collisions.ignoredColliders = tempIgnoredList;
    }
    void JumpingTroughPlatform(){
        foreach(Collider2D roofCollider in collisions.roofColliders){
            if(roofCollider.CompareTag("PassingTrough") && !collisions.ignoredColliders.Contains(roofCollider)){
                Physics2D.IgnoreCollision(collid,roofCollider);
                collisions.ignoredColliders.Add(roofCollider);
            }
        } 
    }
    void DropTroughPlatform(){
        foreach(Collider2D groundCollider in collisions.groundColliders){
            if(groundCollider.CompareTag("PassingTrough") && !collisions.ignoredColliders.Contains(groundCollider)){
                Physics2D.IgnoreCollision(collid,groundCollider);
                collisions.ignoredColliders.Add(groundCollider);
            }
        }
    }

    void FlipDirection(){
        if(directionalInput.x != 0){
            transform.localScale = new Vector2(Mathf.Sign(directionalInput.x) * Mathf.Abs(transform.localScale.x),transform.localScale.y);
        }
    }

    public virtual void OnAttackInput(){
        if(attackInput){
            melee.Attack(melee.playersInRange);
            attackInput = false;
        }
    }


    


}
