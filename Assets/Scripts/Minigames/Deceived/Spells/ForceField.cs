using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public float lifeTime = 3f;
    private List<GameObject> invisibleObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        Destroy(gameObject, lifeTime);
    }

    void OnDestroy(){
        foreach (GameObject g in invisibleObjects)
        {
            g.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Character"){
            collider.GetComponent<MeshRenderer>().enabled = false;
            invisibleObjects.Add(collider.gameObject);
        }
    }

    void OnTriggerExit(Collider collider){
        if(collider.tag == "Character"){
            collider.GetComponent<MeshRenderer>().enabled = true;
            invisibleObjects.Remove(collider.gameObject);
        }
    }
}
