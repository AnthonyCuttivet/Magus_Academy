using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KTB_Player : MonoBehaviour
{
    Rigidbody2D rb;
    [HideInInspector]
    public CollisionCheck collisions;
    //[HideInInspector]
    public BoxCollider2D collid;
    [HideInInspector]
    public KTB_MeleeAttack melee;
    [HideInInspector]
    public Vector2 directionalInput;
    [HideInInspector]
    public Vector2 velocity;
    KTB_PlayerInput inputs;
    public PlayerInput playerInput;

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
    public GameObject feetSmoke;
    public GameObject jumpSmoke;


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
    public Animator animator;
    bool isJumping;
    public Transform spineTransform;
    public Transform RfootTransform,LfootTransform,topHeadTransform;



    void Awake()
    {
        //Time.timeScale = .2f;
        rb = GetComponent<Rigidbody2D>();
        inputs = GetComponent<KTB_PlayerInput>();
        //collid = GetComponentInChildren<Collider2D>();
        collisions = GetComponent<CollisionCheck>();
        melee = GetComponentInChildren<KTB_MeleeAttack>();
        Physics2D.gravity = gravity;
        airJumpCount = maxAirJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead && KeepTheBroom.instance.KTB_State != KeepTheBroom.KTB_States.BEFORE_GAME){
            //WallJumpedUpdate();
            KnockBackedUpdate();
            CalculVelocity();
            Jump();
            //ResetWallStickTime();
            AirJumpCountReset();
            PassingtroughPlatform();
            FlipDirection();
            OnAttackInput();
            SetAnimation();
            Vector3 newPosition = collid.transform.position;
            newPosition.y = spineTransform.position.y - 2.2f;
            //newPosition.x = spineTransform.position.x;
            collid.transform.position = newPosition;
            collid.size = new Vector2(collid.size.x,topHeadTransform.position.y - Mathf.Min(RfootTransform.position.y,LfootTransform.position.y)); 
            collisions.CheckCollisions();
        }        
    }
    void FixedUpdate(){
        if(!dead && KeepTheBroom.instance.KTB_State != KeepTheBroom.KTB_States.BEFORE_GAME){
            Move();
            BetterJump();
        }
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
                velocity = Vector2.Lerp(rb.velocity, (new Vector2(directionalInput.x * speed, rb.velocity.y)), 3 * Time.deltaTime);
            }
            else if(wallJumped){                                     //air control after a wall jump
                velocity = Vector2.Lerp(rb.velocity, (new Vector2(directionalInput.x * speed, rb.velocity.y)), 10 * Time.deltaTime);
            }

            else if(collisions.onGround){                                            //on ground movement
                velocity.x = directionalInput.x * speed;
                velocity.y = rb.velocity.y;
            }
            else if(collisions.onWall){      //wallSlide
                //wallSlide();
                //wallStick();
            }
            else{                                                               //air control
                velocity.x = Mathf.Lerp(rb.velocity.x, directionalInput.x * speed, 15 * Time.deltaTime);
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
            if(Mathf.Sign(directionalInput.x) + wallDir == 0 && wallStickCurrentTime < wallStickMaxTime && !wallJumped){
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
    public void JumpAnim(){
        if(!knockBacked){
            if(jumpInputDown){
                if(!collisions.passingTroughPlatform){
                    if(collisions.onGround){
                        isJumping = true;
                        
                    }
                }
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
                            isJumping = true;
                        } 
                        else if(airJumpCount > 0){
                            airJumpCount -= 1;
                            velocity = new Vector2(velocity.x, 0);
                            velocity += Vector2.up * jumpForce;  
                            inputIncoming = true;
                            jumpSmoke.GetComponent<ParticleSystem>().Simulate(0.0f, true, true);
                            jumpSmoke.GetComponent<ParticleSystem>().Play();
                        }
                }
                else if(airJumpCount > 0){
                    airJumpCount -= 1;
                    velocity = new Vector2(velocity.x, 0);
                    velocity += Vector2.up * jumpForce;  
                    inputIncoming = true;
                    jumpSmoke.GetComponent<ParticleSystem>().Simulate(0.0f, true, true);
                    jumpSmoke.GetComponent<ParticleSystem>().Play();
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
        if(collisions.onGround /* || collisions.onWall */ && !collisions.passingTroughPlatform){
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
        if(collisions.onGround && directionalInput.y < 0 && Mathf.Abs(directionalInput.x) < .3f ){
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
        if(collisions.groundColliders.Count > 0){
            foreach(Collider2D groundCollider in collisions.groundColliders){
                if(groundCollider.CompareTag("PassingTrough") && !collisions.ignoredColliders.Contains(groundCollider)){
                    Physics2D.IgnoreCollision(collid,groundCollider);
                    collisions.ignoredColliders.Add(groundCollider);
                }
            }
        }
    }

    void FlipDirection(){
        Quaternion newRotation = transform.rotation;
        if(directionalInput.x != 0){
            
            if(!collisions.onWall || collisions.passingTroughPlatform || collisions.onGround){
                
                if(directionalInput.x > 0){
                    newRotation.y = 0;
                    transform.rotation = newRotation;
                }
                else{
                    newRotation.y = 180;
                    transform.rotation = newRotation;
                }
            }
        }
        else if(collisions.onWall && !collisions.passingTroughPlatform && !collisions.onGround){
            float wallDir = (collisions.onLeftWall) ? -1 : 1;
                newRotation.y = wallDir ==  -1 ? 180 : 0;
                transform.rotation = newRotation;
            }
    }

    public virtual void OnAttackInput(){
        if(attackInput){
            //melee.Attack(melee.playersInRange);
            attackInput = false;
            animator.SetTrigger("isPunching");
        }
    }
    public virtual void OnAttackHit(){
        melee.Attack(melee.playersInRange);
        SoundManager.instance.PlaySound("Deceived_PunchHit");
    }
    public void Death(){
        dead = true;
        rb.gravityScale = 0;
        velocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        collid.enabled = false;
        foreach(Transform transform in transform.Find("Chibi_Mesh")){
            if(transform.name != "Chibi_Character"){
                transform.gameObject.SetActive(false);
            }
        }
        //transform.Find("Chibi_Mesh").gameObject.SetActive(false);
        feetSmoke.SetActive(false);
        transform.position = Vector3.zero;
    }
    public virtual void SetAnimation(){
        if(Mathf.Abs(velocity.x) > .05f && collisions.onGround) {
            animator.SetBool("isRunning",true);
        }
        else{
            animator.SetBool("isRunning",false);
        }
        if(!collisions.onGround && !collisions.onWall){
            animator.SetBool("isJumping",true);
        }
        else{
            animator.SetBool("isJumping",false);
        }
        if(collisions.onGround && !collisions.passingTroughPlatform){
            animator.SetBool("onGround",true);
        }
        else{
            animator.SetBool("onGround",false);
        }
        /* if(collisions.onGround || !collisions.onWall){
            animator.SetBool("isWallSliding",false);
        }
        else if((collisions.onLeftWall ^ collisions.onRightWall) && !collisions.passingTroughPlatform){
            animator.SetBool("isWallSliding",true);
        } */
        if(knockBacked){
            animator.SetBool("Knockbacked",true);
        }
        else{
            animator.SetBool("Knockbacked",false);
        }
        
    }
    public void JumpLaunched(){
        isJumping = false;
    }


    


}
