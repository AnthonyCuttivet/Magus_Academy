using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSelector : MonoBehaviour
{

    void Start(){
        Invoke("CreateFakePlayers",.3f);
    }

    void CreateFakePlayers(){
        for (int i = 0; i < 4; i++){
            Player p = PlayersManager.instance.CreatePlayer();
            PlayersManager.instance.AddSkin(p, i+1);
        }
    }

/*     public List<int> GenerateUniqueRandoms(int amount, int min, int max){
        List<int> numbers = new List<int>();

        for(int i = 0; i < amount; i++){
            int numToAdd = Random.Range(min,max);
            while(numbers.Contains(numToAdd)){
                numToAdd = Random.Range(min,max);
            }
            numbers.Add(numToAdd);
        }

        return numbers;
    } */
}
