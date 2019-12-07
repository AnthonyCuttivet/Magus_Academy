using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public float lifeTime = 3f;
    public Vector3 finalSize = Vector3.one * 10;
    private List<GameObject> invisibleObjects = new List<GameObject>();

    IEnumerator Start()
    {
        while(Vector3.Distance(transform.localScale, finalSize) >= 1){
            transform.localScale += Vector3.one;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
    }

    void Update(){
        Destroy(gameObject, lifeTime);
    }

    void OnDestroy(){
        foreach (GameObject g in invisibleObjects){
            foreach(Transform t in g.transform.Find("Parts")){
                if(t.name != "Chibi_Character"){
                    t.GetComponent<SkinnedMeshRenderer>().enabled = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Character"){
            foreach(Transform g in collider.transform.Find("Parts")){
                if(g.name != "Chibi_Character"){
                    g.GetComponent<SkinnedMeshRenderer>().enabled = false;
                }
            }
            invisibleObjects.Add(collider.gameObject);
        }
    }

    void OnTriggerExit(Collider collider){
        if(collider.tag == "Character"){
            foreach(Transform g in collider.transform.Find("Parts")){
                if(g.name != "Chibi_Character"){
                    g.GetComponent<SkinnedMeshRenderer>().enabled = true;
                }
            }
            invisibleObjects.Remove(collider.gameObject);
        }
    }
}
