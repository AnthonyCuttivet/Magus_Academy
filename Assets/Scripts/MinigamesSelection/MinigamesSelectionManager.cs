using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using J80N;
using TMPro;

public class MinigamesSelectionManager : MonoBehaviour
{

    public string selectedMinigame;
    public GameObject minigamesInfos;
    SoundManager soundManager;
    void Start(){
        soundManager = SoundManager.instance;
    }
    void OnEnable(){
        gameObject.GetComponent<PlayerInput>().actions.Enable();
    }

    void Update()
    {
        if(selectedMinigame == ""){
            selectedMinigame = "Deceived";
            SwitchInformations();
        }
        else if(EventSystem.current.currentSelectedGameObject.name != selectedMinigame){
            OnChangeSelectedGO();
            selectedMinigame = EventSystem.current.currentSelectedGameObject.name;
            SwitchInformations();
        }
       
        
    }

    void SwitchInformations(){
        minigamesInfos.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = Translator.Translate("MINIGAMES." + selectedMinigame.ToUpper() + ".TITLE");
        minigamesInfos.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = Translator.Translate("MINIGAMES." + selectedMinigame.ToUpper() + ".DESC");
        minigamesInfos.transform.Find("VictoryCondition").GetComponent<TextMeshProUGUI>().text = Translator.Translate("MINIGAMES." + selectedMinigame.ToUpper() + ".VCOND");
    }

    void OnA(){
        PlayersManager.instance.nextMinigame = (PlayersManager.Minigames)System.Enum.Parse( typeof(PlayersManager.Minigames), selectedMinigame);
        PlayersManager.instance.currentMinigame = (PlayersManager.Minigames)System.Enum.Parse( typeof(PlayersManager.Minigames), selectedMinigame);
        BlackFade.instance.FadeOutToScene("CommandsScreen");
        soundManager.PlaySound("Menu_Validate");
    }

    void OnBack(){
        PlayersManager.instance.playersList = new List<Player>();
        BlackFade.instance.FadeOutToScene("CharacterSelection");
        soundManager.PlaySound("Menu_Cancel");
    }

    public void OnChangeSelectedGO(){
        soundManager.PlaySound("Menu_Switch");
    }


}
