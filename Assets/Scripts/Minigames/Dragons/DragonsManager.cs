﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;
using TMPro;


public class DragonsManager : MonoBehaviour
{

    public enum DFStates{
        BEFORE_GAME,
        IN_GAME,
        AFTER_GAME,
    }

    public DFStates dfState;

    public static DragonsManager instance;
    public InputActionAsset dragonsActions;
    public List<Player> playersInfos = new List<Player>();
    
    [SerializeField]
    public Dictionary<int, int> dragonsScoreboard = new Dictionary<int, int>();
    public GameObject playersGO;
    public TextMeshProUGUI timerText;
    public GameObject countDown;
    public GameObject fishableZone;
    public bool playersInitialized = false;
    public GameObject ScoresUI;

    [Space]
    [Header("Minigame Vars")] 
    public float timeLeft;
    public int basePoints = 100;
    public int sequenceMultiplier = 20;
    public int comboScale = 1;
    public int QTELength = 5;
    public float sequenceMaxTime = 5f;
    public float bitingMaxTime = 10f;
    public int qteStreak = 3;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
        
    }
    void Start(){
        dfState = DFStates.BEFORE_GAME;
        playersInfos = PlayersManager.instance.playersList;
        dragonsActions.Enable();
        AssignControllerToPlayer();
        
    }

    void Update(){
        switch(dfState){
            case DFStates.BEFORE_GAME :
                if(!playersInitialized){
                    InitializePlayers();
                }
                switch(countDown.GetComponent<Countdown>().cdState){
                    case Countdown.COUNTDOWN_STATES.BEFORE_CD :
                        countDown.GetComponent<Countdown>().cdState = Countdown.COUNTDOWN_STATES.IN_CD;
                    break;
                    case Countdown.COUNTDOWN_STATES.AFTER_CD :
                        dfState = DFStates.IN_GAME;
                        ToggleFishableZone(true);
                    break;
                }
            break;
            case DFStates.IN_GAME :
                timeLeft -= Time.deltaTime;
                UpdateTimerDisplay();
                if(timeLeft < 0){
                    timeLeft = 0;
                    dfState = DFStates.AFTER_GAME;
                    EndGame();
                }
            break;
            case DFStates.AFTER_GAME :

            break;

        }
    }

    public void PrintScores(){
        string tmp = "";
        foreach(KeyValuePair<int,int> kvp in dragonsScoreboard){
            tmp += "["+kvp.Key + " : " + kvp.Value+"]";
        }
        print(tmp);
    }
    void InitializePlayers(){
        //Initialized scoreboard
        dragonsScoreboard.Add(0, 0);
        dragonsScoreboard.Add(1, 0);
        dragonsScoreboard.Add(2, 0);
        dragonsScoreboard.Add(3, 0);

        //Players Icons
        GameObject icons = GameObject.Find("PlayersManager");
        foreach (Player p in playersInfos){
            ScoresUI.transform.GetChild(p.Id).Find("Icon").GetComponent<Image>().sprite = icons.GetComponent<DebugIcons>().icons[p.Skin];
        }

        playersInitialized = true;
    }

    void EndGame(){
        ToggleFishableZone(false);
        PlayersManager.instance.globalRanking[PlayersManager.Minigames.DF] = DragonsManager.instance.dragonsScoreboard;
        PlayersManager.instance.UpdateTotals();
        BlackFade.instance.FadeOutToScene("FinalWinnerScreen");
    }

    void ToggleFishableZone(bool activated){
        fishableZone.SetActive(activated);
    }

    void UpdateTimerDisplay(){
        timerText.text = ((int)timeLeft).ToString();
    }

    void OnEnable(){
        dragonsActions.Enable();
    }

    public void AddPoints(int id, int points){
        dragonsScoreboard[id] += points;
    }

    void AssignControllerToPlayer(){
        foreach(Player player in playersInfos){
            GameObject currentPlayerGO = playersGO.transform.GetChild(player.Id).gameObject;
            currentPlayerGO.GetComponent<QTE>().id = player.Id;
            PlayerInput playerInput = currentPlayerGO.AddComponent<PlayerInput>();
            playerInput.actions = Instantiate(dragonsActions);
            playerInput.actions.Enable();
            playerInput.user.UnpairDevices();
            InputUser.PerformPairingWithDevice(playersInfos[player.Id].device,playerInput.user);
        }   
    }
}