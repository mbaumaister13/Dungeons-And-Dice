using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    PlayerController player;
    void Start(){
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="Enemy"){
            col.GetComponent<Enemy>().takeDamage(player.damage);
        }
    }
}
