using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScreenNavigation : MonoBehaviour
{
    void OnEnable(){
        gameObject.GetComponent<PlayerInput>().actions.Enable();
        PlayerPrefs.SetInt("SP_MONSTER_SKIN", 0);
    }

    void OnA(){
        SceneManager.LoadScene("CharacterSelection");
    }

    void OnSelect(){
        SceneManager.LoadScene("RedeemCode");
    }
}
