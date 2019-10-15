using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KillPNJ : MonoBehaviour
{

    public float interval = 1f;
    private List<int> pnjIdsList = new List<int>();
    private bool killing = false;

    // Start is called before the first frame update
    void Start()
    {
        GetPNJIds();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(killing == false && gameObject.GetComponent<CharactersSpawner>().gameStart){
            StartCoroutine(RemovePNJ());
            killing = true;
        }
    }

    public void GetPNJIds(){
        foreach (GameObject g in gameObject.GetComponent<CharactersSpawner>().pooledEntities)
        {
            pnjIdsList.Add(int.Parse(g.name));
        }
    }

    IEnumerator RemovePNJ(){
        while(gameObject.GetComponent<CharactersSpawner>().pooledEntities.Count > 0){
            yield return new WaitForSeconds(interval);
            int rndIndex = Random.Range(0,pnjIdsList.Count); //Get a random index in pnj id list
            int idToKill = int.Parse(gameObject.GetComponent<CharactersSpawner>().pooledEntities[rndIndex].name); // get corresponding pnj id
            pnjIdsList.Remove(idToKill); //Remove it from the ids list
            GameObject g = GameObject.Find("Characters/"+idToKill);
            Destroy(g); //Then destroy it
            gameObject.GetComponent<CharactersSpawner>().pooledEntities.Remove(g); //And finaly remove it from the pool
        }
    }
}
