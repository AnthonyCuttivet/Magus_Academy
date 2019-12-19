using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinigameVSManager : MonoBehaviour
{

    public GameObject lines;
    public GameObject BG;
    public Sprite deceivedBG;
    public GameObject winnerModel;
    private bool generated = false;

    void OnEnable(){

    }

    // Start is called before the first frame update
    void Awake(){

    }

    // Update is called once per frame
    void Update(){
        //Set BG
        switch(PlayersManager.instance.currentMinigame.ToString()){
            case "Deceived" : 
                BG.GetComponent<Image>().sprite = deceivedBG;
            break;
        }
        BG.GetComponent<Image>().enabled = true;

        //Set winner skin
        foreach(Transform t in winnerModel.transform.GetChild(0)){
            if(t.name != "Chibi_Character"){
                t.GetComponent<SkinnedMeshRenderer>().material = GetComponent<Magesnames>().skins[PlayersManager.instance.globalRanking[PlayersManager.instance.currentMinigame][0].Skin];
            }
        }
        winnerModel.SetActive(true);
        
        if(!generated){
            foreach(KeyValuePair<int,Player> ranking in PlayersManager.instance.globalRanking[PlayersManager.instance.currentMinigame]){
                GameObject currentLine = lines.transform.GetChild(ranking.Key).gameObject;
                currentLine.transform.Find("Icon").GetComponent<Image>().sprite = GetComponent<DebugIcons>().icons[ranking.Value.Skin];
                currentLine.transform.Find("Name").GetComponent<TextMeshProUGUI>().text += GetComponent<Magesnames>().skinsNames[ranking.Value.Skin];
            }
            generated = true;
        }
    }
}
