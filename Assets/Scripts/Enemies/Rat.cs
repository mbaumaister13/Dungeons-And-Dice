using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class Rat : Enemy
{
    // Start is called before the first frame update
    int gold = 0;
    float dir = 0;
    SpriteRenderer sr;
    void Start()
    {
        hp = 5f;
        damage = 5;
        moveSpeed = 150f;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0){
            player.gold+=gold;
            Debug.Log("Rat died");
            Destroy(gameObject);
        }
        if(dir>0){
            sr.flipX = true;
        }
        else{
            sr.flipX = false;
        }
    }
    [Task]
    public override void canSeePlayer(){
        Vector2 targetDir = rb.transform.position - player.transform.position;
        if(targetDir.magnitude <5){
            sr.enabled = true;
            Task.current.Succeed();
        }
        else{
            Task.current.Fail();
        }
    }
    [Task]
    public void seekPlayer(){
        dir = Mathf.Sign((player.transform.position-rb.transform.position).x);
        rb.velocity = new Vector2(dir*moveSpeed*Time.fixedDeltaTime,rb.velocity.y);
        if((player.transform.position-rb.transform.position).magnitude<1&&canAttack){
            attack();
            canAttack = false;
            Debug.Log("Player has lost "+gold+" gold!");
        }
        if(gold > 0){
            Task.current.Succeed();
        }
        else{
            Task.current.Fail();
        }
    }
    [Task]
    public void runAway(){
        rb.velocity = new Vector2(dir*moveSpeed*Time.fixedDeltaTime,rb.velocity.y);
        if((player.transform.position - rb.transform.position).magnitude > 7.5){
            Task.current.Succeed();
            Destroy(gameObject);
        }
    }
    [Task]
    public override void attack(){
        if(player.gold<=10){
            gold+=player.gold;
            player.gold = 0;
        }
        else{
            gold += (int)(player.gold*.1f);
            player.gold = (int)(player.gold*.9f);
        }
        player.takeDamage(damage);
    }
}
