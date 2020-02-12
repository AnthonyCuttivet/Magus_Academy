using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowBehavior : MonoBehaviour
{

    public float offset;
    public float duration;

    // Start is called before the first frame update
    void Start(){
        gameObject.transform.DOLocalMoveX(gameObject.transform.localPosition.x - offset, duration).SetEase(Ease.InOutQuad).SetLoops(-1,LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
