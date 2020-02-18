using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using TMPro;

public class QTE : MonoBehaviour
{
    public enum QTE_STATES{
        IN_QTE,
        NOT_IN_QTE
    }

    public QTE_STATES qteState;

    public GameObject QTEGO;
    public List<Touche> touches;
    public Dictionary<int,List<Touche>> qteSequences = new Dictionary<int, List<Touche>>();
    public int currentSequence = 0;
    public int currentIndexInSequence = 0;
    public AimController aimController;

    [Space]
    [Header("Scoring")]
    public int score = 0;
    public int combo = 1;
    public int id;

    [Space]
    [Header("UI")]
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI comboTMP;
    public Sprite dot;

    [Space]
    [Header("Controller Vibration")]

    public float LvibrationForce = 0.1f;
    public float RvibrationForce = 1;
    public float vibrationTime = .2f;

    // Start is called before the first frame update
    void Start(){
        QTEGO = gameObject.transform.Find("QTE").gameObject;
    }

    // Update is called once per frame
    void Update(){

    }

    public void StartQTE(){
        //Set INQTE State
        qteState = QTE_STATES.IN_QTE;
        //Generate touches sequence x3
        GenerateSequences();
        //Display first sequence touches
        DisplayQTESequence(qteSequences[currentSequence]);
    }

    public void UpdateQTE(){
        switch(qteState){
            case QTE_STATES.IN_QTE : 
                AddScore();
                if(currentIndexInSequence == (DragonsManager.instance.QTELength -1)){ //If last input
                    if(currentSequence == (DragonsManager.instance.qteStreak - 1)){ //Of last sequence
                        currentIndexInSequence = 0;
                        currentSequence = 0;
                        ResetCombo();
                        qteState = QTE_STATES.NOT_IN_QTE;
                        aimController.EndFishing();
                    }else{ //Of any sequence but the last
                        currentIndexInSequence = 0;
                        currentSequence++;
                        DisplayQTESequence(qteSequences[currentSequence]);
                    }
                }else{ //If not last input of the sequence
                    currentIndexInSequence++;
                }
            break;
        }
    }


#region Utils

    public void RightInput(){
        GameObject currentToucheGO = QTEGO.transform.GetChild(currentIndexInSequence).gameObject;
        currentToucheGO.GetComponent<SpriteRenderer>().sprite = dot; //Change sprite on success

        //Play sound
        SoundManager.instance.PlaySound("QTE2");

        //Vibrate controller
        VibrateController();

        UpdateQTE();
    }

    public void MissInput(){
        SoundManager.instance.PlaySound("QTEWrong");
        ResetCombo();
    }

    public void VibrateController(){
        gameObject.GetComponent<PlayerInput>().user.pairedDevices[0].MakeCurrent();
        Gamepad.current.SetMotorSpeeds(LvibrationForce,RvibrationForce);
        StartCoroutine(StopVibrationAfterSeconds(vibrationTime));
    }

    IEnumerator StopVibrationAfterSeconds(float seconds){
        yield return new WaitForSeconds(seconds);
        gameObject.GetComponent<PlayerInput>().user.pairedDevices[0].MakeCurrent();
        Gamepad.current.PauseHaptics();
    }

    void AddScore(){
        AddCombo();
        int pts = DragonsManager.instance.sequenceMultiplier * combo * aimController.isFishing.pointsMultiplier;
        score += pts;
        DragonsManager.instance.dragonsScoreboard[id] = score;
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay(){
        scoreTMP.text = score.ToString();
    }

    void AddCombo(){
        combo += DragonsManager.instance.comboScale;
        //visual Display
        UpdateComboDisplay();
    }

    void UpdateComboDisplay(){
        comboTMP.text = "x"+combo.ToString();
    }

    void ResetCombo(){
        combo = 1;
        UpdateComboDisplay();
    }

    public void DisplayQTESequence(List<Touche> sequence){
        int currentTouche = 0;
        foreach (Touche t in sequence){
            QTEGO.transform.GetChild(currentTouche).GetComponent<SpriteRenderer>().sprite = t.spriteTouche;
            currentTouche++;
        }
    }

    //Generate sequences
    public void GenerateSequences(){
        qteSequences.Clear();
        for(int i = 0; i < DragonsManager.instance.qteStreak; i++){
           qteSequences.Add(i, PickRandomInputs(touches.Count));
        }
    }
    
    public List<Touche> PickRandomInputs(int maxRange){
        List<Touche> listToReturn = new List<Touche>();
        List<int> lastPicked = new List<int>();
        for (int i = 0; i < DragonsManager.instance.QTELength; i++){
            int index = Random.Range(0,maxRange);
            while(lastPicked.Contains(index)){
                index = Random.Range(0,maxRange);
            }
            lastPicked.Add(index);
            listToReturn.Add(touches[index]);
        }
        return listToReturn;
    }    

#endregion

#region Inputs

    void OnB(){
            if(qteState == QTE_STATES.IN_QTE && DragonsManager.instance.dfState == DragonsManager.DFStates.IN_GAME){
                if(qteSequences[currentSequence][currentIndexInSequence].equals(Touche.Touches.B)){
                    RightInput();
                }
                else{
                    MissInput();
                }
            }
        }
        void OnA(){
            if(qteState == QTE_STATES.IN_QTE && DragonsManager.instance.dfState == DragonsManager.DFStates.IN_GAME){
                if(qteSequences[currentSequence][currentIndexInSequence].equals(Touche.Touches.A)){
                    RightInput();
                }
                else{
                    MissInput();
                }
            }
        }
        void OnX(){
            if(qteState == QTE_STATES.IN_QTE && DragonsManager.instance.dfState == DragonsManager.DFStates.IN_GAME){
                if(qteSequences[currentSequence][currentIndexInSequence].equals(Touche.Touches.X)){
                    RightInput();
                }
                else{
                    MissInput();
                }
            }
        }
        void OnY(){
            if(qteState == QTE_STATES.IN_QTE && DragonsManager.instance.dfState == DragonsManager.DFStates.IN_GAME){
                if(qteSequences[currentSequence][currentIndexInSequence].equals(Touche.Touches.Y)){
                    RightInput();
                }
                else{
                    MissInput();
                }
            }
        }

        void OnUp(){
            if(qteState == QTE_STATES.IN_QTE && DragonsManager.instance.dfState == DragonsManager.DFStates.IN_GAME){
                if(qteSequences[currentSequence][currentIndexInSequence].equals(Touche.Touches.UP)){
                    RightInput();
                }
                else{
                    MissInput();
                }
            }
        }
        void OnDown(){
            if(qteState == QTE_STATES.IN_QTE && DragonsManager.instance.dfState == DragonsManager.DFStates.IN_GAME){
                if(qteSequences[currentSequence][currentIndexInSequence].equals(Touche.Touches.DOWN)){
                    RightInput();
                }
                else{
                    MissInput();
                }
            }
        }
        void OnLeft(){
            if(qteState == QTE_STATES.IN_QTE && DragonsManager.instance.dfState == DragonsManager.DFStates.IN_GAME){
                if(qteSequences[currentSequence][currentIndexInSequence].equals(Touche.Touches.LEFT)){
                    RightInput();
                }
                else{
                    MissInput();
                }
            }
        }

        void OnRight(){
            if(qteState == QTE_STATES.IN_QTE && DragonsManager.instance.dfState == DragonsManager.DFStates.IN_GAME){
                if(qteSequences[currentSequence][currentIndexInSequence].equals(Touche.Touches.RIGHT)){
                    RightInput();
                }
                else{
                    MissInput();
                }
            }
        }

        void OnAim(InputValue value){
            if(qteState == QTE_STATES.NOT_IN_QTE && Countdown.instance.cdState == Countdown.COUNTDOWN_STATES.AFTER_CD && DragonsManager.instance.dfState == DragonsManager.DFStates.IN_GAME){
                Vector2 aimDirection = value.Get<Vector2>();
                if(aimDirection.magnitude > .2f){
                    aimController.direction = aimDirection;
                }
                else{
                    aimController.direction = Vector2.zero;
                }
                
            }
        }
        void OnFish(){
            if(qteState == QTE_STATES.NOT_IN_QTE && Countdown.instance.cdState == Countdown.COUNTDOWN_STATES.AFTER_CD && DragonsManager.instance.dfState == DragonsManager.DFStates.IN_GAME){
                aimController.Fish();
            }
        }

#endregion




    

[System.Serializable]
public class Touche{
    public Sprite spriteTouche;
    public enum Touches { A, B, X, Y, UP, DOWN, LEFT, RIGHT};
    public Touches touches;

    public bool equals(Touches enumT){
        return touches == enumT;
    }
}
}

