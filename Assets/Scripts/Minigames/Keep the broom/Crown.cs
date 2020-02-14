using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Crown : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(-90,0,180),1).SetEase(Ease.Linear).SetLoops(-1,LoopType.Incremental);
    }
}
