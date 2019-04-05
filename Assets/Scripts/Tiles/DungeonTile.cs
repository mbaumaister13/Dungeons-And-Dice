using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
public class DungeonTile: Tile
{
    public override void execute(){
        Player.saveCamState();
        Debug.Log("Activating Dungeon Tile");
        StartCoroutine(unloadScene());
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
    }
    IEnumerator unloadScene(){
        yield return new WaitForEndOfFrame();
        foreach(GameObject g in SceneManager.GetActiveScene().GetRootGameObjects()){
            g.SetActive (false);
        }
    }
}
