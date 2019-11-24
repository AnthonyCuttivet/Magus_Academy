using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Blink : MonoBehaviour
{

    private Renderer rdr;
    public float blinkSpeed = 2f;

    void Start(){
        BlinkOn();
    }

    void BlinkOn(){
        rdr = gameObject.GetComponent<SpriteRenderer>();
        rdr.material.DOFade(0f, blinkSpeed).SetLoops(-1, LoopType.Yoyo);
    }
    
    void BlinkOff(){
        DOTween.Kill(rdr.material);
    }

    void OnEnable(){
        BlinkOn();
    }

    void OnDisable(){
        BlinkOff();
        Color tmp = rdr.material.color;
        tmp.a = 1f;
        rdr.material.color = tmp;
    }

}

