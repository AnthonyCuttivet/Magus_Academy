using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    public enum CSStates{
        IN_SELECTION,
        ALL_SELECTED,
        AFTER_SELECTION
    }

    public CSStates cSState;

    public static CharacterSelectionManager instance;

    public int selectedCount = 0;
    public bool ready = false;

    public GameObject[] characters;
    public GameObject[] banners;

    public Material[] skins;

    public Color[] cursors;

    public List<int> selectedSkins = new List<int>();

    [Space]
    [Header("Start Overlay")]
    
    public GameObject startCanvas;

    [Space]
    [Header("Special Skin")]
    public GameObject SP_MONSTER_SKIN;
    SoundManager soundManager;
    public float FadeVolumeTime;


    //Security flags
    public bool startPressed = false;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
        //DontDestroyOnLoad(gameObject);
    }

    void OnEnable(){
        
    }

    // Start is called before the first frame update
    void Start(){
        soundManager = SoundManager.instance;
        soundManager.PlayMusic("MainTheme");
        CheckSpecialSkin();
        PlayMagesThemeMuted();
    }

    // Update is called once per frame
    void Update()
    {

        switch(cSState){
            case CSStates.IN_SELECTION :
                if(selectedCount == 4){
                    cSState = CSStates.ALL_SELECTED;
                    ToggleStartOverlay();
                }
            break;
            case CSStates.ALL_SELECTED : 
                if(selectedCount < 4){
                    cSState = CSStates.IN_SELECTION;
                    ToggleStartOverlay();
                }
                if(ready){
                    SetRandomSkins();
                    //Start game with selected gamemode
                    switch(PlayersManager.instance.gamemode){
                        case PlayersManager.Gamemodes.Single:
                            LoadMinigameSelection();
                            cSState = CSStates.AFTER_SELECTION;
                        break;
                        case PlayersManager.Gamemodes.Tournament:
                            PlayersManager.instance.T_LoadNextMinigameCommands();
                            cSState = CSStates.AFTER_SELECTION;
                        break;
                    }
                }
            break;
        }

/*         if(selectedCount == 4 && !selectedCountFlag){
            selectedCountFlag = true;
            ready = true;
        }
        if(ready && !readyFlag){

            readyFlag = true;
            //StartDance();
            switch(PlayersManager.instance.gamemode){
                case PlayersManager.Gamemodes.Single:
                    LoadMinigameSelection();
                break;
                case PlayersManager.Gamemodes.Tournament:

                break;
            }
        } */
    }

    public void SetRandomSkins(){
        //Set random skins
        foreach (Player p in PlayersManager.instance.playersList){
            if(p.Skin == 0){
                PlayersManager.instance.RemoveSkin(p);
                PlayersManager.instance.AddSkin(p, GetRandomSkin());
            }
        }
    }

    public void ToggleStartOverlay(){
        if(startCanvas.activeSelf == true){
            startCanvas.SetActive(false);
        }else{
            startCanvas.SetActive(true);
        }
    }

    public int GetRandomSkin(){
        int randomSkin = 0;
        randomSkin = (int)Random.Range(1,8);
        if(selectedSkins.Count != 0){
            while(selectedSkins.Contains(randomSkin)){
                randomSkin = (int)Random.Range(1,8);
            }
        }
        selectedSkins.Add(randomSkin);
        return randomSkin;
    }

    public void CheckSpecialSkin(){
        if(PlayerPrefs.GetInt("SP_MONSTER_SKIN") == 1){
            SP_MONSTER_SKIN.SetActive(true);
        }
    }

    public void StartDance(){
        gameObject.GetComponent<AudioSource>().Play();
        foreach (GameObject character in characters){
            Animator animator = character.transform.GetComponent<Animator>();
            animator.Play("DanceMoves");    
        }
    }

    public void AddSkin(Player player){
        selectedSkins.Add(player.Skin);
        selectedCount++;
        foreach(Transform g in characters[player.Id].transform/* .GetChild(0) */){
            if(g.name != "Chibi_Character"){
                g.GetComponent<SkinnedMeshRenderer>().material = skins[player.Skin];
            }
        }
        characters[player.Id].SetActive(true);
        soundManager.FadeInMusicVolume((CharacterAttribute.MagesAttributes)player.Skin + "Theme",FadeVolumeTime,true);
    }
    public void RemoveSkin(Player player){
        selectedSkins.Remove(player.Skin);
        selectedCount--;
        characters[player.Id].SetActive(false);
        soundManager.FadeOutMusicVolume((CharacterAttribute.MagesAttributes)player.Skin + "Theme",FadeVolumeTime);
    }
    void PlayMagesThemeMuted(){
        foreach(string name in System.Enum.GetNames(typeof (CharacterAttribute.MagesAttributes))){
            soundManager.PlayMusicMuted(name + "Theme");
        }
    }
    void LoadMinigameSelection(){
        soundManager.PlaySound("Menu_Validate");
        BlackFade.instance.FadeOutToScene("MinigamesScreen");
    }
    public void Return(){
        soundManager.PlaySound("Menu_Return");
        BlackFade.instance.FadeOutToScene("TitleScreen");
    }


}
