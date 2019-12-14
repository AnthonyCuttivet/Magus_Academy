using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TipsScreenManager : MonoBehaviour
{

    public enum MinigamesScenesList{
        Deceived, Dragons, MNG3, MNG4, MNG5
    }

    public MinigamesScenesList currentMinigame;

    public InputActionAsset tipsScreenActions;

    void Awake(){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GetPlayers();
        SceneManager.LoadScene(currentMinigame.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPlayers(){

    }

    void OnReady(GameObject g){
        Debug.Log(g.name + " Ready");
    }
}
