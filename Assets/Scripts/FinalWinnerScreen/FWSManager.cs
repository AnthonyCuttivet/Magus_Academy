using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FWSManager : MonoBehaviour
{

    public GameObject playersFWS;

    // Start is called before the first frame update
    void Start(){
        Dictionary<int,int> totals = new Dictionary<int, int>();
        int currentPlayer = 0;
        foreach (KeyValuePair<int,int> totalScore in totals){
            
            currentPlayer++;
        }
    }

    public void SetModelBannerScore(int slot, int skin, int score){
        GameObject currentPlayerGO = playersFWS.transform.GetChild(slot).gameObject;

        //Set banner
        currentPlayerGO.transform.Find("Banner").GetComponent<Image>().sprite = GetComponent<Magesnames>().banners[skin];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
