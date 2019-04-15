using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    public string tileType;
    public int tileIndex;
    public bool hasVisited;
    protected PlayerController player;
    void Start(){
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
    }
    public virtual void execute(){
        Debug.Log("Activiating Normal Tile");
        Player.gold += 5;
    }
}