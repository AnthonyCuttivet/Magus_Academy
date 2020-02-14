using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ForceField : MonoBehaviour
{
    public float lifeTime = 5f;
    public Vector3 finalSize = Vector3.one * 10;
    private List<GameObject> invisibleObjects = new List<GameObject>();
    bool degrowStarted;

    IEnumerator Start()
    {
        
        while(Vector3.Distance(AbsVector3(transform.localScale), finalSize) >= 1f){
            transform.DOScale(finalSize,1.2f).SetEase(Ease.OutCirc);
            yield return null;
        }
        
    }

    void Update(){
        lifeTime-= Time.deltaTime;
        if(lifeTime <= 0 && !degrowStarted){
            StartCoroutine(Degrow());
        }
        
    }
    IEnumerator Degrow(){
        degrowStarted = true;  
        while(Vector3.Distance(transform.localScale, Vector3.zero) >= .1f){
            transform.DOScale(Vector3.zero,1.2f).SetEase(Ease.OutCirc);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Destroy(gameObject);
    }

    void OnDestroy(){
        foreach (GameObject g in invisibleObjects){
            if(g.GetComponent<PlayerControls>().alive == true){
                foreach(Transform t in g.transform.Find("Parts")){
                    if(t.name != "Chibi_Character"){
                        t.GetComponent<SkinnedMeshRenderer>().enabled = true;
                    }
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
    Vector3 AbsVector3(Vector3 vecteur){
        return new Vector3(Mathf.Abs(vecteur.x),Mathf.Abs(vecteur.y),Mathf.Abs(vecteur.z));
    }
}
