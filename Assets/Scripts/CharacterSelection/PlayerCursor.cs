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
        if(currentSelection != -1  && !hasSelected){
            if(currentSelection != 0){
                hasSelected = true;
                PlayersManager.instance.AddSkin(currentPlayer, currentSelection);
            }else if(currentSelection == 0){
                //Random skin
                hasSelected = true;
                PlayersManager.instance.AddSkin(currentPlayer, currentSelection);
                CharacterSelectionManager.instance.selectedCount++;
                CharacterSelectionManager.instance.characters[currentPlayer.Id].SetActive(true);
            }else if(CharacterSelectionManager.instance.selectedSkins.Contains(currentSelection)){
                //Skin already selected
            }
        }
    }

    void OnCancel(){
        if(hasSelected){
            hasSelected = false;
            PlayersManager.instance.RemoveSkin(currentPlayer);
            CharacterSelectionManager.instance.selectedSkins.Remove(currentSelection);
            CharacterSelectionManager.instance.selectedCount--;
            CharacterSelectionManager.instance.characters[currentPlayer.Id].SetActive(false);
        }
    }


}
