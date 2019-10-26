using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSystem : MonoBehaviour
{

    public GameObject circle;
    [Range(0.01f,1)]
    public float speed;
    [Range(0.01f,1)]
    public float precision;
    public int points = 0;
    public int multiplicator = 1;
    public int goodPoints = 1;
    public int excellentPoints = 2;
    public float circleScaleX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

    }
}
