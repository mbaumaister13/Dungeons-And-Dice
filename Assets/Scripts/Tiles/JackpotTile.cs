using UnityEngine;
public class JackpotTile: Tile
{
    public override void execute(){
        Debug.Log("Activating Jackpot Tile");
        player.gold += 100;
    }
}