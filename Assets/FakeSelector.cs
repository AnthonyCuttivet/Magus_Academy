using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSelector : MonoBehaviour
{


    void Start(){
        /* for (int i = 0; i < 4; i++)
        {
            Player p = PlayersManager.CreatePlayer();
            PlayersManager.AddSkin(p, i);
            CharacterSelectionManager.instance.selectedCount++;
        } */
        Player p = PlayersManager.instance.CreatePlayer();
        PlayersManager.instance.AddSkin(p, 1);
        CharacterSelectionManager.instance.selectedCount++;
        Player q = PlayersManager.instance.CreatePlayer();
        PlayersManager.instance.AddSkin(q, 0);
        CharacterSelectionManager.instance.selectedCount++;
        Player a = PlayersManager.instance.CreatePlayer();
        PlayersManager.instance.AddSkin(a, 3);
        CharacterSelectionManager.instance.selectedCount++;
        Player b = PlayersManager.instance.CreatePlayer();
        PlayersManager.instance.AddSkin(b, 2);
        CharacterSelectionManager.instance.selectedCount++;
    }
}
