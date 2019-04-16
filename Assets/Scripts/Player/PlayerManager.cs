using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager: MonoBehaviour{
    #region Singleton

    public static PlayerManager instance;
    void Awake(){
        instance = this;
    }

    #endregion

    //public void respawnPlayer(){
    //    player = savedPlayer;
    //    SceneManager.UnloadSceneAsync(2);
    //    foreach (GameObject g in SceneManager.GetSceneByName("BoardScene").GetRootGameObjects()) {
    //        g.SetActive(true);
    //    }
    //}
    //public void savePlayer(Player p) {
    //    savedPlayer = p.gameObject;
    //}
    public GameObject player;
    public GameObject savedPlayer;
}