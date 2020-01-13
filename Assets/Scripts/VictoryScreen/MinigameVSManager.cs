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
    private bool generated = false;

    void OnEnable(){

    }

    // Start is called before the first frame update
    void Awake(){

    }

    // Update is called once per frame
    void Update(){
        
        if(!generated){

            //Order scoreboard
            OrderScoreboard(PlayersManager.instance.globalRanking[PlayersManager.instance.currentMinigame]);

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

            //Set winner skin and banner
            int winnerSkinID = PlayersManager.instance.globalRanking[PlayersManager.instance.currentMinigame].First().Key.Skin;

/*             foreach(Transform t in winnerModel.transform.GetChild(0)){
                if(t.name != "Chibi_Character"){
                    t.GetComponent<SkinnedMeshRenderer>().material = GetComponent<Magesnames>().skins[winnerSkinID];
                }
            } */
            //winnerModel.SetActive(true);
            //banner.GetComponent<Image>().sprite = GetComponent<Magesnames>().banners[winnerSkinID];
            
            //Fill scoreboard
            int lineNumber = 0;

/*             foreach(KeyValuePair<PlayersManager.Minigames,Dictionary<Player,int>> gr in PlayersManager.instance.globalRanking){
                foreach (KeyValuePair<Player,int> ranking in gr){
                    
                }
            } */


            foreach(KeyValuePair<Player,int> ranking in PlayersManager.instance.globalRanking[PlayersManager.instance.currentMinigame]){
                GameObject currentLine = lines.transform.GetChild(lineNumber).gameObject;
                string completeName = currentLine.transform.Find("PID").GetComponent<TextMeshProUGUI>().text + (ranking.Key.Id+1);
                currentLine.transform.Find("PID").GetComponent<TextMeshProUGUI>().text = "<color=#" + ColorUtility.ToHtmlStringRGB(GetComponent<Magesnames>().playerColors[ranking.Key.Id]) + ">" + completeName + "</color>";
                currentLine.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = ranking.Value + " pts";
                lineNumber++;
            }
            generated = true;
        }
    }

    public void OrderScoreboard(Dictionary<Player, int> scoreBoard){
        Dictionary<Player, int> scToReturn = new Dictionary<Player, int>();
        foreach (KeyValuePair<Player,int> line in scoreBoard.OrderByDescending(x => x.Value)){
            scToReturn.Add(line.Key, line.Value);
        }
        PlayersManager.instance.globalRanking[PlayersManager.instance.currentMinigame] = scToReturn;
    }
}
