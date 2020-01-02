using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCUI : MonoBehaviour
{

    public bool ready = false;
    public int id;

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

    void OnReady(){
        if(!ready){
            ToggleReady();
            CommandsUIManager.instance.readyCount++;
        }
    }

    void OnCancel(){
        if(ready){
            ToggleReady();
            CommandsUIManager.instance.readyCount--;
        }
    }

    void OnStart(){
        if(CommandsUIManager.instance.readyCount == 4){
            CommandsUIManager.instance.start = true;
        }
    }

    void OnSelect(){
        CommandsUIManager.instance.start = true;
    }

    void ToggleReady(){
        ready = !ready;
        GameObject playersIcons = CommandsUIManager.instance.playerIcons;
        if(ready){
            playersIcons.transform.GetChild(id).GetChild(0).gameObject.SetActive(true);
        }else{
            playersIcons.transform.GetChild(id).GetChild(0).gameObject.SetActive(false);
        }
    }
}
