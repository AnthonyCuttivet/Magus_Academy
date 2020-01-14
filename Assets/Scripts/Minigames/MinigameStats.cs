using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameStats : MonoBehaviour
{

    public static MinigameStats instance;

    public Dictionary<int,int> ranking = new Dictionary<int,int>(); //score, Player

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
        //DontDestroyOnLoad(gameObject);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
/*             foreach (KeyValuePair<int, int> kvp in ranking)
            {
                print(kvp.Key + " " + kvp.Value);
            } */
        }
    }

}
