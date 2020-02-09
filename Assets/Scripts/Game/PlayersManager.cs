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

    public void ResetPlayers(){
        PlayersManager.instance.playersList = new List<Player>();
    }

    public Player CreatePlayer(){
        Player p = new Player(playersList.Count, -1);
        playersList.Add(p);
        return p;
    }

    public void AddSkin(Player p, int skin){
        p.Skin = skin;
        CharacterSelectionManager.instance.AddSkin(p);
        //gameObject.transform.Find("DebugIcons").gameObject.GetComponent<DebugIcons>().AddDebugIcon(p.Id, p.Skin);
    }

    public void RemoveSkin(Player p){
        CharacterSelectionManager.instance.RemoveSkin(p);
        p.Skin = -1;
    }

    public int GetSkin(int playerId){
        return playersList.Where(x=>x.Id == playerId).First().Skin;
    }

    public void UpdateTotals(){

        globalRanking[PlayersManager.Minigames.LB_TOTAL][0] = globalRanking[PlayersManager.Minigames.Deceived][0] + globalRanking[PlayersManager.Minigames.DF][0] + globalRanking[PlayersManager.Minigames.KTB][0];
        globalRanking[PlayersManager.Minigames.LB_TOTAL][1] = globalRanking[PlayersManager.Minigames.Deceived][1] + globalRanking[PlayersManager.Minigames.DF][1] + globalRanking[PlayersManager.Minigames.KTB][1];
        globalRanking[PlayersManager.Minigames.LB_TOTAL][2] = globalRanking[PlayersManager.Minigames.Deceived][2] + globalRanking[PlayersManager.Minigames.DF][2] + globalRanking[PlayersManager.Minigames.KTB][2];
        globalRanking[PlayersManager.Minigames.LB_TOTAL][3] = globalRanking[PlayersManager.Minigames.Deceived][3] + globalRanking[PlayersManager.Minigames.DF][3] + globalRanking[PlayersManager.Minigames.KTB][3];

        globalRanking = OrderScores(globalRanking);
    
    }

    public Dictionary<PlayersManager.Minigames,Dictionary<int,int>> OrderScores(Dictionary<PlayersManager.Minigames,Dictionary<int,int>> _globalRanking){

        Dictionary<PlayersManager.Minigames,Dictionary<int,int>> totalsToReturn = new Dictionary<PlayersManager.Minigames,Dictionary<int,int>>();
        
        foreach (KeyValuePair<PlayersManager.Minigames,Dictionary<int,int>> kvp in _globalRanking){

            Dictionary<int,int> tmpCategoryTotal = new Dictionary<int,int>();

            foreach (KeyValuePair<int,int> category in kvp.Value.OrderByDescending(x => x.Value)){
                tmpCategoryTotal.Add(category.Key, category.Value);
            }

            totalsToReturn.Add(kvp.Key,tmpCategoryTotal);
        }

        return totalsToReturn;
    }

    public void T_LoadNextMinigameCommands(){
        BlackFade.instance.FadeOutToScene("CommandsScreen");
    }

    public void T_ShowScoreboardScene(){
        BlackFade.instance.FadeOutToScene("MinigameVictoryScreen");
    }

}
