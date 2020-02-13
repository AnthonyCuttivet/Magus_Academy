using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartFlash : MonoBehaviour
{

    public float fadeDuration;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().DOFade(1, fadeDuration).SetLoops(-1,LoopType.Yoyo);
    }
}
