using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonQTE_PlayerControls : MonoBehaviour
{


    public List<Touche> QTE_List;
    [SerializeField]
    public List<Touche> Touches;
    List<GameObject> TouchesGO = new List<GameObject>();
    public int lengthOfQTE;
    public float spacing;
    public Vector2 startPos;
    public Text scoreText;
    int score = 0;
    void Awake(){
        scoreText.text = score.ToString();
        GenerateQteList();
    }
    void GenerateQteList(){
        QTE_List = new List<Touche>();
        int randomRange = Touches.Count;
        for(int i = 0; i<lengthOfQTE;i++){
            QTE_List.Add(Touches[Random.Range(0,randomRange)]);
        }
        DisplayQTE_List();
        scoreText.text = score.ToString();
    }
    void OnB(){
        if(QTE_List[0].equals(Touche.Touches.B)){
            UpdateQTE();
        }
        else{
            score--;
            GenerateQteList();
        }
    }
    void OnA(){
        if(QTE_List[0].equals(Touche.Touches.A)){
            UpdateQTE();
        }
        else{
            score--;
            GenerateQteList();
        }
    }
    void OnX(){
        if(QTE_List[0].equals(Touche.Touches.X)){
            UpdateQTE();
        }
        else{
            score--;
            GenerateQteList();
        }
    }
    void OnY(){
        if(QTE_List[0].equals(Touche.Touches.Y)){
            UpdateQTE();
        }
        else{
            score--;
            GenerateQteList();
        }
    }
    void DisplayQTE_List(){
        ResetTouchesGO();
        int spriteGenerated = 0;
        foreach(Touche touche in QTE_List){
            Vector2 spawnPos = new Vector2(startPos.x + spacing * spriteGenerated,startPos.y);
            TouchesGO.Add(Instantiate(touche.spriteTouche,spawnPos,transform.rotation));
            spriteGenerated++;
        }
    }
    void UpdateQTE(){
        if(QTE_List.Count == 1){
            score++;
            GenerateQteList();      //QTE fini
        }
        else{
            QTE_List.RemoveAt(0);
            Destroy(TouchesGO[0]);
            TouchesGO.RemoveAt(0);
        }

    }
    void ResetTouchesGO(){
        foreach(GameObject GO in TouchesGO){
            Destroy(GO);
        }
        TouchesGO = new List<GameObject>();
    }

    
}
[System.Serializable]
public class Touche{
    public GameObject spriteTouche;
    public enum Touches { A, B, X, Y};
    public Touches touches;

    public bool equals(Touches enumT){
        return touches == enumT;
    }
}
