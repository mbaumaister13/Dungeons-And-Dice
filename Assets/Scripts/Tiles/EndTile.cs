using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndTile : Tile
{
    public override void execute(){
        Debug.Log("Activating End Tile");       
        winText.enabled = true;
    }
    void Update() {
        winText.color = new Color(1.0f,Random.Range(0f,1.0f),0.0f); 
    }
}
