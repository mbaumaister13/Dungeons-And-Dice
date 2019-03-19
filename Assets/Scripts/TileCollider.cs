using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollider : MonoBehaviour
{
    // Start is called before the first frame update
    Tile tile;
    void Start()
    { 
        tile = transform.parent.GetComponent<Tile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col){
        if(col.tag=="Player"){
            tile.hasVisited = true;
            if(col.gameObject.GetComponent<Player>().spacesToMove==1){
                tile.execute();
            }
        }
    }
}
