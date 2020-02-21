using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerCursor : MonoBehaviour
{

    private RaycastHit2D hit;
    public int currentSelection = -1;
    public bool hasSelected = false;
    public bool playerCreated = false;
    public float speed = 10f;
    public Player currentPlayer;
    public GameObject PlayersManagerGO;
    private Vector2 vel;
    private Rigidbody rb;
    SoundManager soundManager;
    PlayerInput pInput;
    public float vibratingTime;
    public bool isVibrating = false;

    void OnEnable(){
        pInput = gameObject.GetComponent<PlayerInput>();
        pInput.actions.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!playerCreated){
            playerCreated = true;
            currentPlayer = PlayersManager.instance.CreatePlayer();
            currentPlayer.device = pInput.user.pairedDevices[0];
            Color fullColor = CharacterSelectionManager.instance.cursors[currentPlayer.Id];
            gameObject.GetComponent<SpriteRenderer>().color = new Color(fullColor.r, fullColor.g, fullColor.b);

            rb = gameObject.GetComponent<Rigidbody>();

            //Set banner
            CharacterSelectionManager.instance.banners[currentPlayer.Id].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }
        soundManager = SoundManager.instance;
    }

    // Update is called once per frame
    void Update(){
        if(pInput == null){
            pInput = gameObject.GetComponent<PlayerInput>();
        }
    }

    void FixedUpdate(){
        //Movement
        rb.velocity = vel * speed;
        if(hasSelected){
            rb.velocity = Vector2.zero;
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        hit = Physics2D.Raycast(transform.position, forward, 10f);
        if(hit.collider != null){
            currentSelection = hit.collider.transform.gameObject.GetComponent<CharacterAttribute>().attributeID;
            CharacterSelectionManager.instance.banners[currentPlayer.Id].GetComponent<Image>().sprite = GetComponent<Magesnames>().banners[currentSelection];
        }else{
            currentSelection = -1;
            CharacterSelectionManager.instance.banners[currentPlayer.Id].GetComponent<Image>().sprite = GetComponent<Magesnames>().banners[0];
        }
    }

    void OnMove(InputValue value){
        if(!hasSelected){
            vel = value.Get<Vector2>();
            if(vel.magnitude < .2f){
                vel = Vector2.zero;
            }
        }else{
            vel = Vector2.zero;
        }
    }

    public void VibrateController(float l, float r, float t){
        pInput.user.pairedDevices[0].MakeCurrent();
        Gamepad.current.SetMotorSpeeds(l,r);
        StartCoroutine(StopVibrationAfterSeconds(t));
    }

    IEnumerator StopVibrationAfterSeconds(float seconds){
        yield return new WaitForSeconds(seconds);
        pInput.user.pairedDevices[0].MakeCurrent();
        Gamepad.current.PauseHaptics();
    }

    void OnValidate(){
        if(currentSelection != -1 && !hasSelected && CharacterSelectionManager.instance.lockSelection == false){
            if(CharacterSelectionManager.instance.selectedSkins.Contains(currentSelection) && currentSelection != 0){
                //Skin already selected
            }
            else{
                if(CharacterSelectionManager.instance.announcer){
                    SoundManager.instance.PlaySound("CS"+currentSelection);
                }
                hasSelected = true;
                PlayersManager.instance.AddSkin(currentPlayer, currentSelection);
                if(CharacterSelectionManager.instance.selectedCount < 4){
                    VibrateController(CharacterSelectionManager.instance.CS_LvibrationForce, CharacterSelectionManager.instance.CS_RvibrationForce, CharacterSelectionManager.instance.CS_vibrationTime);
                }
                //Set banner alpha to 1
                ChangeBannerAlpha(1f);
                GetComponent<Collider>().isTrigger = true;
                soundManager.PlaySound("Menu_Validate");
            }
        }else if(hasSelected && CharacterSelectionManager.instance.ready != true){
            hasSelected = false;
            PlayersManager.instance.RemoveSkin(currentPlayer);
            ChangeBannerAlpha(.4f);
            GetComponent<Collider>().isTrigger = false;
            soundManager.PlaySound("Menu_Return");
        }
    }

    void OnBack(){
        if(CharacterSelectionManager.instance.ready != true){
            PlayersManager.instance.ResetPlayers();
            CharacterSelectionManager.instance.Return();
        }

/*         if(hasSelected){
            hasSelected = false;
            PlayersManager.instance.RemoveSkin(currentPlayer);
            ChangeBannerAlpha(.4f);
            GetComponent<Collider>().isTrigger = false;
            soundManager.PlaySound("Menu_Return");
        } */
    }

    void OnReady(){
        if(CharacterSelectionManager.instance.cSState == CharacterSelectionManager.CSStates.ALL_SELECTED){
            CharacterSelectionManager.instance.ready = true;
        }
    }

    void OnSkip(){
        CharacterSelectionManager.instance.selectedCount = 4;
        CharacterSelectionManager.instance.ready = true;
    }

    void OnToggleDance(){
        CharacterSelectionManager.instance.announcer = !CharacterSelectionManager.instance.announcer;
    }

    void ChangeBannerAlpha(float value){
        var banner = CharacterSelectionManager.instance.banners[currentPlayer.Id].GetComponent<Image>();
        var tempColor = banner.color;
        tempColor.a = value;
        banner.color = tempColor;
    }



}
