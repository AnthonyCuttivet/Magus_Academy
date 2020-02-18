using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class MinigameVSManager : MonoBehaviour
{

    public GameObject lines;
    public GameObject BG;
    public Sprite[] backgrounds;
    public GameObject winner;

    private bool generated = false;
    public bool hasClicked = false;

    void OnEnable(){

    }

    // Start is called before the first frame update
    void Awake(){

    }

    // Update is called once per frame
    void Update(){
        
        if(!generated){

            Dictionary<PlayersManager.Minigames,Dictionary<int,int>> globalRanking = PlayersManager.instance.globalRanking;

            //Set BG
            switch(PlayersManager.instance.currentMinigame.ToString()){
                case "Deceived" : 
                    BG.GetComponent<Image>().sprite = backgrounds[0];
                break;
                case "DF" : 
                    BG.GetComponent<Image>().sprite = backgrounds[1];
                break;
                case "KTB" : 
                    BG.GetComponent<Image>().sprite = backgrounds[2];
                break;
            }
            BG.GetComponent<Image>().enabled = true;

            //Reading globalRanking and Filling table
            int currentLine = 0;
            foreach(KeyValuePair<int,int> totals in globalRanking[PlayersManager.Minigames.LB_TOTAL]){
                
                //Set player names regarding their total scores
                Transform currentPlayerLine = lines.transform.GetChild(currentLine);
                currentPlayerLine.Find("Name").GetComponent<TextMeshProUGUI>().text += (" " + (totals.Key+1));

                //Set each minigame score
                if(globalRanking.Keys.Contains(PlayersManager.Minigames.Deceived)){
                    currentPlayerLine.Find("Scores/Deceived").GetComponent<TextMeshProUGUI>().text = globalRanking[PlayersManager.Minigames.Deceived][totals.Key] + " pts";
                }
                if(globalRanking.Keys.Contains(PlayersManager.Minigames.DF)){
                    currentPlayerLine.Find("Scores/DF").GetComponent<TextMeshProUGUI>().text = globalRanking[PlayersManager.Minigames.DF][totals.Key] + " pts";
                }
                if(globalRanking.Keys.Contains(PlayersManager.Minigames.KTB)){
                    currentPlayerLine.Find("Scores/KTB").GetComponent<TextMeshProUGUI>().text = globalRanking[PlayersManager.Minigames.KTB][totals.Key] + " pts";
                }

                currentLine++;
            }

            SetWinnerSkinAndBanner();

            generated = true;
        }
    }

    public void SetWinnerSkinAndBanner(){

        int winnerSkinID = PlayersManager.instance.playersList[PlayersManager.instance.globalRanking[PlayersManager.Minigames.LB_TOTAL].Aggregate((l, r) => l.Value > r.Value ? l : r).Key].Skin;

        foreach(Transform t in winner.transform.Find("CharacterMenu")){
            if(t.name != "Chibi_Character"){
                t.GetComponent<SkinnedMeshRenderer>().material = GetComponent<Magesnames>().skins[winnerSkinID];
            }
        }
        winner.transform.Find("Banner").GetComponent<Image>().sprite = GetComponent<Magesnames>().banners[winnerSkinID];
    }

    void OnA(){
        if(hasClicked == false){
            hasClicked = true;
            SoundManager.instance.StopSound("Victory_Complete");
            switch(PlayersManager.instance.currentMinigame){
                case PlayersManager.Minigames.Deceived :
                    PlayersManager.instance.currentMinigame = PlayersManager.Minigames.DF;
                    PlayersManager.instance.nextMinigame = PlayersManager.Minigames.DF;
                    BlackFade.instance.FadeOutToScene("CommandsScreen");
                break;
                case PlayersManager.Minigames.DF :
                    PlayersManager.instance.currentMinigame = PlayersManager.Minigames.KTB;
                    PlayersManager.instance.nextMinigame = PlayersManager.Minigames.KTB;
                    BlackFade.instance.FadeOutToScene("CommandsScreen");
                break;
                case PlayersManager.Minigames.KTB :
                    PlayersManager.instance.currentMinigame = PlayersManager.Minigames.LB_TOTAL;
                    PlayersManager.instance.nextMinigame = PlayersManager.Minigames.LB_TOTAL;
                    BlackFade.instance.FadeOutToScene("FinalWinnerScreen");
                break;
            }
        }
    }
}
