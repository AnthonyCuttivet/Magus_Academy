using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TipsScreenManager : MonoBehaviour
{

    public InputActionAsset tipsScreenActions;

    void Awake(){
        foreach (Player p in PlayersManager.instance.playersList){
            
        }
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
        foreach (Player p in PlayersManager.instance.playersList){
            
            //g.transform.parent = GameObject.Find("Players").transform;
        }
    }

    void OnReady(GameObject g){
        Debug.Log(g.name + " Ready");
    }
}
