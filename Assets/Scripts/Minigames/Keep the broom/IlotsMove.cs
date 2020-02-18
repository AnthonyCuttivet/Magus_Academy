using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class IlotsMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform){
            foreach(Transform grandChild in child){
                float randomX =  Random.Range(-.5f,.5f);
                grandChild.DOMoveY(grandChild.position.y + (randomX + Mathf.Sign(randomX) * 1) / (grandChild.position.z / 40),Random.Range(5f,10f)).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
            }
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
