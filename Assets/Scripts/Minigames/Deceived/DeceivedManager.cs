using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeceivedManager : MonoBehaviour
{

    public static DeceivedManager instance;

    public static bool gameEnded = false;
    public int scoresSaved = 0;
    public Material[] skins;
    public float despawnRate;
    [Range(0,1)]
    public float EndGamePercentage; //percentage of players that trigger endgame musics
    float initialCharacterNumber;
    float currentDespawnRate;
    SoundManager soundManager;
    List<string> magesThemes = new List<string>();  
    List<Player> playersInfos;
    CharactersSpawner spawner;
    int playerNumber;
    bool transitionned;
    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
        currentDespawnRate = despawnRate;
    }
    void Start(){
        playersInfos = PlayersManager.instance.playersList;
        playerNumber = playersInfos.Count;
        Debug.Log(playerNumber);
        soundManager = SoundManager.instance;
        StartMusic();
        spawner = CharactersSpawner.instance;
        initialCharacterNumber = 4 + spawner.amountOfEntities;
    }

    // Update is called once per frame
    void Update(){
        if(CharactersSpawner.instance.players.Count == 1 && scoresSaved == 4 && !gameEnded){
            gameEnded = true;
            //Save minigame scoreboard to global scoreboard
            PlayersManager.instance.globalRanking.Add(PlayersManager.instance.currentMinigame, MinigameStats.instance.ranking);
            LoadVictoryScreen();
        }
        else if(CountDown.instance.countDownfinished){
            Despawner();
            EndGameTransition();
        }
    }
    public void LoadVictoryScreen(){
        SceneManager.LoadScene("MinigameVictoryScreen");
    }

    void Despawner(){
        if(spawner.PNJList.Count > 0){
            currentDespawnRate -= Time.deltaTime;
            if(currentDespawnRate < 0){
                DespawnRandomPNJ();
                currentDespawnRate = despawnRate;
            }
        }
    }
    void DespawnRandomPNJ(){
        int randomPnjIndex = Random.Range(0,spawner.PNJList.Count);
        GameObject randomPnj = spawner.PNJList[randomPnjIndex];
        spawner.PNJList.Remove(randomPnj);
        spawner.pooledEntities.Remove(randomPnj);
        Destroy(randomPnj);
    }
    void StartMusic(){
        soundManager.PlayMusic("Deceived_MainTheme");
        foreach(Player player in playersInfos){
            string skin = System.Enum.GetName(typeof(CharacterAttribute.MagesAttributes), player.Skin);
            magesThemes.Add(skin);
            soundManager.PlayMusic("Deceived_"+skin+"Theme");
        } 
    }
    void EndGameTransition(){
        if(!transitionned){
            float characterPercentage = (spawner.PNJList.Count + spawner.players.Count)/initialCharacterNumber;
            if(characterPercentage <= EndGamePercentage || spawner.PNJList.Count == 0){
                foreach(string theme in magesThemes){
                    Debug.Log(theme);
                    soundManager.FadeOutMusic("Deceived_" + theme +"Theme",2f);
                    if(theme != "Earth"){
                        soundManager.FadeInMusic("Deceived_" + theme +"EndTheme",2f);
                    }
                    
                }
                soundManager.FadeOutMusic("Deceived_MainTheme",2f);
                soundManager.FadeInMusic("Deceived_MainEndTheme",2f);
                transitionned = true;

                
            }
        }
        
    }
    public void StopMusicSkin(int skin){
        soundManager.FadeOutMusic("Deceived_" + (CharacterAttribute.MagesAttributes)skin + "Theme",2f);
    }
}
