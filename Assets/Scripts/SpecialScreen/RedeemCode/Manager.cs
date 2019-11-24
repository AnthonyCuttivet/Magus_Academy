using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour{

    public string code;
    public string userCode = "";
    public bool fullCode = false;
    public bool unlocked = false;

    public GameObject underscores;
    public GameObject currentUnderscore;
    public int currentIndex = -1;

    public GameObject unlockText;

    [Space]
    [Header("Sprites Input")]

    public Sprite a,b,x,y,u,d,l,r,n;

    void OnEnable(){
        gameObject.GetComponent<PlayerInput>().actions.Enable();
    }

    // Start is called before the first frame update
    void Start(){
        SetCurrentInputIndex(true);
    }

    // Update is called once per frame
    void Update(){
        if(userCode.Length == code.Length){
            fullCode = true;
        }else{
            fullCode = false;
        }
    }

    // Check code
    void OnStart(){
        if(fullCode){
            if(userCode == code){
                PlayerPrefs.SetInt("SP_MONSTER_SKIN", 1);
                gameObject.GetComponent<AudioSource>().Play();
                unlockText.SetActive(true);
                unlocked = true;
            }else{
                print("Invalid code, please check and try again");
            }
        }
    }

    // Cancel last input
    void OnSelect(){
        RemoveLastInput();
    }

    void SetCurrentInputIndex(bool shift){
        if(shift == true){
            currentIndex ++;
            currentUnderscore = underscores.transform.GetChild(currentIndex).gameObject;
            currentUnderscore.GetComponent<Blink>().enabled = true;
        }else if(shift == false){
            if(currentIndex != (code.Length - 1)){
                currentIndex --;
            }
            currentUnderscore = underscores.transform.GetChild(currentIndex).gameObject;
            currentUnderscore.transform.localScale = new Vector3(.25f,.25f,.25f);
            currentUnderscore.GetComponent<SpriteRenderer>().sprite = n;
            currentUnderscore.GetComponent<Blink>().enabled = true;
        }
    }

    void RemoveLastInput(){
        userCode = userCode.Remove(userCode.Length - 1);
/*         if(userCode.Length != code.Length){
            underscores.transform.GetChild(currentIndex + 1).gameObject.GetComponent<Blink>().enabled = false;
        } */
        UnshiftIndex();
    }

    void ShiftIndex(){
        if(userCode.Length < code.Length){
            SetCurrentInputIndex(true);
        }
    }

    void UnshiftIndex(){
        SetCurrentInputIndex(false);
    }

    void ShowInput(string input){
        if(userCode.Length < code.Length){
            userCode += input;
            switch(input){
                case "a" :
                    currentUnderscore.GetComponent<SpriteRenderer>().sprite = a;
                break;
                case "b" :
                    currentUnderscore.GetComponent<SpriteRenderer>().sprite = b;
                break;
                case "x" :
                    currentUnderscore.GetComponent<SpriteRenderer>().sprite = x;
                break;
                case "y" :
                    currentUnderscore.GetComponent<SpriteRenderer>().sprite = y;
                break;
                case "u" :
                    currentUnderscore.GetComponent<SpriteRenderer>().sprite = u;
                break;
                case "d" :
                    currentUnderscore.GetComponent<SpriteRenderer>().sprite = d;
                break;
                case "l" :
                    currentUnderscore.GetComponent<SpriteRenderer>().sprite = l;
                break;
                case "r" :
                    currentUnderscore.GetComponent<SpriteRenderer>().sprite = r;
                break;
            }
            currentUnderscore.GetComponent<Blink>().enabled = false;
            currentUnderscore.transform.localScale = new Vector3(1,1,1);
            ShiftIndex();
        }
    }

    void OnA(){
        ShowInput("a");
    }

    void OnB(){
        ShowInput("b");
        if(unlocked){
            SceneManager.LoadScene("TitleScreen");
        }
    }

    void OnX(){
        ShowInput("x");
    }

    void OnY(){
        ShowInput("y");
    }

    void OnUp(){
        ShowInput("u");
    }

    void OnDown(){
        ShowInput("d");
    }

    void OnLeft(){
        ShowInput("l");
    }

    void OnRight(){
        ShowInput("r");
    }
}
