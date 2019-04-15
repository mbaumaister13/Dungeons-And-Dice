using UnityEngine;
public class JackpotTile: Tile
{
    public override void execute(){
        Debug.Log("Activating Jackpot Tile");
        Player.gold += 50;
    }
}