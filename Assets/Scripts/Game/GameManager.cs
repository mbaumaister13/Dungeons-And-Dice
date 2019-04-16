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
    public UIManager UI;
    public VendorManager vendor;
    public MeterManager meterManager;
    protected TextMeshProUGUI winText;
    // Start is called before the first frame update
    void Start()
    {
        UI.GetComponentInChildren<Canvas>().enabled = false;
        if(vendor!=null){
            vendor.GetComponentInChildren<Canvas>().enabled = false;
        }
        if (meterManager != null) {
            winText = meterManager.transform.Find("PlayerMeters").transform.Find("WinText").gameObject.GetComponent<TextMeshProUGUI>();
            winText.enabled = false; 
        }
    }
    public static IEnumerator unloadScene(){
        yield return new WaitForEndOfFrame();
        foreach(GameObject g in SceneManager.GetActiveScene().GetRootGameObjects()){
            g.SetActive (false);
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
