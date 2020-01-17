using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleScreenNavigation : MonoBehaviour
{

    public string selectedMenu;
    SoundManager soundManager;
    void Start(){
        soundManager = SoundManager.instance;
        //Reset and set Globalranking and PlayersList
    }

    void OnEnable(){
        gameObject.GetComponent<PlayerInput>().actions.Enable();
        PlayerPrefs.SetInt("SP_MONSTER_SKIN", 0);
    }

    void Update(){

        if(selectedMenu == ""){
            selectedMenu = EventSystem.current.currentSelectedGameObject.name;
        }
        else if(EventSystem.current.currentSelectedGameObject.name != selectedMenu){
            OnChangeSelectedGO();
            selectedMenu = EventSystem.current.currentSelectedGameObject.name;
        }        
    }

    void OnA(){
        switch(selectedMenu){
            case "Minigames" : 
                PlayersManager.instance.gamemode = PlayersManager.Gamemodes.Single;
                BlackFade.instance.FadeOutToScene("CharacterSelection");
            break;
            case "Tournament" : 
                PlayersManager.instance.gamemode = PlayersManager.Gamemodes.Tournament;
                BlackFade.instance.FadeOutToScene("CharacterSelection");
            break;
            case "Quit" : 
                BlackFade.instance.FadeOutToScene("SplashScreen");
            break;
        }
    }

    public void BackToSplashScreen(){
        soundManager.PlaySound("Menu_Validate");
        BlackFade.instance.FadeOutToScene("SplashScreen");
    }
    public void OnClickStartGame(int gamemode){
        soundManager.PlaySound("Menu_Validate");
        PlayersManager.instance.gamemode = (PlayersManager.Gamemodes) gamemode;
        BlackFade.instance.FadeOutToScene("CharacterSelection");
    }
    public void OnChangeSelectedGO(){
        soundManager.PlaySound("Menu_Switch");
    }
}
