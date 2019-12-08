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

    public bool alive = true;

    [Space]
    [Header("Spells")]
    public bool invisibilityField = true;
    public bool magicSpear = true;
    public bool divineLight = true;
    public float divineLightSpeed;
    private GameObject dlInstance;

    public override void Awake(){
        base.Awake();
        attackCollider = GetComponentInChildren<Collider>();
        shotSpawnPoint = transform.Find("ShotSpawn").GetComponent<Transform>();
        walkingSpeed = PlayersSettings.instance.characterWalkingSpeed;
        runningSpeed = PlayersSettings.instance.characterRunningSpeed;
        divineLightSpeed = PlayersSettings.instance.divineLightSpeed;
        pa = new PlayerActions();
    }

    // Update is called once per frame
    public override void  Update(){
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space)){
            Kill();
        }
        GetSpeed();
        velocity = new Vector3(i_movement.x, i_movement.y);
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
        i_movement = value.Get<Vector2>();
        if(alive && gameStarted){
            if(value.Get<Vector2>() != Vector2.zero){
                gameObject.GetComponent<Animator>().SetBool("isWalking", true);
                gameObject.GetComponent<Animator>().SetBool("isRunning", false);
                gameObject.transform.rotation = Quaternion.Euler(0,GetAngle(i_movement),0);
            }else{
                gameObject.GetComponent<Animator>().SetBool("isWalking", false);
                gameObject.GetComponent<Animator>().SetBool("isRunning", false);
            }
            
        }else if(!alive && divineLight && dlInstance != null){

            //dlInstance.transform.Translate(new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y, 0));
        }
    }

    void OnRun(InputValue value){
        if(gameStarted){
            if(isRunning){
                isRunning = false;
                gameObject.GetComponent<Animator>().SetBool("isRunning", false);
            }
            else{
                isRunning = true;
                gameObject.GetComponent<Animator>().SetBool("isRunning", true);
            }
        }
    }

    void OnAttack(InputValue value){
        if(gameStarted){
            if(alive && gameStarted){
                Collider[] gameObjectToDestroy = targets.ToArray();
                foreach(Collider collider in gameObjectToDestroy){
                    if(collider){                                           //if a pnj is killed while in the attack area (the collider is still in the targets list but doesnt exist anymore)
                        collider.GetComponent<Controls>().Kill();
                    }
                    targets.Remove(collider);
                }
            }
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
            Instantiate(CharactersSpawner.instance.shot,shotSpawnPoint.position,shotSpawnPoint.rotation);
            magicSpear = false;
        }
    }

    void OnForceField(){
        if(alive && invisibilityField && gameStarted){
            Instantiate(CharactersSpawner.instance.forceField, gameObject.transform.localPosition, gameObject.transform.rotation);
            invisibilityField = false;
        }
    }

    void OnResetSpells(){
        invisibilityField = true;
        magicSpear = true;
        divineLight = true;
    }

    public override void Kill(){
            CharactersSpawner.instance.players.Remove(gameObject);
            foreach(Transform g in gameObject.transform.Find("Parts")){
                if(g.name != "Chibi_Character"){
                    g.GetComponent<SkinnedMeshRenderer>().enabled = false;
                }
            }
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<PlayerInput>().defaultActionMap = "Deceived_PM";
            alive = false;
            MinigameStats.instance.ranking.Add(gameObject.name);
    }

    #region PM
    //Post mortem spells

    void OnDivineLight(){
        if(!alive && divineLight){
            dlInstance = Instantiate(CharactersSpawner.instance.divineLight, CharactersSpawner.instance.divineLight.transform.localPosition, CharactersSpawner.instance.divineLight.transform.rotation,gameObject.transform);
            //divineLight = false;
        }
    }






    #endregion
}
