using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="Enemy"){
            col.GetComponent<Enemy>().hp-=Player.damage;
        }
    }
}
