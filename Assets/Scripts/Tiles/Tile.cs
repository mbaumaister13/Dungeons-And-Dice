using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    public string tileType;
    public int tileIndex;
    public bool hasVisited;
    protected PlayerController player;
    protected VendorManager vendor;
    void Start(){
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
        GameObject[] objs = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach(GameObject g in objs) {
            if (g.name == "VendorManager") {
                vendor = g.GetComponent<VendorManager>();
            }

        }
    }
    public virtual void execute(){
        Debug.Log("Activiating Normal Tile");
        Player.gold += 5;
    }
}