using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    void Start(){
        player = PlayerManager.instance.player.GetComponent<Player>();
        GameObject[] objs = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach(GameObject g in objs) {
            if (g.name == "VendorManager") {
                vendor = g.GetComponent<VendorManager>();
            }
        }
        tooltip = gameObject.GetComponentInChildren<TextMeshPro>();
        tooltip.enabled = false;
    }

    void Update() {
        if (Mathf.Abs(tileIndex - player.currentTile) < 3) {
            tooltip.enabled = true;
        }

    }
    public virtual void execute(){
        Debug.Log("Activiating Normal Tile");
        player.gold += 5;
    }
}