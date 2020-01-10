using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    Collider2D collid;
    Rigidbody2D rb;
    [Space]
    [Header("Booleans")]
    public bool onGround;
    public bool underRoof;
    public bool onWall, onRightWall, onLeftWall;
    [HideInInspector]
    public bool passingTroughPlatform;

    [Space]
    [Header("Offsets")]
    
    public Vector2 topOffset;
    public Vector2 bottomOffset;
    public Vector2 rightOffset;
    public Vector2 leftOffset;
    public Vector2 bodyOffset;

    [Space]
    [Header("Boxes")]
    public Vector2 groundBox;
    public Vector2 roofBox;
    public Vector2 sideBox;
    Vector2 bodySize;

    [Space]
    [Header("Mask")]
    public LayerMask groundMask;    
   
    
    float jumpVelocityFrame;

    //Colliders lists
    [HideInInspector]
    public List<Collider2D> ignoredColliders = new List<Collider2D>();
    [HideInInspector]
    public List<Collider2D> bodyColliders = new List<Collider2D>();
    [HideInInspector]
    public List<Collider2D> roofColliders,groundColliders;
    
    void Start()
    {
        collid = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        jumpVelocityFrame = 28 * Time.deltaTime * 2;
        bodySize = collid.bounds.size * new Vector2(.8f,.9f);
        
    }

    void RoofCheck(){
        underRoof = Physics2D.OverlapBox((Vector2) transform.position + topOffset,roofBox  + ((Vector2.up) * jumpVelocityFrame),0,groundMask); 
        roofColliders = new List<Collider2D>(Physics2D.OverlapBoxAll((Vector2) transform.position + topOffset,roofBox  + ((Vector2.up) * jumpVelocityFrame),0,groundMask));
    }
    void GroundCheck(){
        onGround = Physics2D.OverlapBox((Vector2) transform.position + bottomOffset,groundBox,0,groundMask); 
        groundColliders = new List<Collider2D>(Physics2D.OverlapBoxAll((Vector2) transform.position + bottomOffset,groundBox,0,groundMask)); 
    }
    void WallCheck(){
        onRightWall = Physics2D.OverlapBox((Vector2) transform.position + rightOffset,sideBox,0,groundMask);
        onLeftWall = Physics2D.OverlapBox((Vector2) transform.position + leftOffset,sideBox,0,groundMask);  
        onWall = (onRightWall || onLeftWall) ? true : false;
    }
    
    void PassingTroughPlatformCheck(){
        passingTroughPlatform = Physics2D.OverlapBox((Vector2) transform.position + bodyOffset,bodySize,0,groundMask);
        bodyColliders = new List<Collider2D>(Physics2D.OverlapBoxAll((Vector2) transform.position + bodyOffset,bodySize,0,groundMask));
    }

    public void CheckCollisions(){
        GroundCheck();
        WallCheck();
        RoofCheck();
        PassingTroughPlatformCheck();
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube((Vector2) transform.position + topOffset, groundBox  + ((Vector2.up) * jumpVelocityFrame * 2));
        Gizmos.DrawCube((Vector2) transform.position + bottomOffset, groundBox);
        Gizmos.color = Color.blue;
        Gizmos.DrawCube((Vector2) transform.position + rightOffset, sideBox);
        Gizmos.DrawCube((Vector2) transform.position + leftOffset, sideBox);
        Gizmos.color = Color.green;
        Gizmos.DrawCube((Vector2) transform.position + bodyOffset, bodySize);
    }
    
}
