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
    public int score = 0;
    public int combo = 0;
    Vector3 spriteSize;

    void Start(){
        score = DragonsManager.instance.dragonsScoreboard[0];
        scoreText.text = score.ToString();
        spriteSize = Touches[0].spriteTouche.transform.localScale;
        GenerateQteList();
    }

    void Update(){
        score = DragonsManager.instance.dragonsScoreboard[0];
        if(Input.GetKeyDown(KeyCode.A)){
            QTE_List.RemoveAt(0);
            Destroy(TouchesGO[0]);
            TouchesGO.RemoveAt(0);
            GenerateQteList();
        }
        scoreText.text = "Score : " + score.ToString() + "\nCombos : " + combo.ToString();
    }
    void GenerateQteList(){
        QTE_List = new List<Touche>();
        int randomRange = Touches.Count;
/*         for(int i = 0; i<lengthOfQTE;i++){
            QTE_List.Add(Touches[Random.Range(0,randomRange)]);
        } */
        PickRandomInputs(randomRange);
        DisplayQTE_List();
    }

    void PickRandomInputs(int maxRange){
        List<int> lastPicked = new List<int>();
        for (int i = 0; i < lengthOfQTE; i++){
            int index = Random.Range(0,maxRange);
            while(lastPicked.Contains(index)){
                index = Random.Range(0,maxRange);
            }
            lastPicked.Add(index);
            QTE_List.Add(Touches[index]);
        }
    }

    void RightInput(){
        combo++;
        UpdateQTE();
    }

    void MissInput(){
        combo = 0;
        GenerateQteList();
        //TODO Voir quoi faire en cas de missInput : Continuer le QTE ? Mort instant ? Le poisson se barre ?
    }

    void OnB(){
        if(QTE_List[0].equals(Touche.Touches.B)){
            RightInput();
        }
        else{
            MissInput();
        }
    }
    void OnA(){
        if(QTE_List[0].equals(Touche.Touches.A)){
            RightInput();
        }
        else{
            MissInput();
        }
    }
    void OnX(){
        if(QTE_List[0].equals(Touche.Touches.X)){
            RightInput();
        }
        else{
            MissInput();
        }
    }
    void OnY(){
        if(QTE_List[0].equals(Touche.Touches.Y)){
            RightInput();
        }
        else{
            MissInput();
        }
    }

    void OnUp(){
        if(QTE_List[0].equals(Touche.Touches.UP)){
            RightInput();
        }
        else{
            MissInput();
        }
    }
    void OnDown(){
        if(QTE_List[0].equals(Touche.Touches.DOWN)){
            RightInput();
        }
        else{
            MissInput();
        }
    }
    void OnLeft(){
        if(QTE_List[0].equals(Touche.Touches.LEFT)){
            RightInput();
        }
        else{
            MissInput();
        }
    }
    void OnRight(){
        if(QTE_List[0].equals(Touche.Touches.RIGHT)){
            RightInput();
        }
        else{
            MissInput();
        }
    }
    void DisplayQTE_List(){
        ResetTouchesGO();
        int spriteGenerated = 0;
        foreach(Touche touche in QTE_List){
            Vector2 spawnPos = new Vector2(startPos.x + spriteSize.x * spriteGenerated,startPos.y);
            TouchesGO.Add(Instantiate(touche.spriteTouche,(Vector2)transform.position + spawnPos,transform.rotation));
            spriteGenerated++;
        }
    }
    void UpdateQTE(){
        if(QTE_List.Count == 1){
            DragonsManager.instance.AddPoints(0,DragonsManager.instance.dragonsScoreboard[0] += (1*(combo + 1)));
            //score += 1 * (combo + 1);
            Debug.Log("End of QTE. Score : " + DragonsManager.instance.dragonsScoreboard[0]);
            GenerateQteList();      //QTE fini
        }
        else{
            QTE_List.RemoveAt(0);
            Destroy(TouchesGO[0]);
            TouchesGO.RemoveAt(0);
            foreach(GameObject touche in TouchesGO){
                touche.transform.position -= new Vector3(spriteSize.x,0,0);
            }
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
    public enum Touches { A, B, X, Y, UP, DOWN, LEFT, RIGHT};
    public Touches touches;

    public bool equals(Touches enumT){
        return touches == enumT;
    }
}
