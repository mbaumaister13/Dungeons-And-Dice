using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterManager : MonoBehaviour
{
    private void Start() {
        GameManager.meterManager = this;
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
