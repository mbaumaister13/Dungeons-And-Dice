using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : Player
{
    SpriteRenderer sr;
    public Transform groundCheck;
    public BoxCollider2D wep;
    public float moveSpeed, jumpForce;
    bool movingRight = false, grounded = false;
    public LayerMask WhatIsGround;
    Rigidbody2D rb;
    Animator animator;
    float horizontalMove = 0f, groundRadius = .2f, wepOffset;
    //public MeterManager meterManager;
    TextMeshProUGUI HealthText, StrengthText, GoldText;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        wepOffset = wep.offset.x;
        HealthText = meterManager.transform.Find("PlayerMeters").transform.Find("Health").gameObject.GetComponent<TextMeshProUGUI>(); 
        StrengthText = meterManager.transform.Find("PlayerMeters").transform.Find("Strength").gameObject.GetComponent<TextMeshProUGUI>(); 
        GoldText = meterManager.transform.Find("PlayerMeters").transform.Find("Gold").gameObject.GetComponent<TextMeshProUGUI>(); 
    }

    void Update(){
        HealthText.SetText("Health: " + hp + " hp");
        StrengthText.SetText("Strength: x" + strength);
        GoldText.SetText("Gold: " + gold);
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space")&&grounded){
            rb.AddForce(new Vector2(0,jumpForce));
        }
        if(Input.GetMouseButtonDown(0)&&Time.time-attackTimer>=attackSpeed){
            if(horizontalMove!=0){
                wep.offset = new Vector2(wepOffset*horizontalMove,wep.offset.y);
            }
            animator.SetTrigger("isAttacking");
            attackTimer = Time.time;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,WhatIsGround);

        if (horizontalMove==1){
            if(!movingRight){
                sr.flipX = false;
                movingRight = true;
                animator.SetBool("isFacingRight",true);
            }
        }
        if (horizontalMove==-1){
            if(movingRight){
                sr.flipX = true;
                movingRight = false;
                animator.SetBool("isFacingRight",false);
            }
        }
        animator.SetBool("onGround",grounded);
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
        rb.velocity = new Vector2 (horizontalMove* moveSpeed, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy"){
            Debug.Log("Enemy HIT");
            //Enemy.Damage();
        }
    }
    public void takeDamage(int damage){
        hp-=damage;
        Debug.Log("Player took "+damage+" damage!");
    }
}
