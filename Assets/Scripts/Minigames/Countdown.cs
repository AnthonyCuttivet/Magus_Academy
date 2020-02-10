using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public enum COUNTDOWN_STATES{
        BEFORE_CD,
        IN_CD,
        AFTER_CD
    }

    public static Countdown instance;

    public COUNTDOWN_STATES cdState;

    public float cdTime = 3f;
    public bool countDownFinished = false;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
    }

    // Start is called before the first frame update
    void Start(){
        SoundManager.instance.PlaySound("Countdown");
    }

    // Update is called once per frame
    void Update()
    {
        switch(cdState){
            case COUNTDOWN_STATES.BEFORE_CD :
                
            break;
            case COUNTDOWN_STATES.IN_CD :
                UpdateCountdown();
            break;
            case COUNTDOWN_STATES.AFTER_CD :
                countDownFinished = true;
            break;
        }
    }

    public void UpdateCountdown(){
        cdTime -= Time.deltaTime;
        if(cdTime < 0){
            UpdateCountdownDisplay(0);
            cdTime = 0;
            cdState = COUNTDOWN_STATES.AFTER_CD;
        }else{
            UpdateCountdownDisplay((int)cdTime+1);
        }
    }

    void UpdateCountdownDisplay(int number){
        foreach (Transform t in gameObject.transform){
            t.gameObject.SetActive(false);
        }
        gameObject.transform.GetChild(number).gameObject.SetActive(true);
    }

    IEnumerator DestroyItselfAfterSeconds(float seconds){
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
