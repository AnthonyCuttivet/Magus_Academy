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

    void Start(){
        Cursor.visible = false;
        InitializeScoreboard();
    }

    void Update(){
        //Security input
        if(Input.GetKeyDown(KeyCode.F1)){
            playersList = new List<Player>();
            globalRanking = new Dictionary<Minigames, Dictionary<int, int>>();
            SoundManager.instance.FadeAllMusicsAndSounds();
            BlackFade.instance.FadeOutToScene("TitleScreen");
        }
    }

    public void InitializeScoreboard(){
        for (int i = 0; i < 4; i++){
            globalRanking[PlayersManager.Minigames.LB_TOTAL][i] = 0;
            globalRanking[PlayersManager.Minigames.Deceived][i] = 0;
            globalRanking[PlayersManager.Minigames.DF][i] = 0;
            globalRanking[PlayersManager.Minigames.KTB][i] = 0;
        }
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

    public void UpdateTotals(Minigames from){

        Dictionary<int,int> tmpTotals = new Dictionary<int, int>(globalRanking[Minigames.LB_TOTAL]);

        string aaa = "";
        foreach (KeyValuePair<Minigames,Dictionary<int,int>> kvp in globalRanking){
            aaa += "["+kvp.Key + ":" + kvp.Value[0]+"]";
        }
        print("GRIUTBFA : " + aaa);

        foreach (KeyValuePair<int,int> kvp in globalRanking[from]){
            tmpTotals[kvp.Key] += globalRanking[from][kvp.Key];
        }

        globalRanking[Minigames.LB_TOTAL] = tmpTotals;

        string tmpsc3 = "";
        foreach (KeyValuePair<Minigames,Dictionary<int,int>> kvp in globalRanking){
            tmpsc3 += "["+kvp.Key + ":" + kvp.Value[0]+"]";
        }
        print("GRIUTAA : " + tmpsc3);

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
