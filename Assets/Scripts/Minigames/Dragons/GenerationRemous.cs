using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationRemous : MonoBehaviour
{
    BoxCollider generationArea;
    public GameObject fish;
    public float spawnSpeed = .3f;
    public float spawnHeight = 4.1f;
    public float spawnRange;
    float maxAttemps = 10;
    public LayerMask layerMask;
    public List<Collider> fishesColliders = new List<Collider>();

    [Space]
    [Header("Golden Dragon")]
    public float goldenDragonChance = .1f;
    public Material goldenDragonMaterial;

    public static GenerationRemous instance;
    
    void Awake(){
        generationArea = GetComponent<BoxCollider>();
        InvokeRepeating("SpawnFish",0,spawnSpeed);
        instance = this;
    }

    bool IsGolden(){
        bool isGolden = false;

        if(Random.value <= goldenDragonChance){
            isGolden = true;
        }

        return isGolden;
    }

    void SpawnFish(){

        bool isGolden = IsGolden();

        int dragonDirection = 0;
        if(Random.value <= .5f){
            dragonDirection = 1;
        }else{
            dragonDirection = -1;
        }

        Vector3 randomSpawnPosition = GeneratePosition(59*dragonDirection);
        if(randomSpawnPosition != Vector3.zero){
            GameObject fishGO = Instantiate(fish,randomSpawnPosition,new Quaternion(0,0,0,0));

            //if Golden Dragon
            if(isGolden){
                fishGO.GetComponent<Dragon>().pointsMultiplier = 2;
                foreach(Transform t in fishGO.transform){
                    if(t.name != "Dragon_Pete_3"){
                        t.GetComponent<SkinnedMeshRenderer>().material = goldenDragonMaterial;
                    }
                }
            }


            fishGO.transform.Rotate(new Vector3(0,-90*dragonDirection,0));
            fishGO.GetComponent<DragonMovement>().direction = -dragonDirection;
            fishesColliders.Add(fishGO.GetComponent<Collider>());
        }
    }

    Vector3 GeneratePosition(int x){
        int attemps = 0;
        while(attemps < maxAttemps){
            Vector3 position = new Vector3 (x,spawnHeight,Random.Range(generationArea.bounds.min.z, generationArea.bounds.max.z));
        Collider[] hitColliders = Physics.OverlapSphere(position, spawnRange,layerMask);
        if(hitColliders.Length == 0){
            return position;
        }
        else{
            attemps++;
        }
        }
        return Vector3.zero;
    }
}
