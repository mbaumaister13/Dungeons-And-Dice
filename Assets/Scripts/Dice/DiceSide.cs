using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
    public int sideValue;
    bool onBoard = false;
    void OnTriggerStay(Collider col){
        if(col.tag == "Board"){
            onBoard = true;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Board"){
            onBoard = false;
        }
    }

    public bool isOnBoard(){
        return onBoard;
    }
}
