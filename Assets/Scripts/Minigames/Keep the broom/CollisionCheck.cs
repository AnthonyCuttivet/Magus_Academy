using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public Collider2D collid;
    public Transform spineTransform;
    public Transform RfootTransform,LfootTransform,topHeadTransform;

    Rigidbody2D rb;
    [Space]
    [Header("Booleans")]
    public bool onGround;
    public bool underRoof;
    public bool onWall, onRightWall, onLeftWall;
    
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
    //[HideInInspector]
    public List<Collider2D> ignoredColliders = new List<Collider2D>();
    //[HideInInspector]
    public List<Collider2D> bodyColliders = new List<Collider2D>();
    //[HideInInspector]
    public List<Collider2D> roofColliders = new List<Collider2D>();
    public List<Collider2D> groundColliders = new List<Collider2D>();
    public KTB_Player player;

    void Start()
    {
        //collid = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        jumpVelocityFrame = 28 * Time.deltaTime * 1.5f;
        bodySize = collid.bounds.size * new Vector2(.8f,.9f);
        
    }

    void RoofCheck(){
        bodySize = new Vector2(bodySize.x,topHeadTransform.position.y - Mathf.Min(RfootTransform.position.y,LfootTransform.position.y)); 
        bodySize.y *= .95f;
        Vector2 _bodyOffset = bodySize;
        _bodyOffset.x = 0;
        Vector2 spineOffset = new Vector2(0,transform.position.y - spineTransform.position.y + 2.2f);
        underRoof = Physics2D.OverlapBox((Vector2)  spineTransform.position + _bodyOffset / 2 + topOffset,roofBox  + ((Vector2.up) * jumpVelocityFrame),0,groundMask); 
        roofColliders = new List<Collider2D>(Physics2D.OverlapBoxAll((Vector2) spineTransform.position + _bodyOffset / 2 + topOffset,roofBox  + ((Vector2.up) * jumpVelocityFrame),0,groundMask));
    }
    void GroundCheck(){
        bodySize = new Vector2(bodySize.x,topHeadTransform.position.y - Mathf.Min(RfootTransform.position.y,LfootTransform.position.y)); 
        bodySize.y *= .9f;
        Vector2 _bodyOffset = bodySize;
        _bodyOffset.x = 0;
        Vector2 spineOffset = new Vector2(0,transform.position.y - spineTransform.position.y + 2.2f);
        onGround = Physics2D.OverlapBox((Vector2) spineTransform.position - _bodyOffset / 2 + bottomOffset,groundBox,0,groundMask); 
        groundColliders = new List<Collider2D>(Physics2D.OverlapBoxAll((Vector2) spineTransform.position - _bodyOffset / 2 + bottomOffset,groundBox,0,groundMask)); 
    }
    void WallCheck(){
        Vector2 spineOffset = new Vector2(0,transform.position.y - spineTransform.position.y + 2.2f);
        onRightWall = Physics2D.OverlapBox(((Vector2) spineTransform.position + rightOffset ),sideBox,0,groundMask);
        onLeftWall = Physics2D.OverlapBox(((Vector2) spineTransform.position + leftOffset),sideBox,0,groundMask);  
        onWall = (onRightWall || onLeftWall) ? true : false;
    }
    
    void PassingTroughPlatformCheck(){
        bodySize = new Vector2(bodySize.x,topHeadTransform.position.y - Mathf.Min(RfootTransform.position.y,LfootTransform.position.y)); 
        bodySize.y *= .9f;
        Vector2 spineOffset = new Vector2(transform.position.x,spineTransform.position.y);
        passingTroughPlatform = Physics2D.OverlapBox((Vector2) spineOffset + bodyOffset,bodySize,0,groundMask);
        bodyColliders = new List<Collider2D>(Physics2D.OverlapBoxAll((Vector2) spineOffset + bodyOffset,bodySize,0,groundMask));
    }

    public void CheckCollisions(){
        RoofCheck();
        PassingTroughPlatformCheck();
        GroundCheck();  
        WallCheck();
        
    }
    
    void OnDrawGizmos()
    {
        bodySize = new Vector2(bodySize.x,topHeadTransform.position.y - Mathf.Min(RfootTransform.position.y,LfootTransform.position.y)); 
        bodySize.y *= .95f;
        Vector2 spineOffset = new Vector2(transform.position.x,spineTransform.position.y);
        Vector2 _bodyOffset = bodySize;
        _bodyOffset.x = 0;
        Gizmos.color = Color.red;
        Gizmos.DrawCube((Vector2) spineTransform.position + _bodyOffset / 2 + topOffset, groundBox  + ((Vector2.up) * jumpVelocityFrame));
        Gizmos.DrawCube((Vector2) spineTransform.position - _bodyOffset / 2 + bottomOffset, groundBox);
        Gizmos.color = Color.blue;
        sideBox.y = bodySize.y * .7f;
        Gizmos.DrawCube((Vector2) spineTransform.position + rightOffset, sideBox);
        Gizmos.DrawCube((Vector2) spineTransform.position + leftOffset, sideBox);
        Gizmos.color = Color.green;
        Gizmos.DrawCube((Vector2) spineOffset + bodyOffset, bodySize);
    }
    
}
