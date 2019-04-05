using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    protected PlayerController player;

    void Start(){
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
    }
    public void Enable(string name){
        foreach(Transform t in transform){
            if(t.name == name){
                t.gameObject.SetActive(true);
            }
        }
    }
    public void Disable(string name){
        foreach(Transform t in transform){
            if(t.name == name){
                t.gameObject.SetActive(false);
            }
        }
    }
}
