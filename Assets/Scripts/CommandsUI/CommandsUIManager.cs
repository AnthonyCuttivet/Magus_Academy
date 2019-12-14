using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CommandsUIManager : MonoBehaviour
{

    public static CommandsUIManager instance;
    public InputActionAsset actions;
    public bool inUI = true;

    public GameObject PlayersManagerGO;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
    }

    void OnEnable(){
        actions.Enable();
    }

    void Start(){
        PlayersManagerGO = GameObject.Find("PlayersManager/PlayersGO");
        foreach(Transform player in PlayersManagerGO.transform){
            PlayerInput p = player.GetComponent<PlayerInput>();
            p.actions = Instantiate(actions);
            p.actions.Enable();
            player.gameObject.AddComponent<PlayerCUI>();
            Destroy(player.GetComponent<PlayerCursor>());
            Destroy(player.GetComponent<SpriteRenderer>());
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
