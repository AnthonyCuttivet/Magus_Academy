using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{

    public static CharacterSelectionManager instance;

    public int selectedCount = 0;
    public bool ready = false;

    //Security flags
    private bool selectedCountFlag = false;
    private bool readyFlag = false;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable(){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selectedCount == 4 && !selectedCountFlag){
            Debug.Log("All 4 players have selected their characters");
            selectedCountFlag = true;
            //ready = true;
        }
        if(ready && !readyFlag){
            Debug.Log("Everyone is ready, transitioning to " + PlayersManager.instance.nextMinigame.ToString() + " Tips Screen");
            readyFlag = true;
            SceneManager.LoadScene("TipsScreen");
        }
    }
}
