using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSlot : MonoBehaviour
{
    public Gradient gradient;

    public bool isSelected;
    public string playerSelecting;

    void Awake(){

        
    }
    public void ChangeColor(ParticleSystem body, ParticleSystem trail){
        if(!isSelected){
            var colorLifeTime = body.colorOverLifetime;
            colorLifeTime.color = gradient;
            
            var psChild = trail.colorOverLifetime;
            psChild.color = gradient;
            
            var gradientTrail = trail.trails.colorOverLifetime;
            gradientTrail.color = gradient.colorKeys[0].color;
        }
        
    }
    public void SelectSlot(PointerPlayer player){
        if(!isSelected){
            isSelected = true;
            player.slot = this;
            player.locked = true;
            player.velocity = Vector3.zero;
            playerSelecting = player.name;
        }
    }
    public void DeselectSlot(){
        isSelected = false;
        playerSelecting = null;
    }

}
