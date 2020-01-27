using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxeLayer : MonoBehaviour
{

    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        gameObject.transform.Translate(Vector3.right  * speed * Time.deltaTime);
        if(gameObject.GetComponent<RectTransform>().position.x > 100){
            Vector3 newPos = new Vector3(-100,gameObject.GetComponent<RectTransform>().position.y,gameObject.GetComponent<RectTransform>().position.z);
            gameObject.transform.position = newPos;
        }
    }
}
