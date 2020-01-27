using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;


[System.Serializable]
public class Player
{
    public int Id; //{get; set;}
    public int Skin; //{get; set;}
    public InputDevice device;

    public Player(int _id, int _skin){
        Id = _id;
        Skin = _skin;
        
    }
}
