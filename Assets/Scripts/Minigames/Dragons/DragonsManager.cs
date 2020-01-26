using System.Collections;
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
    public PlayerInputManager inputManager;
    [SerializeField]
    public Dictionary<int, int> dragonsScoreboard = new Dictionary<int, int>();
    public List<Player> playersInfos = new List<Player>();
    public List<GameObject> playersGO = new List<GameObject>();  
    public TextMeshProUGUI timerText;
    public GameObject countDown;
    public GameObject fishableZone;

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
        
        dragonsScoreboard.Add(0, 0);
        dragonsScoreboard.Add(1, 0);
        dragonsScoreboard.Add(2, 0);
        dragonsScoreboard.Add(3, 0);
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
                }
            break;
            case DFStates.AFTER_GAME :
                ToggleFishableZone(false);
            break;

        }
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

/*     public void AddPoints(int id, int points){
        dragonsScoreboard[id] += points;
<<<<<<< HEAD
        //Debug.Log(dragonsScoreboard[id]);
        foreach(KeyValuePair<int,int> i in dragonsScoreboard){
/*             Debug.Log("key " + i.Key);
            Debug.Log("Value " + i.Value); */
        }
        UpdateScores();
    }
    public void UpdateScores(){
        for(int i = 0;i<dragonsScoreboard.Count;i++){
            scoresText[i].text = dragonsScoreboard[i].ToString();
        }
    }
    void AssignControllerToPlayer(){
        for(int i = 0; i < PlayersManager.instance.playersList.Count;i++){
            PlayerInput playerInput = playersGO[i].AddComponent<PlayerInput>();
=======
    } */
    void AssignControllerToPlayer(){   
        foreach(GameObject playerGO in playersGO){
            PlayerInput playerInput = playerGO.AddComponent<PlayerInput>();
>>>>>>> Dragon Fishing avancement
            playerInput.actions = Instantiate(dragonsActions);
            playerInput.actions.Enable();
            playerInput.user.UnpairDevices();
            InputUser.PerformPairingWithDevice(PlayersManager.instance.playersList[i].device,playerInput.user);
        }   
    }
}