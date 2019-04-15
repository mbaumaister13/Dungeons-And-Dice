using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
public class Enemy : MonoBehaviour
{
    protected PlayerController player;
    //string name;
    protected Rigidbody2D rb;
    protected int damage;
    public float hp;
    public float moveSpeed;
    protected bool canAttack;
    protected float attackSpeed;
    protected float attackTimer;
    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackTimer = 0;
        canAttack = true;

    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public virtual void attack(){    }
    [Task]
    public virtual void canSeePlayer(){
        Vector2 targetDir = rb.transform.position - player.transform.position;
        if(targetDir.magnitude <5){
            Task.current.Succeed();
        }
        else{
            Task.current.Fail();
        }
    }
}
