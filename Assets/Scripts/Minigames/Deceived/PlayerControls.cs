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

    public override void Awake(){
        base.Awake();
        attackCollider = GetComponentInChildren<Collider>();
        shotSpawnPoint = transform.Find("ShotSpawn").GetComponent<Transform>();
        walkingSpeed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterWalkingSpeed;
        runningSpeed = GameObject.Find("GameManager").GetComponent<PlayersSettings>().characterRunningSpeed;
        pa = new PlayerActions();

/*      pa.Deceived.Walk.performed += ctx => isWalking = true;
        pa.Deceived.Run.performed += ctx => isRunning = true;

        pa.Deceived.Walk.canceled += ctx => isWalking = false;
        pa.Deceived.Run.canceled += ctx => isRunning = false; */
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
        if(value.Get<Vector2>() != Vector2.zero){
            gameObject.transform.rotation = Quaternion.Euler(0,GetAngle(i_movement),0);
        }
        i_movement = value.Get<Vector2>();
        Debug.DrawRay(gameObject.transform.position,gameObject.transform.forward, Color.red, .5f);    
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
        Collider[] gameObjectToDestroy = targets.ToArray();
        foreach(Collider collider in gameObjectToDestroy){
            targets.Remove(collider);
            Destroy(collider.gameObject);
            CharactersSpawner.instance.PNJList.RemoveAll(x=>x.name==collider.gameObject.name);
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
        Instantiate(CharactersSpawner.instance.shot,shotSpawnPoint.position,shotSpawnPoint.rotation);
    }

    public override void Kill(){
        CharactersSpawner.instance.pooledEntities.Remove(gameObject);
        CharactersSpawner.instance.players.Remove(gameObject);
        Destroy(gameObject);
    }
}
