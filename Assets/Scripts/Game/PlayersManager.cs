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

    public void UpdateTotals(){

        print("ntm");

        foreach(KeyValuePair<int,int> kvp in globalRanking[PlayersManager.Minigames.Deceived]){
            print(kvp.Key + " : " + kvp.Value + "pts");
        }

        for (int i = 0; i < 4; i++){
            globalRanking[PlayersManager.Minigames.LB_TOTAL][i] = globalRanking[PlayersManager.Minigames.Deceived][i] + globalRanking[PlayersManager.Minigames.DF][i] + globalRanking[PlayersManager.Minigames.KTB][i];
        }

        foreach(KeyValuePair<int,int> kvp in globalRanking[PlayersManager.Minigames.LB_TOTAL]){
            print(kvp.Key + " : " + kvp.Value + "pts");
        }

        globalRanking = OrderScores(globalRanking);
        



/*         Dictionary<int,int> totals = new Dictionary<int, int>();
        for (int i = 0; i < 4; i++){
            totals.Add(i,0);
        }

        foreach (KeyValuePair<PlayersManager.Minigames,Dictionary<int,int>> kvp in globalRanking){                    
            if(kvp.Key != PlayersManager.Minigames.LB_TOTAL){
                foreach(KeyValuePair<int,int> minigameScoreKvp in kvp.Value){
                    print(kvp.Value[minigameScoreKvp.Key]);
                    totals[minigameScoreKvp.Key] += kvp.Value[minigameScoreKvp.Key];
                }
            }
        }

        globalRanking[PlayersManager.Minigames.LB_TOTAL] = totals;



        Dictionary<PlayersManager.Minigames,Dictionary<int,int>> updatedTotals = globalRanking;
        foreach(KeyValuePair<PlayersManager.Minigames,Dictionary<int,int>> kvp in updatedTotals){
            if(kvp.Key != PlayersManager.Minigames.LB_TOTAL){
                foreach(KeyValuePair<int,int> minigameScoreKvp in kvp.Value){
                    updatedTotals[PlayersManager.Minigames.LB_TOTAL][minigameScoreKvp.Key] += minigameScoreKvp.Value;
                }
            }
        } */
        

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

}
