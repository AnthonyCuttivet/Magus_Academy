using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersManager : MonoBehaviour {

    public enum Minigames{
        Map,
        Deceived,
        DF,
        MNG3,
        MNG4,
        MNG5
    }


    public static PlayersManager instance;

    [SerializeField]
    public List<Player> playersList = new List<Player>();

    public Minigames nextMinigame;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);  
        }
        DontDestroyOnLoad(gameObject);
    }

    public Player CreatePlayer(){
        Player p = new Player(playersList.Count, -1);
        playersList.Add(p);
        Debug.Log("Created Player " + p.Id);
        return p;
    }

    public void AddSkin(Player p, int skin){
        p.Skin = skin;
        if(skin != 0){
            CharacterSelectionManager.instance.selectedSkins.Add(skin);
        }
        CharacterSelectionManager.instance.selectedCount++;
        foreach(Transform g in CharacterSelectionManager.instance.characters[p.Id].transform.GetChild(0)){
            if(g.name != "Chibi_Character"){
                g.GetComponent<SkinnedMeshRenderer>().material = CharacterSelectionManager.instance.skins[skin];
            }
        }
        CharacterSelectionManager.instance.characters[p.Id].SetActive(true);
        Debug.Log("Skin " + p.Skin + " has been set to Player " + p.Id);
        gameObject.transform.Find("DebugIcons").gameObject.GetComponent<DebugIcons>().AddDebugIcon(p.Id, p.Skin);
    }

    public void RemoveSkin(Player p){
        CharacterSelectionManager.instance.selectedSkins.Remove(p.Skin);
        CharacterSelectionManager.instance.selectedCount--;
        CharacterSelectionManager.instance.characters[p.Id].SetActive(false);
        p.Skin = -1;
        Debug.Log("Skin has been removed from Player " + p.Id);
    }
}
