using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragonsManager : MonoBehaviour
{

    public static DragonsManager instance;
    public InputActionAsset dragonsActions;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
    }

    void OnEnable(){
        dragonsActions.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
