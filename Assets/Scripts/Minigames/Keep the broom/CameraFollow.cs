using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public KTB_Player player;
    public Vector3 cameraOffset; 
    public Vector2 boxSize;
    Vector3 boxPos;
    public float smoothTime;

    void Start(){
        
        boxPos = player.collid.bounds.center;
        boxPos.z = cameraOffset.z;
        transform.position = boxPos;
    }

    void FixedUpdate(){
        if(player.transform.position.x - boxPos.x > boxSize.x / 2){     //Left 
            boxPos.x = player.transform.position.x - boxSize.x / 2;
        }
        else if(player.transform.position.x - boxPos.x < -(boxSize.x / 2)){     //Right
            boxPos.x = player.transform.position.x + boxSize.x / 2;
        }

        if(player.transform.position.y - boxPos.y > boxSize.y / 2){     //Top
            boxPos.y = player.transform.position.y - boxSize.y / 2;
        }
        else if(player.transform.position.y - boxPos.y < -(boxSize.y / 2)){     //Bottom
            boxPos.y = player.transform.position.y + boxSize.y / 2;
        }
        boxPos = Vector3.Lerp(transform.position,boxPos, smoothTime * Time.fixedDeltaTime);     //Smoothing
        transform.position = boxPos;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,.7f,.4f,.3f);
        Gizmos.DrawCube(boxPos, boxSize);
    }
}
