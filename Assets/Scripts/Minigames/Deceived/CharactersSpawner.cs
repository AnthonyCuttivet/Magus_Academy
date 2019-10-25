using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using System.Linq;

public class CharactersSpawner : MonoBehaviour
{

    public static CharactersSpawner instance;

    [Space]
    [Header("Players")]
    public GameObject entity;

    [Range(4,100)]
    public int amountOfEntities = 4;
    public Material player;
    public Material[] materials;

    public List<GameObject> pooledEntities;
    public List<GameObject> players;
    public List<GameObject> PNJList = new List<GameObject>();

    private Dictionary<string,int> colorRepartition = new Dictionary<string,int>();

    public bool gameStart = false; //Check if the minigame has started

    private bool m_HitDetect;
    private RaycastHit m_Hit;

    [Space]
    [Header("Prefabs")]
    public GameObject shot;
    public GameObject forceField;
    public GameObject divineLight;
    
    [Space]
    [Header("Settings")]
    public float m_MaxDistance = 1f;
    public InputActionAsset actions;
    LayerMask layerMask = (1 <<8);      //only the layer 8
    public List<Material> skinToUse = new List<Material>();
    public List<Player> playersInfos = PlayersManager.instance.playersList;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
    }

    void OnEnable(){
        actions.Enable();
    }

    void Start(){
        foreach(Player player in playersInfos){
            skinToUse.Add(DeceivedManager.instance.skins[player.Skin]);
        }
        PoolEntities(entity, amountOfEntities);
    }

    public void PoolEntities(GameObject entity, int amount){
        pooledEntities = new List<GameObject>();
        for (int i = 1; i <= amount; i++) {
            bool spawned = false;
            while(spawned != true){
                GameObject obj = (GameObject)Instantiate(entity, new Vector3(Random.Range(-30f,30f), 1, Random.Range(-15f,15f)), Quaternion.identity);
                Collider[] hitColliders = Physics.OverlapSphere(obj.transform.position, m_MaxDistance,layerMask);
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
        GeneratePNJList();
        ActivatePNJ(PNJList);
    }

    public void GeneratePNJList(){
        pooledEntities.RemoveAll(x=>x.name.Contains("Player")); // remove the players from the list
        foreach (GameObject g in pooledEntities){
            PNJList.Add(g);
        }
    }

    public void SetSkin(GameObject obj, int index){
        if(index <= (0.25f * amountOfEntities)){
            obj.GetComponent<Renderer>().material = skinToUse[0];
        }else if(index <= (0.5f * amountOfEntities)){
            obj.GetComponent<Renderer>().material = skinToUse[1];
        }
        else if(index <= (0.75f * amountOfEntities)){
            obj.GetComponent<Renderer>().material = skinToUse[2];
        }
        else{
            obj.GetComponent<Renderer>().material = skinToUse[3];
        }
    }

    public void SetPlayers(){
        List<float> ids = new List<float>{0.25f*amountOfEntities,0.5f*amountOfEntities,0.75f*amountOfEntities,amountOfEntities};
        int j = 1;
        foreach (float i in ids){
            //pooledEntities[(int)i-1].GetComponent<Renderer>().material = player;
            pooledEntities[(int)i-1].name = "Player" + j;
            j++;
            players.Add(pooledEntities[(int)i-1]);
        }
        InstantiatePlayersControls(ids);
        
    }
    void ActivatePNJ(List<GameObject> pnjList){
        foreach(GameObject pnj in pnjList){
            pnj.AddComponent<NavMeshAgent>();
            PNJControls pnj_Controls = pnj.AddComponent<PNJControls>();
        }
    }


    public void InstantiatePlayersControls(List<float> ids){
        foreach (var i in ids){
            PlayerInput p = pooledEntities[(int)i-1].AddComponent<PlayerInput>();
            p.actions = Instantiate(actions);
            p.defaultActionMap = "Deceived";
            PlayerControls pc = pooledEntities[(int)i-1].AddComponent<PlayerControls>();
            p.actions.Enable();
        }
    }

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
}
