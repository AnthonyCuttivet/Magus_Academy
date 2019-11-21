﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttribute : MonoBehaviour
{

    public enum MagesAttributes{
        Earth = 1, 
        Ice = 2, 
        Fire = 3, 
        Wind = 4, 
        Light = 5, 
        Lightning = 6, 
        Death = 7, 
        Dark = 8, 
        Random = 0
    }

    public MagesAttributes attribute;
    [HideInInspector]
    public int attributeID;

    public void Awake(){
        attributeID = (int)attribute;
    }
}
