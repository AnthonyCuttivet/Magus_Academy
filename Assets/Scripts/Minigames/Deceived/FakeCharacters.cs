using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCharacters : MonoBehaviour
{
    void Awake(){
        /* for (int i = 0; i < 4; i++)
        {
            Player p = PlayersManager.CreatePlayer();
            PlayersManager.AddSkin(p, i);
            CharacterSelectionManager.instance.selectedCount++;
        } */
        List<int> randomSkins = GenerateUniqueRandoms(4, 0, 7);
        Player p = PlayersManager.instance.CreatePlayer();
        PlayersManager.instance.AddSkin(p, randomSkins[0]);
        Player q = PlayersManager.instance.CreatePlayer();
        PlayersManager.instance.AddSkin(q, randomSkins[1]);
        Player a = PlayersManager.instance.CreatePlayer();
        PlayersManager.instance.AddSkin(a, randomSkins[2]);
        Player b = PlayersManager.instance.CreatePlayer();
        PlayersManager.instance.AddSkin(b, randomSkins[3]);
    }

    public List<int> GenerateUniqueRandoms(int amount, int min, int max){
        List<int> numbers = new List<int>();

        for(int i = 0; i < amount; i++){
            int numToAdd = Random.Range(min,max);
            while(numbers.Contains(numToAdd)){
                numToAdd = Random.Range(min,max);
            }
            numbers.Add(numToAdd);
        }

        return numbers;
    }
}
