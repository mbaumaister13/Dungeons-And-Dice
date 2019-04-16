using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    static Vector3 camSavePos;
    static Quaternion camSaveRot;
    static GameObject playerCamera;
    Vector3 initialCamPosition;
    Board board;
    public float boardMoveSpeed;
    public float attackSpeed = 1f, attackTimer = 1f;
    public float invincibilityTimer = 0f, invincibilityTime = 0.3f; 
    public bool isInvincible = false;
    public int hp = 100, gold = 0, damage = 10;
    public float strength = 1.0f;
    public int currentTile = -1;
    public int spacesToMove = 0;
    public Dice dice;
    private Animator animator;
    bool isIdle;
    public MeterManager meterManager;
    public int dungeonCount = 0;
    TextMeshProUGUI HealthText, StrengthText, GoldText;

    // Update is called once per frame
    void Start(){
        HealthText = meterManager.transform.Find("PlayerMeters").transform.Find("Health").gameObject.GetComponent<TextMeshProUGUI>(); 
        StrengthText = meterManager.transform.Find("PlayerMeters").transform.Find("Strength").gameObject.GetComponent<TextMeshProUGUI>(); 
        GoldText = meterManager.transform.Find("PlayerMeters").transform.Find("Gold").gameObject.GetComponent<TextMeshProUGUI>(); 
        Physics.IgnoreCollision(GetComponent<Collider>(),dice.gameObject.GetComponent<Collider>());
        playerCamera = transform.GetChild(3).gameObject;
        initialCamPosition = playerCamera.transform.position;
        animator = GetComponent<Animator>();
        animator.SetInteger("animation",13);
        board = GameObject.Find("Board").GetComponent<Board>();
        //PlayerManager.instance.savePlayer(PlayerManager.instance.player.GetComponent<Player>());
    }
    void Update()
    {
        HealthText.SetText("Health: " + hp + " hp");
        StrengthText.SetText("Strength: x" + strength);
        GoldText.SetText("Gold: " + gold);
        if(playerCamera.gameObject.activeInHierarchy){
            if(dice.value!=0&&spacesToMove==0){
                spacesToMove = dice.value;
            }
            if(spacesToMove!=0){
                if(animator.GetInteger("animation")!=20){
                    animator.SetInteger("animation",20);
                    isIdle = false;
                    playerCamera.transform.SetPositionAndRotation(camSavePos,camSaveRot);
                    // Debug.Log(camSaveState.position);
                }
                transform.position = Vector3.MoveTowards(transform.position,board.tiles[currentTile+1].transform.position,Time.deltaTime*boardMoveSpeed);
                Vector3 lookPos = board.tiles[currentTile+1].transform.GetChild(1).transform.position - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPos), Time.deltaTime*2f);
            }
            else{
                if(!isIdle){
                    isIdle = true;
                    saveCamState();
                    // Debug.Log(camSaveState.position);
                }
                playerCamera.transform.LookAt(transform);
                playerCamera.transform.Translate(Vector3.right * Time.deltaTime);
            }
            try {
                if(board.tiles[currentTile+1].hasVisited){
                    currentTile++;
                    spacesToMove--;
                    if(spacesToMove==0){
                        dice.Reset();
                        animator.SetInteger("animation",13);
                    }
                }
            } catch (Exception e) {
                Debug.Log("End tile shit gang");
            }
        }
    }
    public static void saveCamState(){
        camSavePos = playerCamera.transform.position;
        camSaveRot = playerCamera.transform.rotation;
    }
}
