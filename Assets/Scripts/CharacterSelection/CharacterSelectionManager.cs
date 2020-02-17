using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

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

    public bool willDance = false;
    public bool announcer = false;
    public bool lockSelection = false;

    [Space]
    [Header("Start Overlay")]
    
    public GameObject startCanvas;

    [Space]
    [Header("Controller Vibration")]

    public float CS_LvibrationForce = 0.1f;
    public float CS_RvibrationForce = 1;
    public float CS_vibrationTime = .2f;

    public float START_LvibrationForce = 0.1f;
    public float START_RvibrationForce = 1;
    public float START_vibrationTime = .2f;

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
        soundManager.FadeInMusic("MainTheme", 3);
        PlayMagesThemeMuted();
    }

    // Update is called once per frame
    void Update()
    {

        switch(cSState){
            case CSStates.IN_SELECTION :
                if(selectedCount == 4){
                    if(willDance){
                        StartDance();
                    }
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
                    if(willDance){
                        SoundManager.instance.StopMusic("Dance");
                    }
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
        if(cSState == CSStates.IN_SELECTION){
            startCanvas.transform.Find("StartOverlay").gameObject.GetComponent<StartOverlayAnim>().Back();
            Sequence s = DOTween.Sequence();
            startCanvas.transform.Find("RawImage").GetComponent<RawImage>().DOFade(0,1);
            startCanvas.SetActive(false);
        }else if(cSState == CSStates.ALL_SELECTED){
            startCanvas.SetActive(true);
            startCanvas.transform.Find("StartOverlay").gameObject.SetActive(true);
            startCanvas.transform.Find("RawImage").GetComponent<RawImage>().DOFade(.8f,1);
            VibrateAllControllers();
            startCanvas.transform.Find("StartOverlay").GetComponent<StartOverlayAnim>().PlayOverlayAnimation();
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

    public void VibrateAllControllers(){
        foreach (Gamepad g in Gamepad.all){
           g.SetMotorSpeeds(START_LvibrationForce,START_RvibrationForce); 
           StartCoroutine(StopVibrationAfterSeconds(START_vibrationTime, g));
        }
    }

    IEnumerator StopVibrationAfterSeconds(float seconds, Gamepad g){
        yield return new WaitForSeconds(seconds);
        g.PauseHaptics();
    }

    public void StartDance(){
        SoundManager.instance.PlayMusic("Dance");
        foreach (GameObject character in characters){
            Animator animator = character.transform.GetComponent<Animator>();
            animator.SetTrigger("isDancing");
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
        lockSelection = true;
        soundManager.PlaySound("Menu_Return");
        StopAllSkinMusic();
        soundManager.FadeOutMusic("MainTheme", FadeVolumeTime);
        BlackFade.instance.FadeOutToScene("TitleScreen",FadeVolumeTime);
    }
    public void StopAllSkinMusic(){
        foreach(string name in System.Enum.GetNames(typeof (CharacterAttribute.MagesAttributes))){
            soundManager.FadeOutMusicVolume(name + "Theme",FadeVolumeTime);
        }
    }


}
