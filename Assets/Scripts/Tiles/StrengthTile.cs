using UnityEngine;
public class StrengthTile: Tile
{
    public override void execute(){
        Debug.Log("Activating Strength Tile");
        player.strength += .5f;
    }
}