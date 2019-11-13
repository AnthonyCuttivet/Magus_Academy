using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DragonQTE_PlayerControls : MonoBehaviour
{


    public List<Touche> QTE_List;
    [SerializeField]
    public List<Touche> Touches;
    List<GameObject> TouchesGO = new List<GameObject>();
    public int lengthOfQTE;
    public float spacing;
    public Vector2 startPos;
    public int score = 0;
    public int combo = 0;
    public int id;
    Vector3 spriteSize;
    public AimController aimSprite;
    fishingRodRenderer fishingRod;
    public bool inQTE;


    void Awake(){
        fishingRod = GetComponentInChildren<fishingRodRenderer>();
    }
    void Start(){

        spriteSize = Touches[0].spriteTouche.transform.localScale;
        //GenerateQte();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.A)){
            QTE_List.RemoveAt(0);
            Destroy(TouchesGO[0]);
            TouchesGO.RemoveAt(0);
            //GenerateQte();
        }
        transform.LookAt(aimSprite.transform.position);
        transform.rotation = new Quaternion(0,transform.rotation.y,0,transform.rotation.w);
    }
    public void GenerateQte(Transform aimTransform){
        QTE_List = new List<Touche>();
        int randomRange = Touches.Count;
        PickRandomInputs(randomRange);
        DisplayQTE_List(aimTransform);
        inQTE = true;
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
    void DisplayQTE_List(Transform aimTransform){
        ResetTouchesGO();
        int spriteGenerated = 0;
        Vector3 startPosition = new Vector3(aimTransform.position.x - (spriteSize.x  / 2) * (QTE_List.Count - 1),aimTransform.position.y,aimTransform.position.z );
        foreach(Touche touche in QTE_List){
            Vector3 spawnPos = new Vector3(spriteSize.x * spriteGenerated,0,0);
            TouchesGO.Add(Instantiate(touche.spriteTouche,startPosition + spawnPos,aimTransform.rotation));
            spriteGenerated++;
        }
    }
    void UpdateQTE(){
        if(QTE_List.Count == 1){
            DragonsManager.instance.AddPoints(id, (1*(combo + 1)));
            Debug.Log("End of QTE. Score : " + id + "  " + DragonsManager.instance.dragonsScoreboard[id]);
            //GenerateQte();      //QTE fini
            CancelQTE();
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
    void CancelQTE(){
        QTE_List = new List<Touche>();
        foreach(GameObject go in TouchesGO){
            Destroy(go);
        }
        TouchesGO = new List<GameObject>();
        inQTE = false;
    }
        void RightInput(){
        combo++;
        UpdateQTE();
    }

    void MissInput(){
        combo = 0;
        //GenerateQte();
        //TODO Voir quoi faire en cas de missInput : Continuer le QTE ? Mort instant ? Le poisson se barre ?
        CancelQTE();
    }
    void ResetTouchesGO(){
        foreach(GameObject GO in TouchesGO){
            Destroy(GO);
        }
        TouchesGO = new List<GameObject>();
    }
    void OnB(){
        if(inQTE){
            if(QTE_List[0].equals(Touche.Touches.B)){
                RightInput();
            }
            else{
                MissInput();
            }
        }
    }
    void OnA(){
        if(inQTE){
            if(QTE_List[0].equals(Touche.Touches.A)){
                RightInput();
            }
            else{
                MissInput();
            }
        }
    }
    void OnX(){
        if(inQTE){
            if(QTE_List[0].equals(Touche.Touches.X)){
                RightInput();
            }
            else{
                MissInput();
            }
        }
    }
    void OnY(){
        if(inQTE){
            if(QTE_List[0].equals(Touche.Touches.Y)){
                RightInput();
            }
            else{
                MissInput();
            }
        }
    }

    void OnUp(){
        if(inQTE){
            if(QTE_List[0].equals(Touche.Touches.UP)){
                RightInput();
            }
            else{
                MissInput();
            }
        }
    }
    void OnDown(){
        if(inQTE){
            if(QTE_List[0].equals(Touche.Touches.DOWN)){
                RightInput();
            }
            else{
                MissInput();
            }
        }
    }
    void OnLeft(){
        if(inQTE){
            if(QTE_List[0].equals(Touche.Touches.LEFT)){
                RightInput();
            }
            else{
                MissInput();
            }
        }
    }
    void OnRight(){
        if(inQTE){
            if(QTE_List[0].equals(Touche.Touches.RIGHT)){
                RightInput();
            }
            else{
                MissInput();
            }
        }
    }
    void OnAim(InputValue value){
        if(!inQTE){
            Vector2 aimDirection = value.Get<Vector2>();
            aimSprite.direction = aimDirection;
        }
    }
    void OnFish(){
        if(!inQTE){
            aimSprite.Fish();
        }
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
