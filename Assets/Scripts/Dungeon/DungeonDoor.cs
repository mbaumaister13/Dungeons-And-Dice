using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonDoor : MonoBehaviour
{   
    PlayerController player;
    void Start(){
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            player.gold += 10;
            SceneManager.UnloadSceneAsync(2);
            foreach(GameObject g in SceneManager.GetSceneByName("BoardScene").GetRootGameObjects()){
                g.SetActive (true);
                if (g.name == "Player") {
                    g.GetComponent<Player>().gold = player.gold;
                    g.GetComponent<Player>().hp = player.hp;
                    PlayerManager.instance.player = g;
                }
            }
        }
    }
}
