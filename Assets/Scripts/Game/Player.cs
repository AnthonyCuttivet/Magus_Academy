using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    [SerializeField]
    public int Id; //{get; set;}
    [SerializeField]
    public int Skin; //{get; set;}

    public Player(int _id, int _skin){
        Id = _id;
        Skin = _skin;
    }
}
