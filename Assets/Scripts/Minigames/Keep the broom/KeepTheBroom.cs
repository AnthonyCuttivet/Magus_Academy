using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using System.Linq;

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
    public Vector3 broomHoldingOrientation;
    public Vector2 broomSpawnPosition;
    public BarFiller scoreP1, scoreP2,scoreP3,scoreP4;
    public InputActionAsset actions;
    public static KeepTheBroom instance;
    public Material[] skinsDatabase;
    public List<Material> skinToUse = new List<Material>();
    public List<Player> playersInfos = new List<Player>();



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
        IgnoreCollisionsPlayers();
        AssignControllerToPlayer();
    }

    void Update(){
        if(broomIsHold){
            if(broomHolder.dead){
                DropBroom(broomHolder);
            }
            else{
                IncreaseHoldingTime(); 
                UpdateScoreText();
            }
        }
        else{
            PickUpBroomFromGround();
        }
    }

    void PickUpBroomFromGround(){
        foreach(PlayerKTB player in players){
            if(Vector2.Distance(player.transform.position,broom.position) < pickUpDistance && !broomIsHold && !player.knockBacked && !player.dead){
                broomIsHold = true;
                broomHolder = player;  
                broomHolder.holdingBroom = true; 
                broomHolder.airJumpCount += 1;
                broomHolder.maxAirJumpCount +=1;
                broom.parent = playersHand[player.playerNumber];
                broom.localPosition = broomHoldingPosition;
               
                broom.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }  
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
    }

    public void StealBroom(PlayerKTB stealer, PlayerKTB target){
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
    void IncreaseHoldingTime(){
        if(broomIsHold){
            broomHolder.broomHoldingTime += Time.deltaTime;
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
}


 
