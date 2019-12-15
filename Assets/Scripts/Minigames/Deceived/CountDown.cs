using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CountDown : MonoBehaviour
{

    public float time;
    public AudioClip countDownSFX;
    public AudioClip goSFX;
    private int currentSecond = -1;
    public static CountDown instance;
    public bool countDownfinished;

    void Awake(){
        currentSecond = (int)time % 60;
        instance = this;
    }

    // Update is called once per frame
    void Update(){
        if(!CharactersSpawner.instance.gameStart){
            if(time > 0){
                time -= Time.deltaTime;
                int second = (int)time % 60;
                gameObject.GetComponent<TextMeshProUGUI>().text = (second + 1).ToString();
                if(currentSecond != second){
                    PlaySound(countDownSFX);
                }
                currentSecond = second;
            }else{
                CharactersSpawner.instance.gameStart = true;
                //gameObject.GetComponent<DestroySelf>().enabled = true;
                gameObject.GetComponent<TextMeshProUGUI>().text = "GO!";
                PlaySound(goSFX);
                gameObject.GetComponent<TextMeshProUGUI>().DOFade(0,0.5f);
                countDownfinished = true;
            }
        }
    }

    void PlaySound(AudioClip clp){
        gameObject.GetComponent<AudioSource>().clip = clp;
        gameObject.GetComponent<AudioSource>().Play();
    }


}
