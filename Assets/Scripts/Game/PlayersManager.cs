using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersManager : MonoBehaviour {

    public static PlayersManager instance;

    [SerializeField]
    public List<Player> playersList = new List<Player>();

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
        DontDestroyOnLoad(gameObject);
    }

    public Player CreatePlayer(){
        Player p = new Player(playersList.Count, -1);
        playersList.Add(p);
        Debug.Log("Created Player " + p.Id);
        return p;
    }

    public void AddSkin(Player p, int skin){
        p.Skin = skin;
        Debug.Log("Skin " + p.Skin + " has been set to Player " + p.Id);
    }

    public void RemoveSkin(Player p){
        p.Skin = -1;
        Debug.Log("Skin has been removed from Player " + p.Id);
    }
}
