using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingRodRenderer : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform aim;
    public Transform anchorPoint;
    DragonQTE_PlayerControls QTEController;

    void Awake(){
        lineRenderer = GetComponent<LineRenderer>();
        QTEController = GetComponentInParent<DragonQTE_PlayerControls>();
    }
    void Update(){
        if(QTEController.inQTE){
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0,anchorPoint.position);
            lineRenderer.SetPosition(1,aim.position);
        }
        else{
            lineRenderer.enabled = false;
        }
        
        
    }
}
