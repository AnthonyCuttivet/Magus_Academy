using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using J80N;
using DG.Tweening;

public class CommandsUIManager : MonoBehaviour
{
    public static CommandsUIManager instance;

    public GameObject commandsPlayerPrefab;
    public GameObject playerIcons;
    public int readyCount = 0;
    public bool start = false;
    public GameObject BG;
    [Space]
    [Header("Backgrounds")]
    public Sprite deceivedBG;
    public Sprite DFBG;
    public Sprite KTBBG;

    [Space]
    [Header("Thumbnails")]
    public Sprite[] thumbnails;

    [Space]
    [Header("Inputs")]
    public GameObject imgInputs;
    public Sprite[] inputsSprites;

    [Space]
    [Header("Texts")]
    public GameObject texts;

    [Space]
    [Header("UI Animations")]
    public GameObject left_arrow;
    public GameObject right_arrow;
    public float arrowsOffset = 30f;
    public float arrowsAnimDuration = 2f;
    public GameObject s_thumbnails;
    public GameObject s_sliders;
    public Sprite fullSlider;
    public Sprite emptySlider;
    public int s_id = 0;
    private Transform current_thumbnail;
    private Transform current_slider;
    

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }

        //Set BG
        string currenMinigame = PlayersManager.instance.currentMinigame.ToString();
        switch(currenMinigame){
            case "Deceived" : 
                BG.GetComponent<Image>().sprite = deceivedBG;
            break;
            case "DF" : 
                BG.GetComponent<Image>().sprite = DFBG;
            break;
            case "KTB" : 
                BG.GetComponent<Image>().sprite = KTBBG;
            break;
        }
        BG.GetComponent<Image>().enabled = true;

        //Set UI thumbnails and commands
        switch(currenMinigame){
            case "Deceived" : 
                s_thumbnails.transform.GetChild(0).GetComponent<Image>().sprite = thumbnails[0];
                s_thumbnails.transform.GetChild(1).GetComponent<Image>().sprite = thumbnails[1];
                s_thumbnails.transform.GetChild(2).GetComponent<Image>().sprite = thumbnails[2];

                imgInputs.GetComponent<Image>().sprite = inputsSprites[0];
            break;
            case "DF" : 
                s_thumbnails.transform.GetChild(0).GetComponent<Image>().sprite = thumbnails[3];
                s_thumbnails.transform.GetChild(1).GetComponent<Image>().sprite = thumbnails[4];
                s_thumbnails.transform.GetChild(2).GetComponent<Image>().sprite = thumbnails[5];
            
                imgInputs.GetComponent<Image>().sprite = inputsSprites[1];
            break;
            case "KTB " : 
                s_thumbnails.transform.GetChild(0).GetComponent<Image>().sprite = thumbnails[6];
                s_thumbnails.transform.GetChild(1).GetComponent<Image>().sprite = thumbnails[7];
                s_thumbnails.transform.GetChild(2).GetComponent<Image>().sprite = thumbnails[8];
            
                imgInputs.GetComponent<Image>().sprite = inputsSprites[2];
            break;

        }
        //Set Texts
        texts.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = Translator.Translate("MINIGAMES." + currenMinigame.ToUpper() + ".DESC");
        texts.transform.Find("VictoryCondition").GetComponent<TextMeshProUGUI>().text = Translator.Translate("MINIGAMES." + currenMinigame.ToUpper() + ".VCOND");

        //Generate Commands Players
        foreach(Player p in PlayersManager.instance.playersList){
            GameObject g = Instantiate(commandsPlayerPrefab);
            g.name = p.Id + " " + p.Skin;
            g.GetComponent<PlayerCUI>().id = p.Id;
            //Set Player Icons
            playerIcons.transform.GetChild(p.Id).GetComponent<Image>().sprite = GameObject.Find("PlayersManager").GetComponent<DebugIcons>().icons[p.Skin];
        }
    }

    void Start(){
        //Animate arrow
        AnimateArrows();
        //Set current thumbnail and slider
        current_thumbnail = s_thumbnails.transform.GetChild(0);
        current_slider = s_sliders.transform.GetChild(0);
    }


    // Update is called once per frame
    void Update(){
        if(start){
            SceneManager.LoadScene(PlayersManager.instance.nextMinigame.ToString());
        }
    }

    public void AnimateArrows(){
        //left
        left_arrow.transform.DOMoveX(left_arrow.transform.position.x + arrowsOffset, arrowsAnimDuration).SetEase(Ease.OutSine).SetLoops(-1,LoopType.Yoyo);
        //right
        right_arrow.transform.DOMoveX(right_arrow.transform.position.x - arrowsOffset, arrowsAnimDuration).SetEase(Ease.OutSine).SetLoops(-1,LoopType.Yoyo);
    }

    public void SwapThumbnail(int direction){ //0 -> Left, 1 -> Right
        if(direction == 0 && s_id != 0){
            s_id--;
        }else if(direction == 1 && s_id != 2){
            s_id++;
        }

        //Show / Hide arrows
        if(s_id == 0){
            left_arrow.SetActive(false);
        }else if(s_id == 2){
            right_arrow.SetActive(false);
        }else{
            left_arrow.SetActive(true);
            right_arrow.SetActive(true);
        }
        
        //switch thumbnail
        s_thumbnails.transform.GetChild(s_id).gameObject.SetActive(true);
        current_thumbnail.gameObject.SetActive(false);
        current_thumbnail = s_thumbnails.transform.GetChild(s_id);

        //switch slider
        current_slider.GetComponent<Image>().sprite = emptySlider;
        s_sliders.transform.GetChild(s_id).GetComponent<Image>().sprite = fullSlider;
        current_slider = s_sliders.transform.GetChild(s_id);

    }
}
