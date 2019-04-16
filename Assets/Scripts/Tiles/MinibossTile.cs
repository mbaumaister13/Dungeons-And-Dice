using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
public class MinibossTile: Tile
{
    public override void execute(){
        GameManager.dungeonState = "miniboss";
        Player.saveCamState();
        Debug.Log("Activating Miniboss Tile");
        StartCoroutine(GameManager.unloadScene());
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
    }
}