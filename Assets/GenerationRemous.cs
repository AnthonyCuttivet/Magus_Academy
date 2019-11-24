using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationRemous : MonoBehaviour
{
    BoxCollider generationArea;
    public GameObject smoke;
    public GameObject fish;
    public float spawnHeight = 4.1f;
    
    void Awake(){
        generationArea = GetComponent<BoxCollider>();
        InvokeRepeating("SpawnFish",0,5);
    }

    void SpawnFish(){
        Vector2 bounds = new Vector2(generationArea.bounds.size.x,generationArea.bounds.size.z);
        Vector3 randomSpawnPosition = new Vector3 (Random.Range(generationArea.bounds.min.x, generationArea.bounds.max.x),spawnHeight,Random.Range(generationArea.bounds.min.z, generationArea.bounds.max.z));
        Instantiate(smoke,randomSpawnPosition,transform.rotation);
        GameObject fishGO = Instantiate(fish,randomSpawnPosition,transform.rotation);
    }
}
