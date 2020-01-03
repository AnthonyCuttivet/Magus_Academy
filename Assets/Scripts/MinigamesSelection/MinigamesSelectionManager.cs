﻿using System.Collections;
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
        selectedMinigame = EventSystem.current.currentSelectedGameObject.name;
        SwitchInformations();
    }

    void SwitchInformations(){
        minigamesInfos.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = Translator.Translate("MINIGAMES." + selectedMinigame.ToUpper() + ".TITLE");
        minigamesInfos.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = Translator.Translate("MINIGAMES." + selectedMinigame.ToUpper() + ".DESC");
        minigamesInfos.transform.Find("VictoryCondition").GetComponent<TextMeshProUGUI>().text = Translator.Translate("MINIGAMES." + selectedMinigame.ToUpper() + ".VCOND");
    }

    void OnA(){
        PlayersManager.instance.nextMinigame = (PlayersManager.Minigames)System.Enum.Parse( typeof(PlayersManager.Minigames), selectedMinigame);
        PlayersManager.instance.currentMinigame = (PlayersManager.Minigames)System.Enum.Parse( typeof(PlayersManager.Minigames), selectedMinigame);
        SceneManager.LoadScene("CommandsScreen");
    }
}