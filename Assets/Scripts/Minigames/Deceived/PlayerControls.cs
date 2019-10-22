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
    List<Collider> targets = new List<Collider>();
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

    private GameObject dlInstance;

    public override void Awake(){
        base.Awake();
        attackCollider = GetComponentInChildren<Collider>();
        shotSpawnPoint = transform.Find("ShotSpawn").GetComponent<Transform>();
        walkingSpeed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterWalkingSpeed;
        runningSpeed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterRunningSpeed;
        pa = new PlayerActions();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            OnShoot();
        }
        GetSpeed();
        velocity = new Vector3(i_movement.x, i_movement.y);
    }

    public void GetSpeed(){
        if(isRunning){
            speed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterRunningSpeed;
        }else {
            speed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterWalkingSpeed;
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
        if(alive){
            if(value.Get<Vector2>() != Vector2.zero){
                gameObject.transform.rotation = Quaternion.Euler(0,GetAngle(i_movement),0);
            }
            i_movement = value.Get<Vector2>();
        }else if(!alive && divineLight && dlInstance != null){
            dlInstance.transform.Translate(new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y, 0));
        }
    }

    void OnRun(InputValue value){
        if(isRunning){
            isRunning = false;
        }
        else{
            isRunning = true;
        }
    }

    void OnAttack(InputValue value){
        if(alive){
            Collider[] gameObjectToDestroy = targets.ToArray();
            foreach(Collider collider in gameObjectToDestroy){
                targets.Remove(collider);
                collider.GetComponent<Controls>().Kill();
    /*             Destroy(collider.gameObject);
                CharactersSpawner.instance.PNJList.RemoveAll(x=>x.name==collider.gameObject.name); */
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
        if(alive && magicSpear){
            Instantiate(CharactersSpawner.instance.shot,shotSpawnPoint.position,shotSpawnPoint.rotation);
            magicSpear = false;
        }
        //g.transform.Rotate(new Vector3(90f,0,0));
    }

    void OnForceField(){
        if(alive && invisibilityField){
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
        if(gameObject.name.Contains("Player")){
            CharactersSpawner.instance.players.Remove(gameObject);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<PlayerInput>().defaultActionMap = "Deceived_PM";
            gameObject.GetComponent<PlayerControls>().alive = false;
        }else{
            CharactersSpawner.instance.pooledEntities.Remove(gameObject);
            CharactersSpawner.instance.players.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    #region PM
    //Post mortem spells

    void OnDivineLight(){
        if(!alive && divineLight){
            dlInstance = Instantiate(CharactersSpawner.instance.divineLight, CharactersSpawner.instance.divineLight.transform.localPosition, CharactersSpawner.instance.divineLight.transform.rotation);
            //divineLight = false;
        }
    }






    #endregion
}
