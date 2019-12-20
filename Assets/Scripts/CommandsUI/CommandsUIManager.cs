using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        //Set UI



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

    }


    // Update is called once per frame
    void Update(){
        if(start){
            SceneManager.LoadScene(PlayersManager.instance.nextMinigame.ToString());
        }
    }
}
