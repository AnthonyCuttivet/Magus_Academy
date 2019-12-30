using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{

    public static CharacterSelectionManager instance;

    public int selectedCount = 0;
    public bool ready = false;

    public GameObject[] characters;
    public GameObject[] banners;

    public Material[] skins;

    public Color[] cursors;

    public List<int> selectedSkins = new List<int>();

    [Space]
    [Header("Special Skin")]
    public GameObject SP_MONSTER_SKIN;
    SoundManager soundManager;


    //Security flags
    private bool selectedCountFlag = false;
    private bool readyFlag = false;

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
        if(selectedCount == 4 && !selectedCountFlag){
            selectedCountFlag = true;
            ready = true;
        }
        if(ready && !readyFlag){
            //Set random skins
            foreach (Player p in PlayersManager.instance.playersList){
                if(p.Skin == 0){
                    PlayersManager.instance.RemoveSkin(p);
                    PlayersManager.instance.AddSkin(p, GetRandomSkin());
                }
            }
            readyFlag = true;
            StopAllMusic();
            //StartDance();
            switch(PlayersManager.instance.gamemode){
                case PlayersManager.Gamemodes.Single:
                    SceneManager.LoadScene("MinigamesScreen");
                break;
                case PlayersManager.Gamemodes.Tournament:

                break;
            }
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
            Animator animator = character.transform.GetChild(0).GetComponent<Animator>();
            animator.Play("DanceMoves");    
        }
    }

    public void AddSkin(Player player){
        selectedSkins.Add(player.Skin);
        selectedCount++;
        foreach(Transform g in characters[player.Id].transform.GetChild(0)){
            if(g.name != "Chibi_Character"){
                g.GetComponent<SkinnedMeshRenderer>().material = skins[player.Skin];
            }
        }
        characters[player.Id].SetActive(true);
        soundManager.FadeInMusicVolume((CharacterAttribute.MagesAttributes)player.Skin + "Theme",.3f,true,.3f);
    }
    public void RemoveSkin(Player player){
        selectedSkins.Remove(player.Skin);
        selectedCount--;
        characters[player.Id].SetActive(false);
        soundManager.FadeOutMusicVolume((CharacterAttribute.MagesAttributes)player.Skin + "Theme",.3f);
    }
    void PlayMagesThemeMuted(){
        foreach(string name in System.Enum.GetNames(typeof (CharacterAttribute.MagesAttributes))){
            soundManager.PlayMusicMuted(name + "Theme");
        }
    }
    public void StopAllMusic(){
        foreach(int skinNumber in selectedSkins){
            Debug.Log(System.Enum.GetName(typeof(CharacterAttribute.MagesAttributes), skinNumber));
            soundManager.FadeOutMusic(System.Enum.GetName(typeof(CharacterAttribute.MagesAttributes), skinNumber)+ "Theme",1f);
        }
        soundManager.FadeOutMusic("MainTheme",1f);
    }


}
