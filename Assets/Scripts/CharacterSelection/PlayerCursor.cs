using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{

    private RaycastHit hit;
    public int currentSelection = -1;
    public bool hasSelected = false;
    public bool playerCreated = false;
    public Player currentPlayer;

    void OnEnable(){
        gameObject.GetComponent<PlayerInput>().actions.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(Physics.Raycast(transform.position, new Vector3(0,0,1), out hit, 10f)){
            currentSelection = int.Parse(hit.transform.gameObject.name);
        }else{
            currentSelection = -1;
        }
    }

    void OnMove(InputValue value){
        if(!playerCreated){
            playerCreated = true;
            currentPlayer = PlayersManager.instance.CreatePlayer();
        }
        if(!hasSelected){
            Vector3 v3Value = new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y, 0);
            gameObject.transform.Translate(v3Value);
        }
    }

    void OnValidate(){
        if(currentSelection != -1 && !hasSelected){
            hasSelected = true;
            PlayersManager.instance.AddSkin(currentPlayer, currentSelection);
        }
    }

    void OnCancel(){
        if(hasSelected){
            hasSelected = false;
            PlayersManager.instance.RemoveSkin(currentPlayer);
        }
    }


}
