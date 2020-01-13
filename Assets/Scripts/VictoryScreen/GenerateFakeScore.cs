using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFakeScore : MonoBehaviour
{

    public Dictionary<Player,int> minigameRanking = new Dictionary<Player, int>();

    // Start is called before the first frame update
    void Start(){
        for (int i = 0; i < 4; i++){
            minigameRanking.Add(new Player(i,i+1), (i+1)*4526);
        }
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.Deceived, minigameRanking);
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.DF, minigameRanking);
        PlayersManager.instance.globalRanking.Add(PlayersManager.Minigames.KTB, minigameRanking);
    }
}
