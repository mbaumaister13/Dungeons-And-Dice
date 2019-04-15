using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int numPlayers;
    public static Player[] players;
    public static Dice dice;
    public static string difficult;
    public UIManager UI;
    public VendorManager vendor;
    public MeterManager meterManager;
    // Start is called before the first frame update
    void Start()
    {
        UI.GetComponentInChildren<Canvas>().enabled = false;
        vendor.GetComponentInChildren<Canvas>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(difficult);
    }

    public void pause() {
        if (UI.GetComponentInChildren<Canvas>().enabled) {
            UI.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else {
            UI.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0.0f;
        }
    }
}
