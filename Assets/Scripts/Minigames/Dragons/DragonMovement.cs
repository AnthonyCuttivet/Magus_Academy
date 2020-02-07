using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public float speed = 10;
    public int direction; //1-> Left to right -1-> Right to left

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(gameObject.GetComponent<Dragon>().fished == false){
            gameObject.transform.Translate(new Vector3(direction,0,0) * speed * Time.deltaTime, Space.World);
        }

        if(Mathf.Abs(gameObject.transform.position.x) > 60){
            Destroy(gameObject);
        }
    }
}
