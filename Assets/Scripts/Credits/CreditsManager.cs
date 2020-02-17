using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{

    public enum CREDITSSTATES {
        SCROLLING,
        TFP
    }

    public CREDITSSTATES creditsState;

    public GameObject creditsTexts;
    public float scrollSpeed = 5f;
    public float pressedSpeed = 25f;
    public bool isPressed = false;


    void Start(){
        SoundManager.instance.StopSound("Victory_Complete");
        SoundManager.instance.FadeInMusic("Title",.5f);
    }
    void Update(){
        switch(creditsState){
            case CREDITSSTATES.SCROLLING : 
                if(creditsTexts.transform.localPosition.y >= 3800){
                    creditsState = CREDITSSTATES.TFP;
                    scrollSpeed = 0;
                }
                if(isPressed){
                    scrollSpeed = pressedSpeed;
                }else{
                    scrollSpeed = 5;
                }
                creditsTexts.transform.Translate(new Vector3(0,1,0) * scrollSpeed * Time.deltaTime);
            break;
        }
    }

    void OnFastForward(){
        if(creditsState == CREDITSSTATES.SCROLLING){
            isPressed = !isPressed;
        }
    }

    void OnA(){
        if(creditsState == CREDITSSTATES.TFP){
            SoundManager.instance.PlaySound("Menu_Validate");
            BlackFade.instance.FadeOutToScene("TitleScreen");
        }
    }
}
