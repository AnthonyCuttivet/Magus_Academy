using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TipsScreenManager : MonoBehaviour
{

    public InputActionAsset tipsScreenActions;

    void Awake(){
        Debug.Log(PlayersManager.instance.nextMinigame.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        InstantiatePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiatePlayers(){

    }

    void OnReady(GameObject g){
        Debug.Log(g.name + " Ready");
    }
}
