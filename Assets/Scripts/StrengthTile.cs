using UnityEngine;
public class StrengthTile: Tile
{
    public override void execute(){
        Debug.Log("Activating Strength Tile");
        Player.strength += .5f;
    }
}