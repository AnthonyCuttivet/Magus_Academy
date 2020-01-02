using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleScreenNavigation : MonoBehaviour
{

    public string selectedMenu;

    void OnEnable(){
        gameObject.GetComponent<PlayerInput>().actions.Enable();
        PlayerPrefs.SetInt("SP_MONSTER_SKIN", 0);
    }

    void Update(){
        selectedMenu = EventSystem.current.currentSelectedGameObject.name;
    }

    void OnA(){
        switch(selectedMenu){
            case "Minigames" : 
                PlayersManager.instance.gamemode = PlayersManager.Gamemodes.Single;
                SceneManager.LoadScene("CharacterSelection");
            break;
            case "Tournament" : 
                PlayersManager.instance.gamemode = PlayersManager.Gamemodes.Tournament;
                SceneManager.LoadScene("CharacterSelection");
            break;
            case "Quit" : 
                SceneManager.LoadScene("SplashScreen");
            break;
        }
    }
}
