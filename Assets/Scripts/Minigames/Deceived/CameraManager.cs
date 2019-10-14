using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public MeshRenderer arena;
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = arena.bounds.size.x / arena.bounds.size.y;

        if(screenRatio >= targetRatio){
            Camera.main.orthographicSize = arena.bounds.size.y / 2;
        }
        else{
            float differenceSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = arena.bounds.size.y / 2 * differenceSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
