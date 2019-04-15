using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
public class DungeonTile: Tile
{
    public override void execute(){
        Player.saveCamState();
        Debug.Log("Activating Dungeon Tile");
        StartCoroutine(GameManager.unloadScene());
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
    }
    
}
