using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayersManager : MonoBehaviour {

    public enum Minigames{
        Deceived,
        DF,
        KTB,
        LB_TOTAL,
    }

    public enum Gamemodes{
        Single,
        Tournament
    }


    public static PlayersManager instance = null;

    [SerializeField]
    public List<Player> playersList = new List<Player>();
    public Dictionary<Minigames, Dictionary<int,int>> globalRanking = new Dictionary<Minigames, Dictionary<int,int>>();

    public Minigames nextMinigame;
    public Minigames currentMinigame;
    public Gamemodes gamemode;

    void Awake(){
        if(instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public Player CreatePlayer(){
        Player p = new Player(playersList.Count, -1);
        playersList.Add(p);
        return p;
    }

    public void AddSkin(Player p, int skin){
        p.Skin = skin;
        if(skin != 0){
            CharacterSelectionManager.instance.AddSkin(p);
        }
        gameObject.transform.Find("DebugIcons").gameObject.GetComponent<DebugIcons>().AddDebugIcon(p.Id, p.Skin);
    }

    public void RemoveSkin(Player p){
        CharacterSelectionManager.instance.RemoveSkin(p);
        p.Skin = -1;
    }

    public int GetSkin(int playerId){
        return playersList.Where(x=>x.Id == playerId).First().Skin;
    }
}
