using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Player
{
    public int Id; //{get; set;}
    public int Skin; //{get; set;}

    public Player(int _id, int _skin){
        Id = _id;
        Skin = _skin;
    }
}
