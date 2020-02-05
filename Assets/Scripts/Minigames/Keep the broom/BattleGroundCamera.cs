using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGroundCamera : MonoBehaviour
{
    public GameObject[] players;
    Camera cam;
    public float boxPadding;
    public float smoothTime;
    public float minSize,maxSize;
    public float verticalOffset;
    void Start()
    {
        //players = GameObject.FindGameObjectsWithTag("Player");
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 minPos = Vector2.positiveInfinity;
        Vector2 maxPos = Vector2.negativeInfinity;
        
        foreach(GameObject player in players){
            if(!player.GetComponent<KTB_Player>().dead){
                minPos = Vector2.Min(minPos,player.transform.position);
                maxPos = Vector2.Max(maxPos,player.transform.position);
            }
        }
        Rect box = Rect.MinMaxRect(minPos.x - boxPadding,maxPos.y + boxPadding,maxPos.x + boxPadding,minPos.y - boxPadding - verticalOffset);  
        float cameraSize = Camera.main.orthographicSize;
        Vector3 topRight = new Vector3(box.x +  box.width,box.y,0f);
        Vector3 topRightAsViewport = cam.WorldToViewportPoint(topRight);

        if (topRightAsViewport.x >= topRightAsViewport.y)
            cameraSize = Mathf.Abs(box.width) / cam.aspect / 2f;
        else{
            cameraSize = Mathf.Abs(box.height) / 2f;
        }
        Vector3 newCameraPos = new Vector3(box.center.x,box.center.y,transform.position.z);
        transform.position = newCameraPos;
        cam.orthographicSize = Mathf.Clamp(Mathf.Lerp(cam.orthographicSize, cameraSize, Time.deltaTime * smoothTime), minSize, maxSize);
    }
}
