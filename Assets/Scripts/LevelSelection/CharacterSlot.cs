using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSlot : MonoBehaviour
{
    public Color color;
    GradientColorKey[] colorKey = new GradientColorKey[3];
    GradientAlphaKey[] alphaKey = new GradientAlphaKey[3];

    public bool isSelected;
    public string playerSelecting;

    void Awake(){
        //color = GetComponent<Material>().color;
        SetColorGradient();
        
    }
    public void ChangeColor(ParticleSystem ps){
        if(!isSelected){
            var colorLifeTime = ps.colorOverLifetime;
        
        Gradient grad = new Gradient();
        grad.SetKeys(colorKey,alphaKey);
        
        colorLifeTime.color = grad;
        }
        
    }
    public void SelectSlot(string player){
        if(!isSelected){
            isSelected = true;
            playerSelecting = player;
        }
    }
    public void DeselectSlot(){
        isSelected = false;
        playerSelecting = null;
    }

    void SetColorGradient(){
        colorKey[0].color = color;
        colorKey[0].time = 0f;

        colorKey[1].color = color;
        colorKey[1].time = .5f;
        colorKey[2].color = color;
        colorKey[2].time = 1f;

        alphaKey[0].alpha = 1f;
        alphaKey[0].time = 0f;
        alphaKey[1].alpha = 0f;
        alphaKey[1].time = .5f;
    }
}
