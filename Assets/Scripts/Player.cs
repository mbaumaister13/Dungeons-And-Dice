using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static Vector3 camSavePos;
    static Quaternion camSaveRot;
    static GameObject playerCamera;
    Vector3 initialCamPosition;
    Board board;
    public float moveSpeed;
    public static float attackSpeed = 1f, attackTimer = 1f; 
    public static int hp = 100, gold = 0, damage = 10;
    public static float strength = 1.0f;
    int currentTile = -1;
    public int spacesToMove = 0;
    public Dice dice;
    private Animator animator;
    bool isIdle;
    public static Text HealthText, StrengthText, GoldText;

    // Update is called once per frame
    void Start(){
        StrengthText = GameObject.Find("UI_Manager").transform.Find("Strength").gameObject.GetComponent<Text>();
        GoldText = GameObject.Find("UI_Manager").transform.Find("Gold").gameObject.GetComponent<Text>();
        Physics.IgnoreCollision(GetComponent<Collider>(),dice.gameObject.GetComponent<Collider>());
        playerCamera = transform.GetChild(3).gameObject;
        initialCamPosition = playerCamera.transform.position;
        animator = GetComponent<Animator>();
        animator.SetInteger("animation",13);
        board = GameObject.Find("Board").GetComponent<Board>();

        DontDestroyOnLoad(GameObject.Find("UI_Manager"));
    }
    void Update()
    {
        StrengthText.text = "Strength: x" + strength;
        GoldText.text = "Gold: " + gold;
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
                transform.position = Vector3.MoveTowards(transform.position,board.tiles[currentTile+1].transform.position,Time.deltaTime*moveSpeed);
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
            if(board.tiles[currentTile+1].hasVisited){
                currentTile++;
                spacesToMove--;
                if(spacesToMove==0){
                    dice.Reset();
                    animator.SetInteger("animation",13);
                }
            }
        }
    }
    public static void saveCamState(){
        camSavePos = playerCamera.transform.position;
        camSaveRot = playerCamera.transform.rotation;
    }
    public static void Damage(int damage) {
        Debug.Log("Player Health: " + hp);
        hp -= damage;
    }
}
