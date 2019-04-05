using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dice Roll script found from https://www.youtube.com/watch?v=JgbJZdXDNtg
public class Dice : MonoBehaviour
{
    UIManager uiManager;
    public Camera cam;
    Rigidbody rb;
    public bool hasLanded, thrown;
    public int value = 0;
    public DiceSide[] diceSides;
    Vector3 throwPosition;
    float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        throwPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!thrown&&!hasLanded){
            transform.position = cam.transform.position;
        }
        if(rb.IsSleeping() && !hasLanded && thrown){
            foreach(DiceSide d in diceSides){
                if(d.isOnBoard()){
                    value = d.sideValue;
                    hasLanded = true;
                    uiManager.Enable("DiceUI");
                }
            }
        }
    }

    public void Roll(){
        waitTime = Time.time;
        if(!hasLanded && !thrown){
            rb.AddTorque(Random.Range(0,500),Random.Range(0,500),Random.Range(0,500));
            rb.AddForce(cam.transform.forward*500);
            rb.useGravity = true;
            thrown = true;
            uiManager.Disable("DiceUI");
        }
        else if (!hasLanded && thrown && (Time.time - waitTime > 5)) {
            rb.AddForce(0, 1, 0, ForceMode.Impulse);
        }
        else if(hasLanded){
            Reset();
        }
    }
    public void Reset(){
        rb.useGravity = false;
        transform.position = cam.transform.position-throwPosition;
        hasLanded = false;
        thrown = false;
        value = 0;
    }
}
