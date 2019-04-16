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
    protected bool damaged = false;
    protected float invicibilityTime = 1f, invincibilityTimer = 0f;
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
    public virtual void Update() {
        if (hp <= 0) {
            Debug.Log("died");
            Destroy(gameObject,1f);
        }
        if (Time.time - invincibilityTimer >= invicibilityTime && damaged) {
            damaged = false;
        }
    }
    // Update is called once per frame
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
    [Task]
    public void isDamaged() {
        if (damaged) {
            Task.current.Succeed();
        }
        else {
            Task.current.Fail();
        }
    }
    public virtual void takeDamage(int d) {
        hp -= d;
        Debug.Log(rb.velocity);
        Vector2 knockback = new Vector2(-rb.velocity.x*2, -rb.velocity.y);
        rb.AddForce(knockback, ForceMode2D.Impulse);
        invincibilityTimer = Time.time;
        damaged = true;
        Debug.Log(rb.velocity);
        Debug.Log("DAMAGE");
    }
}
