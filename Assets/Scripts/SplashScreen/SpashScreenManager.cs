using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SpashScreenManager : MonoBehaviour
{

    public InputActionAsset controls;

    public void OnEnable(){
        controls.Enable();
    }

    void OnStart(){
        SceneManager.LoadScene("TitleScreen");
    }
}
