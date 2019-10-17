using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeceivedManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CharactersSpawner.instance.players.Count == 1){
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
