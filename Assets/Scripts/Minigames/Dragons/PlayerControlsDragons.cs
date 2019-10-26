using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsDragons : MonoBehaviour
{

    public GameObject circleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(circleSystem.GetComponent<CircleSystem>().circleScaleX);
    }

    void OnAction(){
        float circleScaleX = circleSystem.GetComponent<CircleSystem>().circleScaleX;
        float precision = circleSystem.GetComponent<CircleSystem>().precision;
        if((circleScaleX > (1 + precision) && circleScaleX < 1.3f) || (circleScaleX < (1 - precision) && circleScaleX > .765f)){
            Debug.Log("Good " + circleScaleX);
        }else if(circleScaleX < (1 + precision) && circleScaleX > (1 - precision)){
            Debug.Log("Excellent " + circleScaleX);
        }
        Destroy(circleSystem.GetComponentInChildren<CircleShrink>().gameObject);
    }
}
