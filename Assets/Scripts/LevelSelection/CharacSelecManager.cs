using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacSelecManager : MonoBehaviour
{
    CharacterSlot[] slots;

    void Awake(){
        slots = GetComponentsInChildren<CharacterSlot>();
    }

    void Update(){
        int selectCount = slots.Where(x => x.isSelected).Count();
        if(selectCount == 2){
            Debug.Log("eee");
        }

    }
}
