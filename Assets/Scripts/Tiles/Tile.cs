using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    public string tileType;
    public int tileIndex;
    public bool hasVisited;
    protected TextMeshPro tooltip;
    protected Player player;
    protected VendorManager vendor;
    protected UIManager UI;
    protected MeterManager meterManager;
    private Toggle toggleTooltip;
    protected TextMeshProUGUI winText;
    void Start(){
        player = PlayerManager.instance.player.GetComponent<Player>();
        GameObject[] objs = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach(GameObject g in objs) {
            if (g.name == "VendorManager") {
                vendor = g.GetComponent<VendorManager>();
            } else if (g.name == "UI_Manager") {
                UI = g.GetComponent<UIManager>();
            } else if (g.name == "MeterManager") {
                meterManager = g.GetComponent<MeterManager>();
            }
        }
        if(UI != null) {
            toggleTooltip = UI.GetComponentInChildren<Canvas>().transform.Find("Tooltip").gameObject.GetComponentInChildren<Toggle>();
        }
        if (meterManager != null) {
            winText = meterManager.transform.Find("PlayerMeters").transform.Find("WinText").gameObject.GetComponent<TextMeshProUGUI>();
        }
        tooltip = gameObject.GetComponentInChildren<TextMeshPro>();
        tooltip.enabled = false;
    }

    void Update() {
        if (toggleTooltip.isOn && toggleTooltip != null) {
            toggleTooltip.GetComponentInChildren<Text>().text = "Enabled";
        } else if (!toggleTooltip.isOn && toggleTooltip != null) {
            toggleTooltip.GetComponentInChildren<Text>().text = "Disabled";
        }
        if (Mathf.Abs(tileIndex - player.currentTile) < 3 && toggleTooltip.isOn && toggleTooltip != null) {
            tooltip.enabled = true;
        } else {
            tooltip.enabled = false;
        }

    }
    public virtual void execute(){
        Debug.Log("Activiating Normal Tile");
        player.gold += 5;
    }
}