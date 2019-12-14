using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{

    private RaycastHit2D hit;
    public int currentSelection = -1;
    public bool hasSelected = false;
    public bool playerCreated = false;
    public Player currentPlayer;
    public GameObject PlayersManagerGO;

    void OnEnable(){
        gameObject.GetComponent<PlayerInput>().actions.Enable();
        PlayersManagerGO = GameObject.Find("PlayersManager/PlayersGO");
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!playerCreated){
            playerCreated = true;
            currentPlayer = PlayersManager.instance.CreatePlayer();
            Color fullColor = CharacterSelectionManager.instance.cursors[currentPlayer.Id];
            gameObject.GetComponent<SpriteRenderer>().color = new Color(fullColor.r, fullColor.g, fullColor.b);
            gameObject.name = "PlayerGO" + currentPlayer.Id;
            gameObject.transform.parent = PlayersManagerGO.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        hit = Physics2D.Raycast(transform.position, forward, 10f);
        if(hit.collider != null){
            currentSelection = hit.collider.transform.gameObject.GetComponent<CharacterAttribute>().attributeID;
        }else{
            currentSelection = -1;
        }
    }

    void OnMove(InputValue value){
        if(!hasSelected){
            Vector3 v3Value = new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y, 0);
            gameObject.transform.Translate(v3Value);
        }
    }

    void OnValidate(){
        if(currentSelection != -1  && !hasSelected){
            if(CharacterSelectionManager.instance.selectedSkins.Contains(currentSelection)){
                //Skin already selected
            }else{
                hasSelected = true;
                PlayersManager.instance.AddSkin(currentPlayer, currentSelection);
            }
        }
    }

    void OnCancel(){
        if(hasSelected){
            hasSelected = false;
            PlayersManager.instance.RemoveSkin(currentPlayer);
        }
    }


}
