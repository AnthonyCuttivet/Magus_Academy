using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharactersSpawner : MonoBehaviour
{

    [Space]
    [Header("Players")]
    public GameObject entity;

    [Range(4,100)]
    public int amountOfEntities = 4;
    public Material player;
    public Material[] materials;

    private List<GameObject> pooledEntities;
    private List<GameObject> players;

    private Dictionary<string,int> colorRepartition = new Dictionary<string,int>();

    private bool m_HitDetect;
    private RaycastHit m_Hit;
    
    [Space]
    [Header("Settings")]
    public float m_MaxDistance = 1f;
    public InputActionAsset actions;

    void Awake(){
        
    }

    // Start is called before the first frame update
    void Start(){
        PoolEntities(entity, amountOfEntities);
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void PoolEntities(GameObject entity, int amount){
        pooledEntities = new List<GameObject>();
        for (int i = 1; i <= amount; i++) {
            bool spawned = false;
            while(spawned != true){
                GameObject obj = (GameObject)Instantiate(entity, new Vector3(Random.Range(-30f,30f), 1, Random.Range(-15f,15f)), Quaternion.identity);
                Collider[] hitColliders = Physics.OverlapSphere(obj.transform.position, m_MaxDistance);
                if(hitColliders.Length <= 1){
                    spawned = true;
                    obj.name = i.ToString();        
                    obj.transform.parent = GameObject.Find("Characters").transform;
                    SetSkin(obj, i);
                    //obj.SetActive(false); 
                    pooledEntities.Add(obj);
                }else{
                    Destroy(obj);
                }
            
            }
        }
        SetPlayers();
    }

/*     public void setSkin(GameObject obj){
        Material randomMat = materials[Random.Range(0, materials.Length)];
        if(colorRepartition.ContainsKey(randomMat.name)){
            colorRepartition[randomMat.name] += 1;
        }else{
            colorRepartition[randomMat.name] = 0;
        }
        obj.GetComponent<Renderer>().material = randomMat;
    } */

    public void SetSkin(GameObject obj, int index){
        if(index <= (0.25f * amountOfEntities)){
            obj.GetComponent<Renderer>().material = materials[0];
        }else if(index <= (0.5f * amountOfEntities)){
            obj.GetComponent<Renderer>().material = materials[1];
        }
        else if(index <= (0.75f * amountOfEntities)){
            obj.GetComponent<Renderer>().material = materials[2];
        }
        else{
            obj.GetComponent<Renderer>().material = materials[3];
        }
    }

    public void SetPlayers(){
        actions.Enable();
        List<float> ids = new List<float>{0.25f*amountOfEntities,0.5f*amountOfEntities,0.75f*amountOfEntities,amountOfEntities};
        foreach (float i in ids){
            pooledEntities[(int)i-1].GetComponent<Renderer>().material = player;
            PlayerInput p = pooledEntities[(int)i-1].AddComponent<PlayerInput>();
            p.actions = actions;
            PlayerControls pc = pooledEntities[(int)i-1].AddComponent<PlayerControls>();
            pooledEntities[(int)i-1].name = "Player";
        }
    }

    /*public void SetPlayersRandomly(){
        List<int> ids = GenerateUniqueRandoms(4,1,100);
        foreach (int i in ids){
            pooledEntities[i].GetComponent<Renderer>().material = player;
            pooledEntities[i].name = "Player";
        }
    } */

    public List<int> GenerateUniqueRandoms(int amount, int min, int max){
        List<int> numbers = new List<int>();

        for(int i = 0; i < amount; i++){
            int numToAdd = Random.Range(min,max);
            while(numbers.Contains(numToAdd)){
                numToAdd = Random.Range(min,max);
            }
            numbers.Add(numToAdd);
        }

        return numbers;
    }

    public void SpawnEntities(GameObject entity, int amount){

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
        }
    }
}
