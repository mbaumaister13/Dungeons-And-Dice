using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 50f;
        dmg = 5;
    }

    // Update is called once per frame
    public override void Update()
    {
        //Debug.Log(Vector3.Distance(player.transform.position,transform.position));
        if(Vector3.Distance(player.transform.position,transform.position) < 5){
            transform.position += (player.transform.position-transform.position) * Time.deltaTime * moveSpeed;
        }

        if(hp <= 0){
            Debug.Log("Skeleton died");
            Destroy(gameObject);
        }
    }

    public override void attack(){
        Player.Damage(dmg);
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            Debug.Log("Player HIT");
            attack();
        }
    }
    public override void Damage() {
        hp -= Player.strength * Player.damage;
    }
}
