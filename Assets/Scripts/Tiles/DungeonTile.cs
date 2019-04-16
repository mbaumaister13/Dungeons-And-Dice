using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
public class DungeonTile: Tile
{
    public override void execute(){
        PlayerManager.instance.player.GetComponent<Player>().dungeonCount++;
        GameManager.dungeonState = "dungeon" + PlayerManager.instance.player.GetComponent<Player>().dungeonCount.ToString();
        Player.saveCamState();
        GameManager.gold = PlayerManager.instance.player.GetComponent<Player>().gold;
        GameManager.hp = PlayerManager.instance.player.GetComponent<Player>().hp;
        Debug.Log("Activating Dungeon Tile");
        StartCoroutine(GameManager.unloadScene());
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
        
    }
}
