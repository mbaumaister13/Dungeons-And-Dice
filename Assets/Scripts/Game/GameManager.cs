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
    public UIManager UI;
    // Start is called before the first frame update
    void Start()
    {
        UI.GetComponentInChildren<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void pause() {
        if (UI.GetComponentInChildren<Canvas>().enabled) {
            UI.GetComponentInChildren<Canvas>().enabled = false;
        }
        else {
            UI.GetComponentInChildren<Canvas>().enabled = true;
        }
    }
}
