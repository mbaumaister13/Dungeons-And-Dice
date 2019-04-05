using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State {BAORD,DUNGEON,SHOP};
    public static State gameState = State.BAORD;
    public static int numPlayers;
    public static Player[] players;
    public static Dice dice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape")) {
            Application.Quit();
        } 
    }
}
