using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameStats : MonoBehaviour
{

    public static MinigameStats instance;

    public List<string> ranking = new List<string>();

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
        //DontDestroyOnLoad(gameObject);
    }

}
