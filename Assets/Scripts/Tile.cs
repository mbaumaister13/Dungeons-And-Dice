using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    public string tileType;
    public int tileIndex;
    public bool hasVisited;
    public virtual void execute(){
        Debug.Log("Activiating Normal Tile");
        Player.gold += 5;
    }
}