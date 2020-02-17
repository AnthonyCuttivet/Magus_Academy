using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FWSManager : MonoBehaviour
{

    public GameObject playersFWS;
    private bool generated = false;

    // Start is called before the first frame update
    void Start(){
        //SoundManager.instance.PlayMusic("Victory");
    }

    // Update is called once per frame
    void Update()
    {
        if(!generated && PlayersManager.instance.globalRanking[PlayersManager.Minigames.LB_TOTAL] != null){
            Dictionary<int,int> totals = PlayersManager.instance.globalRanking[PlayersManager.Minigames.LB_TOTAL];
            int currentPlayer = 0;
            foreach (KeyValuePair<int,int> totalScore in totals){
                SetModelBannerScore(currentPlayer,totalScore.Key,totalScore.Value);
                currentPlayer++;
            }
        }
        generated = true;
    }

    public void SetModelBannerScore(int slot, int id, int score){
        GameObject currentPlayerGO = playersFWS.transform.GetChild(slot).gameObject;
        int winnerSkinID = PlayersManager.instance.GetSkin(id);

        //Set banner
        currentPlayerGO.transform.Find("Banner").GetComponent<Image>().sprite = GetComponent<Magesnames>().banners[PlayersManager.instance.GetSkin(id)];

        //Set winner skin 
        foreach(Transform t in currentPlayerGO.transform.Find("CharacterMenu")){
            if(t.name != "Chibi_Character"){
                t.GetComponent<SkinnedMeshRenderer>().material = GetComponent<Magesnames>().skins[winnerSkinID];
            }
        }

        //Set Score
        currentPlayerGO.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = score + " PTS";

        //Activate Fireworks
        if(slot == 0){
            playersFWS.transform.Find("Fireworks").gameObject.SetActive(true);
            //currentPlayerGO.transform.Find("CharacterMenu").GetComponent<Animator>().SetTrigger("isVictorious");
        }
    }

    void OnA(){
        BlackFade.instance.FadeOutToScene("Credits");
    }
}
