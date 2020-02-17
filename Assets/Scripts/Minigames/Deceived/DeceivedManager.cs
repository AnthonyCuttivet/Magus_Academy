using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Linq;
using UnityEngine.UI;

public class DeceivedManager : MonoBehaviour
{

    public static DeceivedManager instance;

    public bool gameEnded = false;
    public int scoresSaved = 0;
    public Material[] skins;
    public Gradient[] projectileColors;
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
    public Transform mapCenter;

    public Dictionary<int,int> deceivedScores = new Dictionary<int,int>();

    [Space]
    [Header("Camera Zoom")]
    public float zoomDuration;
    public float endZoomSize;
    public float endZoomWaitBeforeLoadVictoryScene;
    public Collider mapCollider;

    [Space]
    [Header("Players UI")]
    public GameObject playersUI;
    public enum Spells{
        Shot,
        Invisibility
    }

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
        soundManager = SoundManager.instance;
        StartCoroutine(StartMusic());
        spawner = CharactersSpawner.instance;
        initialCharacterNumber = 4 + spawner.amountOfEntities;
        SetPlayersUI();
        Countdown.instance.cdState = Countdown.COUNTDOWN_STATES.IN_CD;
    }
    void Update(){
        if(CharactersSpawner.instance.players.Count == 1 && scoresSaved >= 4 && !gameEnded){
            gameEnded = true;
            playersUI.SetActive(false);

            //Save minigame scoreboard to global scoreboard
            PlayersManager.instance.globalRanking[PlayersManager.Minigames.Deceived] = deceivedScores;
            PlayersManager.instance.UpdateTotals(PlayersManager.Minigames.Deceived);

            StartCoroutine(EndGameZoom());
            
        }
        else if(Countdown.instance.countDownFinished){
            Despawner();
            EndGameTransition();
        }
    }
    
    public void SetPlayersUI(){
        foreach (Player p in playersInfos){
            playersUI.transform.GetChild(p.Id).Find("Active/Icon").GetComponent<Image>().sprite = PlayersManager.instance.gameObject.GetComponent<DebugIcons>().icons[p.Skin];
            playersUI.transform.GetChild(p.Id).Find("Inactive/Icon").GetComponent<Image>().sprite = PlayersManager.instance.gameObject.GetComponent<DebugIcons>().icons[p.Skin];
        }
    }

    public void FadeUISpell(Spells spell, int playerID){
        Transform playerUI = playersUI.transform.GetChild(playerID);
        switch(spell){
            case Spells.Shot : 
                playerUI.Find("Active/Spell").gameObject.SetActive(false);
            break;
            case Spells.Invisibility : 
                playerUI.Find("Active/Inv").gameObject.SetActive(false);
            break;
        }
    }

    public void KillUIPlayer(int playerID){
        playersUI.transform.GetChild(playerID).Find("Active").gameObject.SetActive(false);
    }
 

    public void LoadVictoryScreen(){
        if(PlayersManager.instance.gamemode == PlayersManager.Gamemodes.Single){
            BlackFade.instance.FadeOutToScene("FinalWinnerScreen");
        }else if(PlayersManager.instance.gamemode == PlayersManager.Gamemodes.Tournament){
            BlackFade.instance.FadeOutToScene("MinigameVictoryScreen");
        }
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
        StartCoroutine(randomPnj.GetComponent<PNJControls>().Dissolve());
        //Destroy(randomPnj);
    }
    IEnumerator StartMusic(){
        while(!Countdown.instance.countDownFinished){
            yield return null;
        }
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
    IEnumerator EndGameZoom(){
        soundManager.PlaySound("Victory_Complete");
        StopAllMusic();
        Vector3 winnerPosition = CharactersSpawner.instance.players[0].transform.position;
        Camera camera = Camera.main;
        StartCoroutine(cameraZoom(camera,endZoomSize,zoomDuration));
        yield return new WaitForSeconds(zoomDuration);
        float VerticalHeightSeen    = endZoomSize * 2.0f;                   //l'orthographic size = ce qui est vu verticalement par la camera * 2
        float HorizontalHeightSeen = VerticalHeightSeen * Screen.width / Screen.height;         //on recupere le valeur horiztontale
        Vector3 newCamPos = camera.transform.position;    
        float boundX = mapCollider.bounds.max.x - HorizontalHeightSeen / 2;             //bound sur le x pour eviter de zoom sur le dehors de la map
        newCamPos.x = Mathf.Clamp(winnerPosition.x,-boundX,boundX);
        newCamPos.y -= 30;
        newCamPos.z = winnerPosition.z - 35;
        winnerPosition.x = newCamPos.x;
        camera.transform.DOMove(newCamPos,zoomDuration); 
        yield return new WaitForSeconds(zoomDuration);
        camera.transform.DOLookAt(winnerPosition,zoomDuration);
        yield return new WaitForSeconds(zoomDuration);
        yield return new WaitForSeconds(endZoomWaitBeforeLoadVictoryScene);
/*         while(soundManager.SoundIsPlaying("Victory")){
            yield return null;
        } */
        LoadVictoryScreen();                               
    }
    IEnumerator cameraZoom(Camera camera,float wantedSize,float duration){
        float sizeReduction = camera.orthographicSize - wantedSize;
        while(camera.orthographicSize > wantedSize){
            camera.orthographicSize -= (Time.deltaTime * sizeReduction) / duration;
            yield return null;
        }
    }
    public void StopMusicSkin(int skin){
        soundManager.FadeOutMusic("Deceived_" + (CharacterAttribute.MagesAttributes)skin + "Theme",2f);
    }

    public void StopAllMusic(){
        foreach(int skin in PlayersManager.instance.playersList.Select(x => x.Skin)){
            soundManager.FadeOutMusic("Deceived_" + (CharacterAttribute.MagesAttributes)skin + "EndTheme",1f);
        }
        soundManager.FadeOutMusic("Deceived_MainEndTheme",2f);
        foreach(int skin in PlayersManager.instance.playersList.Select(x => x.Skin)){
            soundManager.FadeOutMusic("Deceived_" + (CharacterAttribute.MagesAttributes)skin + "Theme",1f);
        }
        soundManager.FadeOutMusic("Deceived_MainTheme",2f);
    }

}
