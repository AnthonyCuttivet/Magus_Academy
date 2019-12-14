using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeceivedManager : MonoBehaviour
{

    public static DeceivedManager instance;

    public static bool gameEnded = false;
    public Material[] skins;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update(){
        if(CharactersSpawner.instance.players.Count == 1 && !gameEnded){
            gameEnded = true;
            //MinigameStats.instance.ranking.Add(CharactersSpawner.instance.players[0].name);
            UiWinner();
            LoadVictoryScreen();
        }
    }

    public void UiWinner(){
        
    }

    public void LoadVictoryScreen(){
        SceneManager.LoadScene("VictoryScreen");
    }
}
