﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFakeScore : MonoBehaviour
{

    public Dictionary<int,Player> minigameRanking = new Dictionary<int, Player>();

    // Start is called before the first frame update
    void Start(){
        PlayersManager.instance.currentMinigame = PlayersManager.Minigames.Deceived;
        for (int i = 0; i < 4; i++){
            minigameRanking.Add(i,new Player(i,i+1));
        }
        PlayersManager.instance.globalRanking.Add(PlayersManager.instance.currentMinigame, minigameRanking);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}