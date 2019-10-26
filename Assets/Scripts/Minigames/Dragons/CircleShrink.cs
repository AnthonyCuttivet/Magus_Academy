using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShrink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        float speed = gameObject.GetComponentInParent<CircleSystem>().speed;
        if(gameObject.transform.localScale.x > 0){
            gameObject.GetComponentInParent<CircleSystem>().circleScaleX = gameObject.transform.localScale.x;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - speed, gameObject.transform.localScale.y - speed, gameObject.transform.localScale.z);
        }else{
            gameObject.GetComponentInParent<CircleSystem>().circleScaleX = -1;
            Destroy(gameObject);
        }
    }
}
