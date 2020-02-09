using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCUI : MonoBehaviour
{

    public bool ready = false;
    public int id;
    SoundManager soundManager;

    void OnEnable(){
        gameObject.GetComponent<PlayerInput>().actions.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnReady(){
        if(!ready){
            ToggleReady();
            CommandsUIManager.instance.readyCount++;
            soundManager.PlaySound("Menu_Validate");
        }else{
            ToggleReady();
            CommandsUIManager.instance.readyCount--;
            soundManager.PlaySound("Menu_Return");
        }
    }

    void OnBack(){
        if(PlayersManager.instance.gamemode == PlayersManager.Gamemodes.Single){
            soundManager.PlaySound("Menu_Return");
            CommandsUIManager.instance.StopMainTheme();
            BlackFade.instance.FadeOutToScene("MinigamesScreen");
        }
    }

/*     void OnCancel(){
        if(ready){
            ToggleReady();
            CommandsUIManager.instance.readyCount--;
            soundManager.PlaySound("Menu_Return");
        }
    } */

    void OnStart(){
        if(CommandsUIManager.instance.readyCount == 4){
            CommandsUIManager.instance.start = true;
        }
    }

    void OnSelect(){
        CommandsUIManager.instance.start = true;
    }

    void OnLeft(){
        if(CommandsUIManager.instance.s_id != 0){
            CommandsUIManager.instance.SwapThumbnail(0);
            soundManager.PlaySound("Menu_Switch");
        }
    }

    void OnRight(){
        if(CommandsUIManager.instance.s_id != 2){
            CommandsUIManager.instance.SwapThumbnail(1);
            soundManager.PlaySound("Menu_Switch");
        }
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
