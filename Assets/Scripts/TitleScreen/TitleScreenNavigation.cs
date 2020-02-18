using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreenNavigation : MonoBehaviour
{

    public string selectedMenu;
    SoundManager soundManager;

    public GameObject buttonsGO;
    public GameObject arrow;

    public bool hasClicked = false;

    [Space]
    [Header("Controller Vibration")]

    public float C_LvibrationForce = 0.1f;
    public float C_RvibrationForce = 1;
    public float C_vibrationTime = .2f;

    public float S_LvibrationForce = 0.1f;
    public float S_RvibrationForce = 1;
    public float S_vibrationTime = .2f;


    void Start(){
        soundManager = SoundManager.instance;
        PlayersManager.instance.currentMinigame = PlayersManager.Minigames.Deceived;
        PlayersManager.instance.nextMinigame = PlayersManager.Minigames.Deceived;
        soundManager.FadeInMusic("Title",3);
    }

    void OnEnable(){
        //gameObject.GetComponent<PlayerInput>().actions.Enable();
        PlayerPrefs.SetInt("SP_MONSTER_SKIN", 0);

        //Reset and set Globalranking and PlayersList
        ResetData();
    }

    void Update(){
        if(selectedMenu == ""){
            selectedMenu = EventSystem.current.currentSelectedGameObject.name;
        }
        else if(EventSystem.current.currentSelectedGameObject.name != selectedMenu){
            selectedMenu = EventSystem.current.currentSelectedGameObject.name;
            OnChangeSelectedGO();
        }        
    }

    public void ResetData(){
        PlayersManager.instance.globalRanking = new Dictionary<PlayersManager.Minigames, Dictionary<int, int>>();
        Dictionary<int, int> cleanArray = new Dictionary<int, int>();
        for (int i = 0; i < 4; i++){cleanArray.Add(i,0);}
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.LB_TOTAL, cleanArray);
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.Deceived, cleanArray);
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.DF, cleanArray);
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.KTB, cleanArray);
        PlayersManager.instance.playersList = new List<Player>();
    }

    void OnA(){
        switch(selectedMenu){
            case "Minigames" : 
                PlayersManager.instance.gamemode = PlayersManager.Gamemodes.Single;
                BlackFade.instance.FadeOutToScene("CharacterSelection");
            break;
            case "Tournament" : 
                PlayersManager.instance.gamemode = PlayersManager.Gamemodes.Tournament;
                PlayersManager.instance.nextMinigame = PlayersManager.Minigames.Deceived;
                PlayersManager.instance.currentMinigame = PlayersManager.Minigames.Deceived;
                BlackFade.instance.FadeOutToScene("CharacterSelection");
            break;
            case "Credits" : 
                ToCredits();
            break;
        }
    }

    public void ToCredits(){
        if(hasClicked == false){
            soundManager.PlaySound("Menu_Validate");
            BlackFade.instance.FadeOutToScene("Credits");
            hasClicked = true;
        }
    }

    public void OnClickStartGame(int gamemode){
        if(hasClicked == false){
            soundManager.PlaySound("Menu_Validate");
            PlayersManager.instance.gamemode = (PlayersManager.Gamemodes) gamemode;
            soundManager.FadeOutMusic("Title", 3);
            BlackFade.instance.FadeOutToScene("CharacterSelection",3);
            hasClicked = true;
        }
    }
    public void OnChangeSelectedGO(){
        soundManager.PlaySound("Menu_Switch");
        foreach (Transform t in buttonsGO.transform){
            if(t.name != selectedMenu){
                t.GetComponent<TextMeshProUGUI>().enableVertexGradient = false;
            }
        }
        buttonsGO.transform.Find(selectedMenu).GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
        arrow.transform.localPosition = new Vector3(arrow.transform.localPosition.x,EventSystem.current.currentSelectedGameObject.transform.localPosition.y,arrow.transform.localPosition.z);
    }
    void PlayMagesThemeMuted(){
        foreach(string name in System.Enum.GetNames(typeof (CharacterAttribute.MagesAttributes))){
            soundManager.PlayMusicMuted(name + "Theme");
        }
    }
}
