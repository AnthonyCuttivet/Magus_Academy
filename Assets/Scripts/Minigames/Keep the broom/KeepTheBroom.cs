using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using System.Linq;
using TMPro;
using DG.Tweening;

public class KeepTheBroom : MonoBehaviour
{
    public PlayerKTB[] players;
    public Transform[] playersHand;
    public Transform broom;
    Collider2D broomCollider;
    public PlayerKTB broomHolder;
    public float pickUpDistance;
    bool broomIsHold;
    public Vector3 broomHoldingPosition;
    public float targetHoldingTime;
    public Vector3 broomHoldingOrientation;
    public Vector2 broomSpawnPosition;
    public BarFiller scoreP1, scoreP2,scoreP3,scoreP4;
    public InputActionAsset actions;
    public static KeepTheBroom instance;
    public Material[] skinsDatabase;
    public List<Material> skinToUse = new List<Material>();
    public List<Player> playersInfos = new List<Player>();
    public enum KTB_States{
        BEFORE_GAME,
        IN_GAME,
        AFTER_GAME,
    }
    public KTB_States KTB_State = KTB_States.BEFORE_GAME;
    bool endGameReveal;
    public GameObject countDown;
    public TextMeshProUGUI winText;
    Tween broomMoveYLoop;
    public int maximumScore;



    void Awake(){
        if(instance == null && instance != this){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        broomCollider = broom.GetComponent<Collider2D>();
        playersInfos = PlayersManager.instance.playersList;
        foreach(Player player in playersInfos){
            skinToUse.Add(skinsDatabase[player.Skin]);
        }
        //IgnoreCollisionsPlayers();
        AssignControllerToPlayer();
        //SoloSceneAssign();
        SetTimeScoreText();
        broomMoveYLoop = StartBroomLevitation();
    }

    void Update(){
        switch(KTB_State){
            case KTB_States.BEFORE_GAME :
                switch(countDown.GetComponent<Countdown>().cdState){
                    case Countdown.COUNTDOWN_STATES.BEFORE_CD :
                        countDown.GetComponent<Countdown>().cdState = Countdown.COUNTDOWN_STATES.IN_CD;
                    break;
                    case Countdown.COUNTDOWN_STATES.AFTER_CD :
                        //StartMusic();
                        KTB_State = KTB_States.IN_GAME;
                    break;
                }
            
            break;
            case KTB_States.IN_GAME :
                if(broomIsHold){
                    if(broomHolder.dead){
                        DropBroom(broomHolder);
                    }
                    else{
                        IncreaseHoldingTime(); 
                        UpdateScoreText();
                        if(broomHolder.broomHoldingTime >= targetHoldingTime){
                            KTB_State = KTB_States.AFTER_GAME;
                        }
                    }
                }
            break;
            case KTB_States.AFTER_GAME :
                if(!endGameReveal){
                    endGameReveal = true;
                    StartCoroutine(FadeWinText());
                    SetFinalScore();
                    ToNextScreen();
                }
            break;
    }
    }

    public void PickUpBroomFromGround(PlayerKTB player){ 
                broomMoveYLoop.Kill();
                broomIsHold = true;
                broomHolder = player;  
                broomHolder.holdingBroom = true; 
                broomHolder.airJumpCount += 1;
                broomHolder.maxAirJumpCount +=1;
                broom.parent = playersHand[player.playerNumber];
                broom.localPosition = broomHoldingPosition;
               
                broom.GetComponent<Rigidbody2D>().isKinematic = true;  
    }
     public void DropBroom(PlayerKTB target){
        target.airJumpCount -= 1;
        target.maxAirJumpCount -=1;
        target.holdingBroom = false;
        //broomHolder = (PlayerKTB)broomHolder.knockBacker;
        //broomHolder.airJumpCount += 1;
        //broomHolder.maxAirJumpCount +=1;
        //broomHolder.holdingBroom = true;
        //broom.localPosition = broomHoldingPosition;
        broom.parent = null;
        broom.GetComponent<Rigidbody2D>().isKinematic = false;
        broomHolder = null;
        broomIsHold = false;
        broomMoveYLoop = StartBroomLevitation();
    }

    public void StealBroom(PlayerKTB stealer, PlayerKTB target){
        broomMoveYLoop.Kill();
        target.airJumpCount -= 1;
        target.maxAirJumpCount -=1;
        target.holdingBroom = false;
        broomHolder = stealer;
        broomHolder.airJumpCount += 1;
        broomHolder.maxAirJumpCount +=1;
        broomHolder.holdingBroom = true;
        broom.parent = broomHolder.transform;
        broom.localPosition = broomHoldingPosition;
    }
    public void BroomRespawn(){
        if(broomIsHold){
            DropBroom(broomHolder);
        }
        broom.transform.position = broomSpawnPosition;
    }
    Tween StartBroomLevitation(){
        Tween tmpTween = broom.DOMoveY(broom.position.y + .5f,1f).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
        return tmpTween;
    }
    void IncreaseHoldingTime(){
        if(broomIsHold){
            broomHolder.broomHoldingTime += Time.deltaTime;
            if(broomHolder.broomHoldingTime > targetHoldingTime){
                broomHolder.broomHoldingTime = targetHoldingTime;
            }
        }      
    }

    void IgnoreCollisionsPlayers(){
        foreach(PlayerKTB player in players){
            foreach(PlayerKTB player2 in players){
                if(player.collid != player2.collid){
                    //Physics2D.IgnoreCollision(player.collid, player2.collid);
                }
            }
            Physics2D.IgnoreCollision(player.collid, broomCollider); 
        }
    }

    void UpdateScoreText(){
        scoreP1.ChangeFillAmount(players[0].broomHoldingTime);
        scoreP2.ChangeFillAmount(players[1].broomHoldingTime);
        scoreP3.ChangeFillAmount(players[2].broomHoldingTime);
        scoreP4.ChangeFillAmount(players[3].broomHoldingTime);
    }
    void SetTimeScoreText(){
        scoreP1.maxAmount = targetHoldingTime;
        scoreP2.maxAmount = targetHoldingTime;
        scoreP3.maxAmount = targetHoldingTime;
        scoreP4.maxAmount = targetHoldingTime;
    }
    public void SetBroomOrientation(){
        broom.localRotation = new Quaternion(broomHoldingOrientation.x,broomHoldingOrientation.y,broomHoldingOrientation.z,broom.rotation.w);
    }
    void AssignControllerToPlayer(){
        Color[] colors = GameObject.Find("PlayersManager").GetComponent<DebugIcons>().colors;
        foreach(Player player in playersInfos){
            GameObject currentPlayerGO = players.Single(x => x.playerNumber == player.Id).gameObject;
            ApplySkin(currentPlayerGO,skinToUse[player.Id]);
            PlayerInput playerInput = currentPlayerGO.AddComponent<PlayerInput>();
            playerInput.actions = Instantiate(actions);
            playerInput.actions.Enable();
            playerInput.SwitchCurrentActionMap("Dead");
            playerInput.currentActionMap.Disable();
            playerInput.SwitchCurrentActionMap("Alive");
            playerInput.user.UnpairDevices();
            playerInput.GetComponent<KTB_Player>().playerInput = playerInput;
            InputUser.PerformPairingWithDevice(playersInfos[player.Id].device,playerInput.user);
        }   
    }
    public void ApplySkin(GameObject obj, Material skin){
        foreach(Transform g in obj.transform.Find("Chibi_Mesh")){
            if(g.name != "Chibi_Character"){
                g.GetComponent<SkinnedMeshRenderer>().material = skin;
            }
        }
    }

    public void ToNextScreen(){
        //Switch to next scene
        switch(PlayersManager.instance.gamemode){
            case PlayersManager.Gamemodes.Single :
                BlackFade.instance.FadeOutToScene("FinalWinnerScreen");
            break;
            case PlayersManager.Gamemodes.Tournament :
                PlayersManager.instance.T_ShowScoreboardScene();
            break;
        }
    }


    IEnumerator FadeWinText(){
        winText.text = "VICTORY";
        //winText.text = skinsDatabase[playersInfos[broomHolder.playerNumber].Skin].name;
        winText.transform.DOScale(1,1f).SetEase(Ease.OutBounce);
        yield return winText.DOFade(1,1).SetEase(Ease.InOutSine).WaitForCompletion();
        winText.transform.DOScale(1.1f,.8f).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }
    void SetFinalScore(){
        Dictionary<int,int> KTBscore = new Dictionary<int,int>();
        KTBscore.Add(0,0);
        KTBscore.Add(1,0);
        KTBscore.Add(2,0);
        KTBscore.Add(3,0);
        foreach(PlayerKTB player in players){
            KTBscore[player.playerNumber] =(int) (maximumScore * (player.broomHoldingTime/targetHoldingTime));
        }
        PlayersManager.instance.globalRanking[PlayersManager.Minigames.KTB] = KTBscore;
        PlayersManager.instance.UpdateTotals(PlayersManager.Minigames.KTB);
    }
    void SoloSceneAssign(){
        PlayerInput playerInput = players[0].gameObject.AddComponent<PlayerInput>();
        playerInput.actions = Instantiate(actions);
        playerInput.actions.Enable();
        playerInput.SwitchCurrentActionMap("Dead");
        playerInput.currentActionMap.Disable();
        playerInput.SwitchCurrentActionMap("Alive");
        playerInput.GetComponent<KTB_Player>().playerInput = playerInput;
    }

}


 
