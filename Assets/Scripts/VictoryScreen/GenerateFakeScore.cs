using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenerateFakeScore : MonoBehaviour
{

    public Dictionary<int,int> minigameRanking = new Dictionary<int, int>();

    // Start is called before the first frame update
    void Start(){

        Dictionary<int,int> totals = new Dictionary<int, int>();

        //Generate players totals keys and scores
        for (int i = 0; i < 4; i++){
            Player p = new Player(i,i+1);
            minigameRanking.Add(p.Id, Random.Range(100,10000));
            totals.Add(p.Id, 0);
        }
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.Deceived, minigameRanking);
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.DF, minigameRanking);
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.KTB, minigameRanking);
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.LB_TOTAL, totals);
        UpdateTotals(PlayersManager.instance.globalRanking);
        
    }
    
    public void UpdateTotals(Dictionary<PlayersManager.Minigames,Dictionary<int,int>> globalRanking){

        Dictionary<PlayersManager.Minigames,Dictionary<int,int>> updatedTotals = globalRanking;
        foreach(KeyValuePair<PlayersManager.Minigames,Dictionary<int,int>> kvp in globalRanking){
            if(kvp.Key != PlayersManager.Minigames.LB_TOTAL){
                foreach(KeyValuePair<int,int> minigameScoreKvp in kvp.Value){
                    updatedTotals[PlayersManager.Minigames.LB_TOTAL][minigameScoreKvp.Key] += kvp.Value[minigameScoreKvp.Key];
                }
            }
        }
        updatedTotals = OrderScores(updatedTotals);
        PlayersManager.instance.globalRanking = updatedTotals;

    }

    public Dictionary<PlayersManager.Minigames,Dictionary<int,int>> OrderScores(Dictionary<PlayersManager.Minigames,Dictionary<int,int>> globalRanking){

        Dictionary<PlayersManager.Minigames,Dictionary<int,int>> totalsToReturn = new Dictionary<PlayersManager.Minigames,Dictionary<int,int>>();
        
        foreach (KeyValuePair<PlayersManager.Minigames,Dictionary<int,int>> kvp in globalRanking){

            Dictionary<int,int> tmpCategoryTotal = new Dictionary<int,int>();

            foreach (KeyValuePair<int,int> category in kvp.Value.OrderByDescending(x => x.Value)){
                tmpCategoryTotal.Add(category.Key, category.Value);
            }

            totalsToReturn.Add(kvp.Key,tmpCategoryTotal);
        }

        return totalsToReturn;
    }
}
