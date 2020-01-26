using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CountdownNumber : MonoBehaviour
{

    public float timeToFade = 1f;

    void Start(){
        StartCoroutine(DeactivateAfterSeconds(timeToFade));
    }

    IEnumerator DeactivateAfterSeconds(float seconds){
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
