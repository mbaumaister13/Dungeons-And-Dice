using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static string dungeonState;
    public static int numPlayers;
    public static Player[] players;
    public static Dice dice;
    public static string difficult;
    public static UIManager UI;
    public static VendorManager vendor;
    public static MeterManager meterManager;
    public static TextMeshProUGUI winText;
    public static int gold,hp;
    // Start is called before the first frame update
    void Start()
    {
        //UI = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        //meterManager= GameObject.Find("MeterManager").GetComponent<MeterManager>();
        //vendor = GameObject.Find("VendorManager").GetComponent<VendorManager>();
        UI.GetComponentInChildren<Canvas>().enabled = false;
        if(vendor!=null){
            vendor.GetComponentInChildren<Canvas>().enabled = false;
        }
        if (meterManager != null) {
            winText = meterManager.transform.Find("PlayerMeters").transform.Find("WinText").gameObject.GetComponent<TextMeshProUGUI>();
            winText.enabled = false; 
        }
        DontDestroyOnLoad(this);
    }
    public static IEnumerator unloadScene(){
        yield return new WaitForEndOfFrame();
        foreach(GameObject g in SceneManager.GetActiveScene().GetRootGameObjects()){
            g.SetActive (false);
        }
    }

    public static void pauseGame() {
        if (UI.GetComponentInChildren<Canvas>().enabled) {
            UI.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else {
            UI.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0.0f;
        }
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
