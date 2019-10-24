using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSelector : MonoBehaviour
{


    void OnEnable(){
        for (int i = 0; i < 4; i++)
        {
            Player p = PlayersManager.instance.CreatePlayer();
            PlayersManager.instance.AddSkin(p, i);
            CharacterSelectionManager.instance.selectedCount++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
