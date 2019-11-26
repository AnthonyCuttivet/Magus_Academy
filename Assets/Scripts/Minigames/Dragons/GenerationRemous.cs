using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationRemous : MonoBehaviour
{
    BoxCollider generationArea;
    public GameObject smoke;
    public GameObject fish;
    public float spawnHeight = 4.1f;
    public float spawnRange;
    float maxAttemps = 10;
    public LayerMask layerMask;
    public List<Collider> fishesColliders = new List<Collider>();

    public static GenerationRemous instance;
    
    void Awake(){
        generationArea = GetComponent<BoxCollider>();
        InvokeRepeating("SpawnFish",0,.3f);
        instance = this;
    }

    void SpawnFish(){
        Vector3 randomSpawnPosition = GeneratePosition();
        if(randomSpawnPosition != Vector3.zero){
            GameObject fishGO = Instantiate(fish,randomSpawnPosition,transform.rotation);
            fishesColliders.Add(fishGO.GetComponent<Collider>());
        }
    }

    Vector3 GeneratePosition(){
        int attemps = 0;
        while(attemps < maxAttemps){
            Vector3 position = new Vector3 (Random.Range(generationArea.bounds.min.x, generationArea.bounds.max.x),spawnHeight,Random.Range(generationArea.bounds.min.z, generationArea.bounds.max.z));
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
