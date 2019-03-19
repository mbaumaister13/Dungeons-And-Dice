using UnityEngine;
public class CheckpointTile: Tile
{
    public GameObject checkpoint;
    public override void execute(){
        Debug.Log("Activating Checkpoint Tile");
        checkpoint.transform.position = transform.position;
    }
}
