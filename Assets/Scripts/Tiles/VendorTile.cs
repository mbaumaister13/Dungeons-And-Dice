using UnityEngine;
public class VendorTile: Tile
{
    public override void execute(){
        Debug.Log("Activating Vendor Tile");
        vendor.GetComponentInChildren<Canvas>().enabled = true;
    }
}