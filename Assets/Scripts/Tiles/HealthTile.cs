using UnityEngine;
public class HealthTile: Tile
{
    public override void execute(){
        Debug.Log("Activating Health Tile");       
        player.hp += 50;
    }
}