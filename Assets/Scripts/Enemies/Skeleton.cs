using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Panda;

public class Skeleton : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 50f;
        damage = 5;
        attackSpeed = 3f;
    }

    // Update is called once per frame
    public override void Update()
    {
        if(hp <= 0){
            Debug.Log("Skeleton died");
            Destroy(gameObject);
        }
    }
    // [Task]
    // public override void canSeePlayer(){
    //     Vector2 targetDir = rb.transform.position - player.transform.position;
    //     if(targetDir.magnitude <10){
    //         Task.current.Succeed();
    //     }
    //     else{
    //         Task.current.Fail();
    //     }
    // }
    [Task]
    public void seekPlayer(){
        float dir = Mathf.Sign((player.transform.position-rb.transform.position).x);
        rb.velocity = new Vector2(dir*moveSpeed*Time.fixedDeltaTime,rb.velocity.y);
        if(canAttack){
            Task.current.Succeed();
        }
        else{
            Task.current.Fail();
        }
    }
    [Task]
    public override void attack(){
        attackTimer = Time.time;
        canAttack = false;
        player.takeDamage(damage);
        Task.current.Succeed();
    }
    [Task]
    public void print1(){
        Debug.Log("Function 1 returning successful");
        Task.current.Succeed();
    }
    [Task]
    public void print2(){
        Debug.Log("Function 2 returning failure");
        Task.current.Fail();
    }
    [Task]
    public void print3(){
        Debug.Log("Function 3 returning successful");
        Task.current.Succeed();
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            if(Time.time-attackTimer>=attackSpeed){
                canAttack = true;
            }
            Debug.Log("Player HIT");
        }
    }
}
