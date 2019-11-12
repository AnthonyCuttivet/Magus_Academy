using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragonsManager : MonoBehaviour
{

    public static DragonsManager instance;
    public InputActionAsset dragonsActions;
    [SerializeField]
    public Dictionary<int, int> dragonsScoreboard = new Dictionary<int, int>();

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

    void OnEnable(){
        dragonsActions.Enable();
    }

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int id, int points){
        dragonsScoreboard[id]+= points;
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
