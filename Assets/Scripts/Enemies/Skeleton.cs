using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Panda;

public class Skeleton : Enemy
{
    bool canAttack;
    float attackSpeed;
    float attackTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 50f;
        damage = 5;
        canAttack = true;
        attackSpeed = 3f;
        attackTimer = 0;
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
    [Task]
    public override void canSeePlayer(){
        Vector2 targetDir = rb.transform.position - player.transform.position;
        if(targetDir.magnitude <10){
            Task.current.Succeed();
        }
        else{
            Task.current.Fail();
        }
    }
    [Task]
    public void seekPlayer(){
        Vector2 targetDir = player.transform.position-rb.transform.position;
        rb.transform.position = Vector2.MoveTowards(rb.transform.position,targetDir,moveSpeed*Time.fixedDeltaTime);
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
