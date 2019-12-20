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
    public Sprite deceivedBG;
    public Sprite DFBG;
    public Sprite KTBBG;
    public GameObject winnerModel;
    public GameObject banner;
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

            //Set winner skin and banner
            int winnerSkinID = PlayersManager.instance.globalRanking[PlayersManager.instance.currentMinigame].First().Value.Skin;

            foreach(Transform t in winnerModel.transform.GetChild(0)){
                if(t.name != "Chibi_Character"){
                    t.GetComponent<SkinnedMeshRenderer>().material = GetComponent<Magesnames>().skins[winnerSkinID];
                }
            }
            winnerModel.SetActive(true);
            banner.GetComponent<Image>().sprite = GetComponent<Magesnames>().banners[winnerSkinID];
            
            //Fill scoreboard
            int lineNumber = 0;
            foreach(KeyValuePair<int,Player> ranking in PlayersManager.instance.globalRanking[PlayersManager.instance.currentMinigame]){
                GameObject currentLine = lines.transform.GetChild(lineNumber).gameObject;
                currentLine.transform.Find("Icon").GetComponent<Image>().sprite = GetComponent<DebugIcons>().icons[ranking.Value.Skin];
                string completeName = currentLine.transform.Find("PID").GetComponent<TextMeshProUGUI>().text + (ranking.Value.Id+1);
                currentLine.transform.Find("PID").GetComponent<TextMeshProUGUI>().text = "<color=#" + ColorUtility.ToHtmlStringRGB(GetComponent<Magesnames>().playerColors[ranking.Value.Id]) + ">" + completeName + "</color>";
                currentLine.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = ranking.Key + " pts";
                lineNumber++;
            }
            generated = true;
        }
    }

    public void OrderScoreboard(Dictionary<int, Player> scoreBoard){
        Dictionary<int, Player> scToReturn = new Dictionary<int, Player>();
        List<int> orderedScores = new List<int>();
        foreach(KeyValuePair<int,Player> line in scoreBoard){
            orderedScores.Add(line.Key);
        }
        orderedScores.Sort();
        orderedScores.Reverse();
        foreach(int score in orderedScores){
            scToReturn.Add(score, scoreBoard[score]);
        }
        PlayersManager.instance.globalRanking[PlayersManager.instance.currentMinigame] = scToReturn;
    }
}
