using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KillPNJ : MonoBehaviour
{

    public float interval = 1f;
    private bool killing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(killing == false && CharactersSpawner.instance.gameStart){
            StartCoroutine(RemovePNJ());
            killing = true;
        }
    }

    IEnumerator RemovePNJ(){
        while(CharactersSpawner.instance.PNJList.Count > 0){
            yield return new WaitForSeconds(interval);
            int rndIndex = Random.Range(0,CharactersSpawner.instance.PNJList.Count); //Get a random index in pnj id list
            CharactersSpawner.instance.PNJList.RemoveAt(rndIndex); //Remove it from the ids list
            Destroy(CharactersSpawner.instance.PNJList[rndIndex]); // Destroy it
        }
    }
}
