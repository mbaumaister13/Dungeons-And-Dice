using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonDoor : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            SceneManager.UnloadSceneAsync(2);
            foreach(GameObject g in SceneManager.GetSceneByName("BoardScene").GetRootGameObjects()){
                g.SetActive (true);
            }
            Player.gold += 10;
        }
    }
}
