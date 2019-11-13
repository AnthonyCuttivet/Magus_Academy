using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DragonsManager : MonoBehaviour
{

    public static DragonsManager instance;
    public InputActionAsset dragonsActions;
    [SerializeField]
    public Dictionary<int, int> dragonsScoreboard = new Dictionary<int, int>();
    public List<Player> playersInfos = new List<Player>();
    public List<GameObject> playersGO = new List<GameObject>();
    public Text[] scoresText;

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
        playersInfos = PlayersManager.instance.playersList;
        AssignControllerToPlayer();
    }

    void OnEnable(){
        dragonsActions.Enable();
    }

    public void AddPoints(int id, int points){
        dragonsScoreboard[id] += points;
        Debug.Log(dragonsScoreboard[id]);
        foreach(KeyValuePair<int,int> i in dragonsScoreboard){
            Debug.Log("key " + i.Key);
            Debug.Log("Value " + i.Value);
        }
        UpdateScores();
    }
    public void UpdateScores(){
        for(int i = 0;i<dragonsScoreboard.Count;i++){
            scoresText[i].text = dragonsScoreboard[i].ToString();
        }
    }
    void AssignControllerToPlayer(){
        foreach(GameObject player in playersGO){
            PlayerInput input = player.GetComponent<PlayerInput>();
            input.actions = dragonsActions;
            input.defaultActionMap = "Fishing"; 
        }
    }
}

public class Stats{
    public int Score{get;set;}
    public int Combos{get;set;}

    public Stats(int score, int combos){
        Score = score;
        Combos = combos;
    }
}
