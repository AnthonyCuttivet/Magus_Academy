using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersManager : MonoBehaviour {

    public enum Minigames{
        Deceived,
        DF,
        KTB,
    }


    public static PlayersManager instance;

    [SerializeField]
    public List<Player> playersList = new List<Player>();
    public Dictionary<Minigames, Dictionary<int,Player>> globalRanking = new Dictionary<Minigames, Dictionary<int,Player>>();

    public Minigames nextMinigame;
    public Minigames currentMinigame;

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
        return p;
    }

    public void AddSkin(Player p, int skin){
        p.Skin = skin;
        if(skin != 0){
            CharacterSelectionManager.instance.AddSkin(p,skin);
        }
        gameObject.transform.Find("DebugIcons").gameObject.GetComponent<DebugIcons>().AddDebugIcon(p.Id, p.Skin);
    }

    public void RemoveSkin(Player p){
        CharacterSelectionManager.instance.RemoveSkin(p);
        p.Skin = -1;
    }
}
