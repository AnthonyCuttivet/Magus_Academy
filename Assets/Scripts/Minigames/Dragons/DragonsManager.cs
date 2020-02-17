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
    public List<Player> playersInfos = new List<Player>();
    
    [SerializeField]
    public Dictionary<int, int> dragonsScoreboard = new Dictionary<int, int>();
    public GameObject playersGO;
    public TextMeshProUGUI timerText;
    public GameObject countDown;
    public GameObject finish;
    public float finishSeconds;
    public GameObject fishableZone;
    public bool playersInitialized = false;
    public GameObject ScoresUI;

    public bool vthasPlayed = false;

    [Space]
    [Header("Minigame Vars")] 
    public float timeLeft;
    public int basePoints = 100;
    public int sequenceMultiplier = 20;
    public int comboScale = 1;
    public int QTELength = 5;
    public int qteStreak = 3;

    [Space]
    [Header("Music")]
    public List<string> magesThemes = new List<string>();  

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
                        StartMusic();
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
                if(vthasPlayed == false){
                    SoundManager.instance.PlaySound("Victory_Complete");
                    vthasPlayed = true;
                }
            break;

        }
    }

    void StartMusic(){
        SoundManager.instance.PlayMusic("DF_Main");
        foreach(Player player in playersInfos){
            string skin = System.Enum.GetName(typeof(CharacterAttribute.MagesAttributes), player.Skin);
            magesThemes.Add(skin);
            SoundManager.instance.PlayMusic("DF_"+skin);
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

    void EndMusic(){
        foreach(string theme in magesThemes){
            Debug.Log(theme);
            SoundManager.instance.FadeOutMusic("DF_" + theme,2f);
        }
        SoundManager.instance.FadeOutMusic("DF_Main",2f);
    }

    void EndGame(){
        ToggleFishableZone(false);
        EndMusic();


        PlayersManager.instance.globalRanking[PlayersManager.Minigames.DF] = dragonsScoreboard;

        PlayersManager.instance.UpdateTotals(PlayersManager.Minigames.DF);

        SoundManager.instance.PlaySound("CountDown");
        finish.SetActive(true);

        StartCoroutine(ShowFinish());
    }

    public IEnumerator ShowFinish(){
        yield return new WaitForSeconds(finishSeconds);
        //Switch to next scene
        switch(PlayersManager.instance.gamemode){
            case PlayersManager.Gamemodes.Single :
                BlackFade.instance.FadeOutToScene("FinalWinnerScreen");
            break;
            case PlayersManager.Gamemodes.Tournament :
                PlayersManager.instance.T_ShowScoreboardScene();
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

    public void AddPoints(int id, int points){
        dragonsScoreboard[id] += points;
    }

    void AssignControllerToPlayer(){
        Color[] colors = GameObject.Find("PlayersManager").GetComponent<DebugIcons>().colors;
        foreach(Player player in playersInfos){
            GameObject currentPlayerGO = playersGO.transform.GetChild(player.Id).gameObject;
            currentPlayerGO.GetComponent<QTE>().id = player.Id;
            currentPlayerGO.transform.Find("CP").GetComponent<SpriteRenderer>().color = colors[player.Skin];
            PlayerInput playerInput = currentPlayerGO.AddComponent<PlayerInput>();
            playerInput.actions = Instantiate(dragonsActions);
            playerInput.actions.Enable();
            playerInput.user.UnpairDevices();
            InputUser.PerformPairingWithDevice(playersInfos[player.Id].device,playerInput.user);
        }   
    }
}