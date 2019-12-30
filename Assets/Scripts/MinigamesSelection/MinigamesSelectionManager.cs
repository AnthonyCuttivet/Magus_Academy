using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MinigamesSelectionManager : MonoBehaviour
{

    public string selectedMinigame;

    void OnEnable(){
        gameObject.GetComponent<PlayerInput>().actions.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selectedMinigame = EventSystem.current.currentSelectedGameObject.name;
    }

    void OnA(){
        PlayersManager.instance.nextMinigame = (PlayersManager.Minigames)System.Enum.Parse( typeof(PlayersManager.Minigames), selectedMinigame);
        SceneManager.LoadScene("CommandsScreen");
    }
}
