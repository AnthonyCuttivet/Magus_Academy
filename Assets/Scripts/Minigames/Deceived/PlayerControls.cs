using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : Controls
{
    private Vector2 i_movement;
    private Vector3 i_rotation;
    Collider attackCollider;
    public Vector3 attackArea;
    Transform shotSpawnPoint;
    public List<Collider> targets = new List<Collider>();
    public bool isWalking = false;
    public bool isRunning = false;
    public PlayerActions pa;
    float walkingSpeed,runningSpeed;
    public Player infos;
    SoundManager soundManager;
    public GameObject projectileGO;
    public bool alive = true;
    bool postmortem;
    bool killAnimation;

    [Space]
    [Header("Spells")]
    public bool invisibilityField = true;
    public bool magicSpear = true;
    public bool divineLight = true;
    public float divineLightSpeed;
    private GameObject dlInstance;
    private Animator animator;
    Vector3 shotOriginPosition;
    Quaternion shotOriginRotation;
    bool castingSpell;
    bool isPunching;

    public override void Awake(){
        base.Awake();
        attackCollider = GetComponentInChildren<Collider>();
        shotSpawnPoint = transform.Find("ShotSpawn").GetComponent<Transform>();
        walkingSpeed = PlayersSettings.instance.characterWalkingSpeed;
        runningSpeed = PlayersSettings.instance.characterRunningSpeed;
        divineLightSpeed = PlayersSettings.instance.divineLightSpeed;
        pa = new PlayerActions();
        animator = gameObject.GetComponent<Animator>();
    }
    void Start(){
        soundManager = SoundManager.instance;
    }
 


    public override void Update(){
        base.Update();
        GetSpeed();
        if(!castingSpell && (alive || postmortem)){
            velocity = new Vector3(i_movement.x, i_movement.y);
        }
        else{
            velocity = Vector3.zero;
        }
        
        //Animation
        animator.SetBool("isRunning", isRunning);
    }

    public void GetSpeed(){
        if(alive){
            if(isRunning){
                speed = GameObject.Find("DeceivedManager").GetComponent<PlayersSettings>().characterRunningSpeed;
            }else {
                speed = GameObject.Find("DeceivedManager").GetComponent<PlayersSettings>().characterWalkingSpeed;
            }
        }
        else{
            speed = divineLightSpeed;
        }
        
    }

     public float GetAngle(Vector2 p_vector2){
         if (p_vector2.x < 0)
         {
             return 360 - (Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg * -1);
         }
         else
         {
             return Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg;
         }
     }

    void OnWalk(InputValue value){
        if(alive && gameStarted){
            i_movement = value.Get<Vector2>();
            if(value.Get<Vector2>() != Vector2.zero){
                animator.SetBool("isWalking", true);
                //animator.SetBool("isRunning", false);
                gameObject.transform.rotation = Quaternion.Euler(0,GetAngle(i_movement),0);
            }
            else{
                i_movement = Vector2.zero;
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
        }
        else if(gameStarted && postmortem){
                i_movement = value.Get<Vector2>();
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
        
    }

    void OnRun(InputValue value){
        if(gameStarted){
            if(value.Get<float>() <= 0.5f){
                isRunning = false;
            }
            else{
                isRunning = true;
            }
        }
    }

    void OnAttack(InputValue value){
        if(gameStarted){
            if(alive && !isPunching){
                animator.SetTrigger("isPunching");
                isPunching = true;
            }
        }
    }
    void AttackHit(){
        if(alive){
            Collider[] gameObjectToDestroy = targets.ToArray();
            foreach(Collider collider in gameObjectToDestroy){
                if(collider){                                           //if a pnj is killed while in the attack area (the collider is still in the targets list but doesnt exist anymore)
                    collider.GetComponent<Controls>().Kill(int.Parse(gameObject.name.Replace("Player", "")));
                }
                targets.Remove(collider);
            }
            if(gameObjectToDestroy.Length > 0){
                soundManager.PlaySound("Deceived_PunchHit");
            }
            isPunching = false;
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Character"){
            targets.Add(collider);
        }
    }
    void OnTriggerExit(Collider collider){
        if(collider.tag == "Character"){
            targets.Remove(collider);
        }
    }

    void OnShoot(){
        if(alive && magicSpear && gameStarted){
            animator.SetTrigger("isAttacking");         
            magicSpear = false;
            shotOriginPosition = shotSpawnPoint.position;
            shotOriginRotation = shotSpawnPoint.rotation;
            castingSpell = true;
            DeceivedManager.instance.FadeUISpell(DeceivedManager.Spells.Shot, infos.Id);
        }
    }
    public void SpawnShot(){
        GameObject shot = Instantiate(CharactersSpawner.instance.shot,shotOriginPosition,shotOriginRotation);
        shot.GetComponent<Shot>().shooter = gameObject.name;
        shot.GetComponent<Shot>().skin = System.Enum.GetName(typeof(CharacterAttribute.MagesAttributes), infos.Skin);
        SetShotSkin(shot);
        soundManager.PlaySound("Deceived_" + System.Enum.GetName(typeof(CharacterAttribute.MagesAttributes), infos.Skin) + "_Shot");
    }
    public void SpellEndedCast(){
        castingSpell = false;
    }

    void OnForceField(){
        if(alive && invisibilityField && gameStarted){
            Instantiate(CharactersSpawner.instance.forceField, gameObject.transform.localPosition, gameObject.transform.rotation);
            invisibilityField = false;
            soundManager.PlaySound("Deceived_Shield");
            DeceivedManager.instance.FadeUISpell(DeceivedManager.Spells.Invisibility, infos.Id);
        }
    }

    void OnResetSpells(){   
        invisibilityField = true;
        magicSpear = true;
        divineLight = true;
    }
    void SetShotSkin(GameObject shot){
        Gradient color = DeceivedManager.instance.projectileColors[infos.Skin];
        var psMain = shot.GetComponent<ParticleSystem>().main;
        psMain.startColor = color;
        ParticleSystem subParticles = shot.transform.Find("subParticles").GetComponent<ParticleSystem>();
        ParticleSystem.MainModule psChild = subParticles.main;
        psChild.startColor = color;
        TrailRenderer trail = shot.GetComponentInChildren<TrailRenderer>();
        Gradient colorTrail = new Gradient();
        colorTrail.colorKeys = color.colorKeys;
        colorTrail.alphaKeys = trail.colorGradient.alphaKeys;
        trail.colorGradient = colorTrail;
        Light light = shot.GetComponentInChildren<Light>();
        light.color = color.colorKeys[0].color; 
    }

    public override void Kill(int killer){

        //Fade UI
        DeceivedManager.instance.KillUIPlayer(infos.Id);

        //Save score
        alive = false;
        velocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        GetComponent<DeceivedScoring>().alive = false;

        DeceivedManager.instance.deceivedScores[infos.Id] = GetComponent<DeceivedScoring>().score;

        DeceivedManager.instance.scoresSaved++;
        //Give points to the killer
        GameObject gKiller = GameObject.Find("Characters/Player"+killer);
        gKiller.GetComponent<DeceivedScoring>().score += PlayersSettings.instance.pointsPerElimination;

        Debug.Log(gameObject.name + " was killed by player " + killer);
        CharactersSpawner.instance.players.Remove(gameObject);       
        DeceivedManager.instance.StopMusicSkin(infos.Skin);

        //if killer is winner save its score
        if(CharactersSpawner.instance.players.Count == 1){
            gKiller.GetComponent<DeceivedScoring>().score += PlayersSettings.instance.victoryPoints;
            DeceivedManager.instance.deceivedScores[gKiller.GetComponent<PlayerControls>().infos.Id] = gKiller.GetComponent<DeceivedScoring>().score;
            DeceivedManager.instance.scoresSaved++;
        }
        animator.SetTrigger("isKilled");
    }
    public void KillAnimationFinished(){
        foreach(Transform g in gameObject.transform.Find("Parts")){
            if(g.name != "Chibi_Character"){
                g.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
        }
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerInput>().defaultActionMap = "Deceived_PM";
        postmortem = true;
    }

    #region PM
    //Post mortem spells

    void OnDivineLight(){
        if(!alive && divineLight && dlInstance == null){
            dlInstance = Instantiate(CharactersSpawner.instance.divineLight, DeceivedManager.instance.mapCenter.position + CharactersSpawner.instance.divineLight.transform.transform.position, CharactersSpawner.instance.divineLight.transform.rotation,gameObject.transform);
            divineLight = false;
            soundManager.PlaySound("Deceived_DivineLight");
        }
    }






    #endregion
}
