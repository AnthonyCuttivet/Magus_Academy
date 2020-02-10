using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeceivedScoring : MonoBehaviour
{
    
    public int score;
    private float currentTime;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        InvokeRepeating("AddPointsPerSecond", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPointsPerSecond(){
        if(alive && Countdown.instance.countDownFinished){
            score += PlayersSettings.instance.pointsPerSecond;
        }
    }
}
